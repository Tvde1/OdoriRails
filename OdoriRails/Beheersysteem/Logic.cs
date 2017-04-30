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
        public List<BeheerTrack> AllTracks { get; private set; }
        bool testing = true;
        int simulationSpeed = 600;

        ICSVContext csv;
        private LogisticRepository repo = new LogisticRepository();
        private List<InUitRijSchema> schema;
        private List<BeheerTram> allTrams;
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
            allTrams = new List<BeheerTram>();
            foreach (Tram tram in repo.GetAllTrams())
            {
                allTrams.Add(tram == null ? null : BeheerTram.ToBeheerTram(tram));
            }
        }

        public bool SortMovingTrams(TramLocation location)
        {
            SortingAlgoritm sorter = new SortingAlgoritm(AllTracks, repo);
            List<Tram> movingTrams = repo.GetAllTramsWithLocation(location);
            if (movingTrams.Count != 0)
            {
                foreach (Tram tram in movingTrams)
                {
                    BeheerTram beheerTram = BeheerTram.ToBeheerTram(tram);
                    if (location == TramLocation.ComingIn)
                    {
                        if (tram.DepartureTime == null)
                        {
                            GetExitTime(beheerTram);
                        }
                        SortTram(sorter, beheerTram);
                    }
                    else if (location == TramLocation.GoingOut)
                    {
                        beheerTram.EditTramLocation(TramLocation.Out);
                        repo.EditTram(beheerTram);
                        repo.WipeSectorByTramId(tram.Number);
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
            int trackNumber = Convert.ToInt32(_track);

            foreach (Track track in AllTracks.Where(x => x.Number == trackNumber))
            {
                track.AddSector(new Sector(track.Sectors.Count));
                repo.AddSector(track.Sectors[track.Sectors.Count - 1], track);
                Update();
                return true;
            }
            return false;
        }



        public bool DeleteSector(string _track)
        {
            int trackNumber = Convert.ToInt32(_track);

            foreach (Track track in AllTracks.Where(x => x.Number == trackNumber && x.Sectors[x.Sectors.Count - 1].OccupyingTram == null))
            {
                track.DeleteSector();
                repo.DeleteSectorFromTrack(track, track.Sectors[track.Sectors.Count - 1]);
                Update();
                return true;
            }
            return false;
        }

        public bool DeleteTrack(string _track)
        {
            int trackNumber = Convert.ToInt32(_track);

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
                AllTracks = sorter.AssignTramLocation(tram);
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
                foreach (BeheerTram tram in allTrams.Where(x => x.DepartureTime == null && x.Line == entry.Line))
                {
                    entry.TramNumber = tram.Number;
                    tram.EditTramDepartureTime(entry.ExitTime);
                    break;
                }
            }

            //Too little linebound trams to fill each entry so overflow to other types of trams
            foreach (InUitRijSchema entry in schema.Where(x => x.TramNumber == null))
            {
                foreach (BeheerTram tram in allTrams.Where(x => x.DepartureTime == null))
                {
                    if ((entry.Line == 5 || entry.Line == 1624) && (tram.Model == Model.Dubbel_Kop_Combino || tram.Model == Model.TwaalfG)) //No driver lines
                    {
                        entry.TramNumber = tram.Number;
                        tram.EditTramDepartureTime(entry.ExitTime);
                        break;
                    }
                    else if ((entry.Line != 5 || entry.Line != 1624) && tram.Model == Model.Combino) //Driver lines
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
                BeheerTram tram = allTrams.Find(x => x.Number == entry.TramNumber);
                SortTram(sorter, tram);
                form.Invalidate();
                Thread.Sleep(simulationSpeed);
            }

            schema = csv.getSchema();
            Update();
        }

        public void Lock(string tracks)
        {
            int[] lockTracks = Array.ConvertAll(tracks.Split(','), int.Parse);
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
            Update();
        }

        public void Unlock(string tracks)
        {
            int[] UnlockTracks = Array.ConvertAll(tracks.Split(','), int.Parse);
            foreach (Track track in AllTracks)
            {
                int pos = Array.IndexOf(UnlockTracks, track.Number);
                if (pos > -1)
                {
                    BeheerTrack beheerTrack = track == null ? null : BeheerTrack.ToBeheerTrack(track);
                    beheerTrack.UnlockTrack();
                    repo.EditTrack(beheerTrack);
                }
            }
            Update();
        }

        public void ToggleDisabled(string trams)
        {
            int[] iTrams = Array.ConvertAll(trams.Split(','), int.Parse);
            foreach (BeheerTram tram in allTrams)
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
            int moveTram = Convert.ToInt32(_tram);
            int moveTrack = Convert.ToInt32(_track);
            int moveSector = Convert.ToInt32(_sector);

            foreach (Track track in AllTracks.Where(x => x.Number == moveTrack && x.Sectors.Count > moveSector))
            {
                foreach (Tram tram in allTrams.Where(x => x.Number == moveTram))
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
            return false;
        }

        public void AddTram(string _tramNumber, string _defaultLine, string _model)
        {
            int tramNumber = Convert.ToInt32(_tramNumber);
            int defaultLine = Convert.ToInt32(_defaultLine);
            Model model;
            Enum.TryParse<Model>(_model, out model);

            repo.AddTram(new Tram(tramNumber, defaultLine, model));
        }

        public void AddTrack(string _trackNumber, string _sectorAmount, string _trackType, string _defaultLine)
        {
            int trackNumber = Convert.ToInt32(_trackNumber);
            int sectorAmount = Convert.ToInt32(_sectorAmount);
            int? defaultLine = Convert.ToInt32(_defaultLine);

            TrackType trackType;
            Enum.TryParse<TrackType>(_trackType, out trackType);

            List<Sector> newSectors = new List<Sector>();
            for (int i = 0; i < sectorAmount; i++)
            {
                newSectors.Add(new Sector(i));
            }

            repo.AddTrack(new Track(trackNumber, defaultLine, trackType, newSectors));
            Update();
        }

        public void Update()
        {
            FetchUpdates();
            form.Invalidate();
        }
    }
}
