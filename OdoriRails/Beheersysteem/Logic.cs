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
        IDatabaseConnector database;
        SortingAlgoritm sorter;
        List<InUitRijSchema> schema;
        List<Tram> allTrams;
        List<Tram> enteringTrams;


        public void GetSchema()
        {
            csv = new CSVContext();
            schema = csv.getSchema();
            database = new MssqlDatabaseContext();
            sorter = new SortingAlgoritm(database.GetTracksAndSectors());
            allTrams = database.GetAllTrams();
        }

        public void SortAllEnteringTrams()
        {
            //TODO: Pas in master de query aan/
            enteringTrams = database.GetAllTramsWithlocation(TramLocation.ComingIn);
            foreach (Tram tram in enteringTrams)
            {
                if (tram.DepartureTime == null)
                {
                    GetExitTime(tram);
                }
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
                if (tram.Line == entry.Line)
                {
                    if (entry.TramNumber == null)
                    {
                        entry.TramNumber = tram.Number;
                        return entry.ExitTime;
                    }
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
