using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.DAL;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public class Logic
    {
        public InUitRitTram Tram { get; private set; }

        private IDatabaseConnector _databaseConnector;

        public Logic(User driver)
        {
            _databaseConnector = new MssqlDatabaseContext();
            Tram = (InUitRitTram)_databaseConnector.GetTramByDriver(driver);
        }

        public void AddRepair(string defect)
        {
            Repair repair = new Repair(Tram.Number, defect);
            _databaseConnector.AddRepair(repair);
        }

        public void AddCleaning()
        {
            Cleaning cleaning = new Cleaning(Tram.Number);
            _databaseConnector.AddCleaning(cleaning);
        }
    }
}
