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
        List<Tram> allTrams;
        List<Tram> enteringTrams;
        private List<Track> _allTracks = new List<Track>();
        private Form form;
        private System.Windows.Forms.Timer tramFetcher;

        public List<Track> AllTracks => _allTracks;

        /// <summary>
        /// Constructor: Voert alles uit dat bij de launch uitgevoerd moet worden.
        /// </summary>
        public Logic(Form form)
        {
            _allTracks = repo.GetTracksAndSectors();
            csv = new CSVContext();
            schema = csv.getSchema();
            sorter = new SortingAlgoritm(AllTracks, repo);
            allTrams = repo.GetAllTrams();
            this.form = form;
            tramFetcher = new System.Windows.Forms.Timer() { Interval = 5000 };
            tramFetcher.Tick += tramFetcher_Tick;
        }

        public void SortAllEnteringTrams()
        {
            enteringTrams = repo.GetAllTramsWithLocation(TramLocation.ComingIn);
            foreach (Tram tram in enteringTrams)
            {
                if (tram.DepartureTime == null)
                {
                    GetExitTime(tram);
                }
                SortTram(tram);
            }
        }

        public void tramFetcher_Tick(object sender, EventArgs e)
        {
            SortAllEnteringTrams();
            form.Invalidate();
        }

        public void WipeDepartureTimes()
        {
            //TODO: Voeg toe aan master
            //database.WipeTramDepartureTime();
        }

        public void WipePreSimulation()
        {
            //TODO: Voeg toe aan master
            //database.WipeTramDepartureTime();
        }

        public DateTime? GetExitTime(Tram tram)
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

        public void SortTram(Tram tram)
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
            WipePreSimulation();

            //De schema moet op volgorde van eerst binnenkomende worden gesorteerd
            schema.Sort((x, y) => x.EntryTime.CompareTo(y.EntryTime));

            //Voor iedere inrijtijd een tram eraan koppellen
            foreach (InUitRijSchema entry in schema)
            {
                if (entry.TramNumber == null)
                {
                    foreach (Tram tram in allTrams)
                    {
                        if (tram.Line == entry.Line && tram.DepartureTime == null)
                        {
                            BeheerTram beheerTram;
                            beheerTram = tram == null ? null : BeheerTram.ToBeheerTram(tram);
                            entry.TramNumber = tram.Number;
                            beheerTram.EditTramDepartureTime(entry.ExitTime);
                            form.Invalidate();
                            //Thread.Sleep(50);
                            break;
                        }
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
                SortTram(tram);
            }

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
                    BeheerTrack beheerTrack;
                    beheerTrack = track == null ? null : BeheerTrack.ToBeheerTrack(track);
                    beheerTrack.LockTrack();
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
                    BeheerTrack beheerTrack;
                    beheerTrack = track == null ? null : BeheerTrack.ToBeheerTrack(track);
                    beheerTrack.UnlockTrack();
                    repo.EditTrack(track);
                }
            }
        }

        public void ToggleDisabled(string trams)
        {
            //TODO: Lock en Unlock wordt nu in de classe aangepast maar niet in de database
            string[] sTrams = trams.Split(',');
            int[] iTrams = Array.ConvertAll(sTrams, int.Parse);

            foreach (Tram tram in allTrams)
            {
                int pos = Array.IndexOf(iTrams, tram.Number);
                if (pos > -1)
                {
                    if (tram.Status == TramStatus.Idle)
                    {
                        BeheerTram beheerTram;
                        beheerTram = tram == null ? null : BeheerTram.ToBeheerTram(tram);
                        beheerTram.EditTramStatus(TramStatus.Idle);
                        repo.EditTram(tram);
                    }
                    else
                    {
                        BeheerTram beheerTram;
                        beheerTram = tram == null ? null : BeheerTram.ToBeheerTram(tram);
                        beheerTram.EditTramStatus(TramStatus.Defect);
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
