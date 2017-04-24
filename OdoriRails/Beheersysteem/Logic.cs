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
                Sector selectedSector = sorter.GetSector(tram, tram.DepartureTime);
                if (selectedSector == null)
                {
                    MessageBox.Show("Het systeem kan geen passende plek vinden voor deze tram. Plaats deze tram manueel.");
                }
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
                        if (tram.Line == entry.Line && tram.DepartureTime == null)
                        {
                            Console.WriteLine(" Entry:" + entry.EntryTime.ToString() + " Exit:"  +  entry.ExitTime.ToString() + " Tram:" +  tram.Number);
                            entry.TramNumber = tram.Number;
                            tram.EditTramDepartureTime(entry.ExitTime);
                            form.Invalidate();
                            //Thread.Sleep(50);
                            break;
                        }
                    }
                    if(entry.TramNumber == null)
                    {
                        Console.WriteLine(" Entry:" + entry.EntryTime.ToString() + " Exit:" + entry.ExitTime.ToString() + " Failed to assign the line to a tram");
                    }
                    
                }
            }

            //Het schema afgaan voor de simulatie
            foreach (InUitRijSchema entry in schema)
            {
                //if (entry.TramNumber == null)
                //{
                //    MessageBox.Show(entry.ToString());
                //}
                Tram tram = allTrams.Find(x => x.Number == entry.TramNumber);
                BeheerTram beheerTram = BeheerTram.ToBeheerTram(tram);
                SortTram(beheerTram);
            }

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
