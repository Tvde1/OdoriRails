using Beheersysteem.DAL;
using Beheersysteem.ObjectClasses;
using OdoriRails.DAL;
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
        //ILogisticDatabaseAdapter database = new MssqlDatabaseContext();
        private LogisticRepository repo = new LogisticRepository();
        SortingAlgoritm sorter;
        List<InUitRijSchema> schema;
        List<BeheerTram> allTrams;
        List<Tram> enteringTrams;
        private List<BeheerTrack> _allTracks;
        private Form form;
        private System.Windows.Forms.Timer tramFetcher;

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
            sorter = new SortingAlgoritm(AllTracks, repo);
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

        public bool SortAllEnteringTrams()
        {
            enteringTrams = repo.GetAllTramsWithLocation(TramLocation.ComingIn);
            if (enteringTrams.Count != 0)
            {
                foreach (Tram tram in enteringTrams)
                {
                    BeheerTram beheerTram = BeheerTram.ToBeheerTram(tram);
                    if (tram.DepartureTime == null)
                    {
                        GetExitTime(beheerTram);
                    }
                    SortTram(beheerTram);
                }
                FetchUpdates();
                return true;
            }
            return false;
        }

        public void tramFetcher_Tick(object sender, EventArgs e)
        {
            if (SortAllEnteringTrams())
            {
                form.Invalidate();
            }
        }

        public void WipeDepartureTimes()
        {
            //TODO: Voeg toe aan master
            //database.WipeTramDepartureTime();
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

        public void SortTram(BeheerTram tram)
        {
            if (tram != null)
            {
                _allTracks = sorter.GetSector(tram, tram.DepartureTime);
            }
        }

        public void Simulation()
        {
            sorter = new SortingAlgoritm(AllTracks, repo);
            WipePreSimulation();

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
                                form.Invalidate();
                                break;
                            }
                            else if ((entry.Line != 5 || entry.Line != 1624) && tram.Model == Model.Combino)//Driver lines
                            {
                                entry.TramNumber = tram.Number;
                                tram.EditTramDepartureTime(entry.ExitTime);
                                form.Invalidate();
                                break;
                            }
                        }

                    }
                }
            }

            ////Overgebleven trams en schema entries
            //Console.WriteLine("Overgebleven schema's");
            //foreach (InUitRijSchema entry in schema)
            //{
            //    if (entry.TramNumber == null)
            //    {
            //        Console.WriteLine(entry.Line);
            //    }
            //}

            //Console.WriteLine("Overgebleven trams:");
            //foreach (BeheerTram tram in allTrams)
            //{
            //    if (tram.DepartureTime == null)
            //    {
            //        Console.WriteLine(tram.Number + " : " + tram.Line + " : " + tram.Model.ToString());
            //    }
            //}
            
            //Het schema afgaan voor de simulatie
            foreach (InUitRijSchema entry in schema)
            {
                BeheerTram tram = allTrams.Find(x => x.Number == entry.TramNumber);
                SortTram(tram);
                form.Invalidate();
                Thread.Sleep(simulationSpeed);
            }

            //Sync with database:
            FetchUpdates();
            form.Invalidate();
        }

        public void Lock(string tracks)
        {
            //TODO: Lock en Unlock wordt nu in de classe aangepast maar niet in de database
            string[] sLockTracks = tracks.Split(',');
            int[] lockTracks = Array.ConvertAll(sLockTracks, int.Parse);

            foreach (Track track in _allTracks)
            {
                int pos = Array.IndexOf(lockTracks, track.Number);
                if (pos > -1)
                {
                    repo.EditTrack(track);
                }
            }
        }

        public void Unlock(string tracks)
        {
            //TODO: Lock en Unlock wordt nu in de classe aangepast maar niet in de database
            string[] sUnlockTracks = tracks.Split(',');
            int[] UnlockTracks = Array.ConvertAll(sUnlockTracks, int.Parse);

            foreach (Track track in _allTracks)
            {
                int pos = Array.IndexOf(UnlockTracks, track.Number);
                if (pos > -1)
                {
                    repo.EditTrack(track);
                }
            }
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

        public void MoveTram(string trams, string track, string sector)
        {
            string[] sTrams = trams.Split(',');
            int[] iTrams = Array.ConvertAll(sTrams, int.Parse);
            int moveTram = iTrams[0]; //Alleen de eerste bewegen

            int moveTrack = Convert.ToInt32(track);
            int moveSector = Convert.ToInt32(sector);

            foreach (Tram tram in allTrams)
            {
                int pos = Array.IndexOf(iTrams, tram.Number);
                if (pos > -1)
                {
                    //foreach (Track track in _allTracks)
                    //{

                    //}
                }

            }
        }
    }
}
