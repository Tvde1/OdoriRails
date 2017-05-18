using Beheersysteem.DAL;
using Beheersysteem.ObjectClasses;
using OdoriRails.BaseClasses;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Threading;
using Beheersysteem.DAL.Repository;
using System.Linq;

namespace Beheersysteem
{
    class Logic
    {
        public List<BeheerTrack> BackupAllTracks;
        public List<BeheerTrack> AllTracks { get; private set; }
        public List<BeheerTram> AllTrams { get; private set; }
        bool testing = true;
        int simulationSpeed = 600;

        ICSVContext csv;
        private LogisticRepository repo = new LogisticRepository();
        private List<InUitRijSchema> schema;

        private Form form;
        public System.Windows.Forms.Timer tramFetcher;

        /// <summary>
        /// Constructor: Voert alles uit dat bij de launch uitgevoerd moet worden.
        /// </summary>
        public Logic(Form form)
        {
            if (testing == true)
            {
                simulationSpeed = 50;
            }

            FetchUpdates();
            csv = new CSVContext();
            schema = csv.getSchema();
            this.form = form;

            tramFetcher = new System.Windows.Forms.Timer() { Interval = 5000 };
            tramFetcher.Tick += tramFetcher_Tick;
            tramFetcher.Start();
        }

        public void FetchUpdates()
        {
            AllTracks = new List<BeheerTrack>();
            foreach (Track track in repo.GetTracksAndSectors())
            {
                AllTracks.Add(track == null ? null : BeheerTrack.ToBeheerTrack(track));
            }
            AllTrams = new List<BeheerTram>();
            foreach (Tram tram in repo.GetAllTrams())
            {
                AllTrams.Add(tram == null ? null : BeheerTram.ToBeheerTram(tram));
            }
        }

        public bool SortMovingTrams(TramLocation location)
        {
            SortingAlgoritm sorter = new SortingAlgoritm(AllTracks, repo);
            List<Tram> movingTrams = repo.GetAllTramsWithLocation(location);
            if (movingTrams.Count != 0)
            {
                for (int i = 0; i < movingTrams.Count; i++)
                {
                    BeheerTram beheerTram = BeheerTram.ToBeheerTram(movingTrams[i]);
                    if (location == TramLocation.ComingIn)
                    {
                        if (movingTrams[i].DepartureTime == null)
                        {
                            GetExitTime(beheerTram);
                        }
                        SortTram(sorter, beheerTram);
                    }
                    else if (location == TramLocation.GoingOut)
                    {
                        beheerTram.EditTramLocation(TramLocation.Out);
                        movingTrams[i] = beheerTram;
                        repo.EditTram(movingTrams[i]);
                        repo.WipeSectorByTramId(movingTrams[i].Number);
                    }
                }
                FetchUpdates();
                return true;
            }
            return false;
        }

        public void tramFetcher_Tick(object sender, EventArgs e)
        {
            if (SortMovingTrams(TramLocation.ComingIn))
            {
                form.Invalidate();
            }
            if (SortMovingTrams(TramLocation.GoingOut))
            {
                form.Invalidate();
            }
        }

        public bool AddSector(string _track)
        {
            int trackNumber = ToInt(_track);

            foreach (Track track in AllTracks.Where(x => x.Number == trackNumber))
            {
                track.AddSector(new Sector(track.Sectors.Count + 1));
                repo.AddSector(track.Sectors[track.Sectors.Count - 1], track);
                Update();
                return true;
            }
            return false;
        }

        public bool DeleteSector(string _track)
        {
            int trackNumber = ToInt(_track);

            foreach (Track track in AllTracks.Where(x => x.Number == trackNumber && x.Sectors[x.Sectors.Count - 1].OccupyingTram == null))
            {
                track.DeleteSector();
                repo.DeleteSectorFromTrack(track, track.Sectors[track.Sectors.Count - 1]);
                Update();
                return true;
            }
            return false;
        }

        public void DeleteTram(string _tram)
        {
            int tramNumber = ToInt(_tram);

            foreach (Tram tram in AllTrams.Where(x => x.Number == tramNumber))
            {
                repo.RemoveTram(tram);
                Update();
            }

        }

        public bool DeleteTrack(string _track)
        {
            int trackNumber = ToInt(_track);

            foreach (Track track in AllTracks.Where(x => x.Number == trackNumber))
            {
                if (track.Sectors.Where(x => x.OccupyingTram != null).Count() > 0)
                {
                    return false;
                }
                repo.DeleteTrack(track);
                Update();
                return true;
            }
            return false;
        }

        public void WipePreSimulation()
        {
            repo.WipeAllDepartureTimes();
            repo.WipeAllTramsFromSectors();
            FetchUpdates();
        }

        public DateTime? GetExitTime(BeheerTram tram)
        {
            foreach (InUitRijSchema entry in schema.Where(x => x.Line == tram.Line && x.TramNumber == null))
            {
                entry.TramNumber = tram.Number;
                return entry.ExitTime;
            }
            return null;
        }

