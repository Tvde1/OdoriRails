﻿using System;
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
        private IInUitrijDatabaseAdapter _databaseConnector = new MssqlDatabaseContext();

        public Logic(User driver)
        {
            Tram tempTram = _databaseConnector.GetTramByDriver(driver);
            Tram = InUitRitTram.ConvertToInUitRitTram(tempTram);
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