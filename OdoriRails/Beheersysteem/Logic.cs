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
        ICSVContext csv = new CSVContext();
        MssqlDatabaseContext database;
        SortingAlgoritm sorter;
        List<InUitRijSchema> schema;

        public void GetSchema()
        {
            schema = csv.getSchema();
            database = new MssqlDatabaseContext();
        }

        public void SortTram(BeheerTram tram)
        {
            sorter = new SortingAlgoritm();
            if (sorter.GetSector(tram, database.GetTracksAndSectors(), schema) == null)
            {
                System.Windows.Forms.MessageBox.Show("Het systeem kan geen passende plek vinden voor deze tram. Plaats deze tram manueel.");
            }
        }
    }
}