        public void SortTram(SortingAlgoritm sorter, BeheerTram tram)
        {
            if (tram != null)
            {
                BackupAllTracks = AllTracks;
                AllTracks = sorter.AssignTramLocation(tram);

                if (AllTracks == null)
                {
                    AllTracks = BackupAllTracks;
                }
            }
        }

        public void Simulation()
        {
            SortingAlgoritm sorter = new SortingAlgoritm(AllTracks, repo);

            //De schema moet op volgorde van eerst binnenkomende worden gesorteerd
            schema.Sort((x, y) => x.EntryTime.CompareTo(y.EntryTime));

            //Voor iedere inrijtijd een tram eraan koppellen
            foreach (InUitRijSchema entry in schema.Where(x => x.TramNumber == null))
            {
                foreach (BeheerTram tram in AllTrams.Where(x => x.DepartureTime == null && x.Line == entry.Line))
                {
                    entry.TramNumber = tram.Number;
                    tram.EditTramDepartureTime(entry.ExitTime);
                    break;
                }
            }

            //Too little linebound trams to fill each entry so overflow to other types of trams
            foreach (InUitRijSchema entry in schema.Where(x => x.TramNumber == null))
            {
                foreach (BeheerTram tram in AllTrams.Where(x => x.DepartureTime == null))
                {
                    if ((entry.Line == 5 || entry.Line == 1624) && (tram.Model == TramModel.Dubbel_Kop_Combino || tram.Model == TramModel.TwaalfG)) //No driver lines
                    {
                        entry.TramNumber = tram.Number;
                        tram.EditTramDepartureTime(entry.ExitTime);
                        break;
                    }
                    else if ((entry.Line != 5 || entry.Line != 1624) && tram.Model == TramModel.Combino) //Driver lines
                    {
                        entry.TramNumber = tram.Number;
                        tram.EditTramDepartureTime(entry.ExitTime);
                        break;
                    }
                }
            }

            //Het schema afgaan voor de simulatie
            foreach (InUitRijSchema entry in schema)
            {
                BeheerTram tram = AllTrams.Find(x => x.Number == entry.TramNumber);
                SortTram(sorter, tram);
                form.Invalidate();
                Thread.Sleep(simulationSpeed);
            }

            foreach (BeheerTram tram in AllTrams.Where(x => x.DepartureTime == null))
            {
                SortTram(sorter, tram);
                form.Invalidate();
                Thread.Sleep(simulationSpeed);
            }

            schema = csv.getSchema();
            Update();

            MessageBox.Show("The simulation has finished, if there are some unassigned trams these could not be assigned a location without hindering standard activities. Please assign these by hand.");

        }

        public void Lock(string tracks, string sectors)
        {
            int[] lockSectors = { -1 };
            int[] lockTracks = { -1 };

            if (sectors != "")
            {
                lockSectors = Parse(sectors);
                for (int i = 0; i < lockSectors.Length; i++)
                {
                    lockSectors[i] -= 1;
                }
            }

            lockTracks = Parse(tracks);

            if (lockTracks[0] != -1)
            {
                if (sectors == "")
                {
                    foreach (Track track in AllTracks)
                    {
                        int pos = Array.IndexOf(lockTracks, track.Number);
                        if (pos > -1)
                        {
                            BeheerTrack beheerTrack = track == null ? null : BeheerTrack.ToBeheerTrack(track);
                            beheerTrack.LockTrack();
                            repo.EditTrack(beheerTrack);
                        }
                    }
                }
                else
                {
                    foreach (BeheerTrack track in AllTracks)
                    {
                        int pos = Array.IndexOf(lockTracks, track.Number);
                        if (pos > -1)
                        {
                            for (int i = 0; i < track.Sectors.Count - 1; i++)
                            {
                                pos = Array.IndexOf(lockSectors, i);
                                if (pos > -1)
                                {
                                    bool lockTrack = true;
                                    BeheerSector beheerSector = track.Sectors[i] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[i]);
                                    if (beheerSector.OccupyingTram != null)
                                    {
                                        DialogResult dialogResult = MessageBox.Show("There are trams on the location you are trying to lock, are you sure?", "Warning", MessageBoxButtons.YesNo);
                                        if (dialogResult == DialogResult.No)
                                        {
                                            lockTrack = false;
                                        }
                                    }
                                    if (lockTrack == true)
                                    {
                                        beheerSector.Lock();
                                        repo.EditSector(beheerSector);
                                    }
                                }
                            }
                        }
                    }
                }
                Update();
            }
        }

