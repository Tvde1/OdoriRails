using Beheersysteem.DAL;
using Beheersysteem.ObjectClasses;
using OdoriRails.BaseClasses;
using System.Collections.Generic;
using System;
using System.Windows.Forms;
using System.Threading;
using OdoriRails.DAL.Repository;

namespace Beheersysteem
{
    class Logic
    {
        bool testing = true;
        int simulationSpeed = 600;

        ICSVContext csv;
        private List<InUitRijSchema> schema;
        private List<BeheerTram> allTrams;
        private LogisticRepository repo = new LogisticRepository();
        private List<BeheerTrack> _allTracks;
        private Form form;
        public System.Windows.Forms.Timer tramFetcher;

        public List<BeheerTrack> AllTracks => _allTracks;

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
            _allTracks = new List<BeheerTrack>();
            foreach (Track track in repo.GetTracksAndSectors())
            {
                _allTracks.Add(track == null ? null : BeheerTrack.ToBeheerTrack(track));
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

        public void WipePreSimulation()
        {
            repo.WipeAllDepartureTimes();
            repo.WipeAllTramsFromSectors();
            FetchUpdates();
        }

        public DateTime? GetExitTime(BeheerTram tram)
        {
            foreach (InUitRijSchema entry in schema)
            {
                if (tram.Line == entry.Line && entry.TramNumber == null)
                {
                    entry.TramNumber = tram.Number;
                    return entry.ExitTime;
                }
            }
            return null;
        }

        public void SortTram(SortingAlgoritm sorter, BeheerTram tram)
        {
            if (tram != null)
            {
                _allTracks = sorter.AssignTramLocation(tram, tram.DepartureTime);
            }
        }

        public void Simulation()
        {
            SortingAlgoritm sorter = new SortingAlgoritm(AllTracks, repo);

            //De schema moet op volgorde van eerst binnenkomende worden gesorteerd
            schema.Sort((x, y) => x.EntryTime.CompareTo(y.EntryTime));

            //Voor iedere inrijtijd een tram eraan koppellen
            foreach (InUitRijSchema entry in schema)
            {
                if (entry.TramNumber == null)
                {
                    foreach (BeheerTram tram in allTrams)
                    {
                        if (tram.DepartureTime == null && tram.Line == entry.Line)
                        {
                            entry.TramNumber = tram.Number;
                            tram.EditTramDepartureTime(entry.ExitTime);
                            break;
                        }
                    }
                }
            }

            //Too little linebound trams to fill each entry so overflow to other types of trams
            foreach (InUitRijSchema entry in schema)
            {
                if (entry.TramNumber == null)
                {
                    foreach (BeheerTram tram in allTrams)
                    {
                        if (tram.DepartureTime == null)
                        {
                            if ((entry.Line == 5 || entry.Line == 1624) && (tram.Model == Model.Dubbel_Kop_Combino || tram.Model == Model.TwaalfG))//No driver lines
                            {
                                entry.TramNumber = tram.Number;
                                tram.EditTramDepartureTime(entry.ExitTime);
                                break;
                            }
                            else if ((entry.Line != 5 || entry.Line != 1624) && tram.Model == Model.Combino)//Driver lines
                            {
                                entry.TramNumber = tram.Number;
                                tram.EditTramDepartureTime(entry.ExitTime);
                                break;
                            }
                        }
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

            //Sync with database:
            Update();
        }

        public void Lock(string tracks)
        {
            int[] lockTracks = Array.ConvertAll(tracks.Split(','), int.Parse);

            foreach (Track track in _allTracks)
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
            string[] sUnlockTracks = tracks.Split(',');
            int[] UnlockTracks = Array.ConvertAll(sUnlockTracks, int.Parse);

            foreach (Track track in _allTracks)
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
            //TODO: Lock en Unlock wordt nu in de classe aangepast maar niet in de database
            string[] sTrams = trams.Split(',');
            int[] iTrams = Array.ConvertAll(sTrams, int.Parse);

            foreach (BeheerTram tram in allTrams)
            {
                int pos = Array.IndexOf(iTrams, tram.Number);
                if (pos > -1)
                {
                    if (tram.Status == TramStatus.Idle)
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
        }

        public bool MoveTram(string _tram, string _track, string _sector)
        {
            int moveTram = Convert.ToInt32(_tram);
            int moveTrack = Convert.ToInt32(_track);
            int moveSector = Convert.ToInt32(_sector);

            foreach (Track track in AllTracks)
            {
                if (track.Number == moveTrack)
                {
                    foreach (Tram tram in allTrams)
                    {
                        if (tram.Number == moveTram)
                        {
                            BeheerSector beheerSector = track.Sectors[moveSector] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[moveSector]);
                            beheerSector.SetOccupyingTram(tram);
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

        public void Update()
        {
            FetchUpdates();
            form.Invalidate();
        }
    }
}
