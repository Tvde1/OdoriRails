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
        MssqlDatabaseContext database;
        SortingAlgoritm sorter;
        List<InUitRijSchema> schema;

        public void GetSchema()
        {
            csv = new CSVContext();
            schema = csv.getSchema();
            database = new MssqlDatabaseContext();
            sorter = new SortingAlgoritm(database.GetTracksAndSectors());
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
    }
}