        public void Unlock(string tracks, string sectors)
        {
            int[] unlockSectors = { -1 };
            int[] unlockTracks = { -1 };

            if (sectors != "")
            {
                unlockSectors = Parse(sectors);
                for (int i = 0; i < unlockSectors.Length; i++)
                {
                    unlockSectors[i] -= 1;
                }
            }
            unlockTracks = Parse(tracks);

            if (unlockTracks[0] != -1)
            {
                if (sectors == "")
                {
                    foreach (Track track in AllTracks)
                    {
                        int pos = Array.IndexOf(unlockTracks, track.Number);
                        if (pos > -1)
                        {
                            BeheerTrack beheerTrack = track == null ? null : BeheerTrack.ToBeheerTrack(track);
                            beheerTrack.UnlockTrack();
                            repo.EditTrack(beheerTrack);
                        }
                    }
                }
                else
                {
                    foreach (BeheerTrack track in AllTracks)
                    {
                        int pos = Array.IndexOf(unlockTracks, track.Number);
                        if (pos > -1)
                        {
                            for (int i = 0; i < track.Sectors.Count - 1; i++)
                            {
                                pos = Array.IndexOf(unlockSectors, i);
                                if (pos > -1)
                                {
                                    BeheerSector beheerSector = track.Sectors[i] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[i]);
                                    beheerSector.UnLock();
                                    repo.EditSector(beheerSector);
                                }
                            }
                        }
                    }
                }
                Update();
            }
        }

        public void ToggleDisabled(string trams)
        {
            int[] iTrams = Parse(trams);
            foreach (BeheerTram tram in AllTrams)
            {
                int pos = Array.IndexOf(iTrams, tram.Number);
                if (pos > -1)
                {
                    if (tram.Status == TramStatus.Defect)
                    {
                        tram.EditTramStatus(TramStatus.Idle);
                        repo.EditTram(tram);
                    }
                    else
                    {
                        tram.EditTramStatus(TramStatus.Defect);
                        repo.EditTram(tram);
                    }
                }
            }
            Update();
        }

        public bool MoveTram(string _tram, string _track, string _sector)
        {
            int moveTram = ToInt(_tram);
            int moveTrack = ToInt(_track);
            int moveSector = ToInt(_sector) - 1;

            bool confirmMove = true;

            foreach (Tram tram in AllTrams.Where(x => (x.Number == moveTram) && (x.Status == TramStatus.Cleaning || x.Status == TramStatus.Maintenance || x.Status == TramStatus.CleaningMaintenance)))
            {
                confirmMove = false;
            }

            if (confirmMove == false)
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to move this tram, it is still in service", "Move Tram", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    confirmMove = true;
                }
            }

            if (confirmMove == true)
            {
                foreach (Track track in AllTracks.Where(x => x.Number == moveTrack && x.Sectors.Count > moveSector))
                {
                    foreach (Tram tram in AllTrams.Where(x => x.Number == moveTram))
                    {
                        BeheerSector beheerSector = track.Sectors[moveSector] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[moveSector]);
                        if (beheerSector.SetOccupyingTram(tram))
                        {
                            repo.WipeSectorByTramId(tram.Number);
                            repo.EditSector(beheerSector);
                            Update();
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void AddTram(string _tramNumber, string _defaultLine, string _model)
        {
            int tramNumber = ToInt(_tramNumber);
            int defaultLine = ToInt(_defaultLine);

            if (tramNumber != -1 && defaultLine != -1)
            {
                TramModel model;
                Enum.TryParse<TramModel>(_model, out model);

                repo.AddTram(new Tram(tramNumber, defaultLine, model));
                Update();
            }
        }

        public void AddTrack(string _trackNumber, string _sectorAmount, string _trackType, string _defaultLine)
        {
            int trackNumber = ToInt(_trackNumber);
            int sectorAmount = ToInt(_sectorAmount);
            int? defaultLine;
            if (_defaultLine == "")
            {
                defaultLine = 0;
            }
            else
            {
                defaultLine = ToInt(_defaultLine);
            }

            if (trackNumber != -1 && sectorAmount != -1)
            {
                TrackType trackType;
                Enum.TryParse<TrackType>(_trackType, out trackType);

                List<Sector> newSectors = new List<Sector>();
                for (int i = 0; i < sectorAmount; i++)
                {
                    newSectors.Add(new Sector(i + 1));
                }

                repo.AddTrack(new Track(trackNumber, defaultLine, trackType, newSectors));
                Update();
            }
        }

        public void Update()
        {
            FetchUpdates();
            form.Invalidate();
        }

        public int[] Parse(string _string)
        {
            int[] array = { -1 };

            try
            {
                array = Array.ConvertAll(_string.Split(','), int.Parse);
            }
            catch
            {
                MessageBox.Show("Couldn't process the input, please check if input is correct", "Error");
            }

            return array;
        }

        public int ToInt(string _string)
        {
            int integer = -1;

            try
            {
                integer = Convert.ToInt32(_string);
            }
            catch
            {
                MessageBox.Show("Couldn't process the input, please check if input is correct", "Error");
            }

            return integer;
        }
    }
}
