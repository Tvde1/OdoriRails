using Beheersysteem.DAL;
using Beheersysteem.ObjectClasses;
using OdoriRails.DAL;
using OdoriRails.BaseClasses;
using System.Collections.Generic;
using System;

namespace Beheersysteem
{
    class Logic
    {
        ICSVContext csv;
        ILogisticDatabaseAdapter database = new MssqlDatabaseContext();
        SortingAlgoritm sorter;
        List<InUitRijSchema> schema;
        List<Tram> allTrams;
        List<Tram> enteringTrams;
        private List<Track> _allTracks = new List<Track>();

        public List<Track> AllTracks => _allTracks;

        /// <summary>
        /// Constructor: Voert alles uit dat bij de launch uitgevoerd moet worden.
        /// </summary>
        public Logic()
        {
            _allTracks = database.GetTracksAndSectors();
        }


        public void GetSchema()
        {
            csv = new CSVContext();
            schema = csv.getSchema();
            database = new MssqlDatabaseContext();
            sorter = new SortingAlgoritm(AllTracks);
            allTrams = database.GetAllTrams();
        }

        public void SortAllEnteringTrams()
        {
            enteringTrams = database.GetAllTramsWithlocation(TramLocation.ComingIn);
            foreach (Tram tram in enteringTrams)
            {
                //Vgm niet nodig maar toch voor de zekerheid nog even laten staan
                //if (tram.DepartureTime == null)
                //{
                //    GetExitTime(tram);
                //}
                SortTram(tram);
            }
        }

        public void WipeDepartureTimes()
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
            if (sorter.GetSector(tram, GetExitTime(tram)) == null)
            {
                System.Windows.Forms.MessageBox.Show("Het systeem kan geen passende plek vinden voor deze tram. Plaats deze tram manueel.");
            }
        }

        public void Simulation()
        {
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
                            entry.TramNumber = tram.Number;

                            tram.EditTramDepartureTime(entry.ExitTime);
                            continue;
                        }
                    }

                }
            }

            //Het schema afgaan voor de simulatie
            foreach (InUitRijSchema entry in schema)
            {
                Tram tram = allTrams.Find(x => x.Number == entry.TramNumber);
                SortTram(tram);
            }

        }
    }
}
