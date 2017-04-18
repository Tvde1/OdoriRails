using Beheersysteem.DAL;
using Beheersysteem.ObjectClasses;
using OdoriRails.DAL;
using OdoriRails.BaseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            sorter = new SortingAlgoritm();
        }

        public void GetTime(Tram tram)
        {
            foreach (InUitRijSchema entry in schema)
            {
                if (tram.Line == entry.Line)
                {
                    if (entry.wagenNr == null)
                    {
                        entry.wagenNr = tram.Number;
                        SortTram(tram);
                    }
                }
            }
        }

        public void SortTram(Tram tram)
        {
            if (sorter.GetSector(tram, database.GetTracksAndSectors(), schema) == null)
            {
                System.Windows.Forms.MessageBox.Show("Het systeem kan geen passende plek vinden voor deze tram. Plaats deze tram manueel.");
            }
        }
    }
}
