using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    class InUitRitTram : Tram
    {
        Logic Logic;

        public InUitRitTram(int number, Logic logic, TramStatus status, int line, User driver, Model model) : base(number, status, line, driver, model)
        {
            Logic = logic;
        }

        public void EditTramStatus(TramStatus tramstatus)
        {
            Status = tramstatus;
        }

        public void AddRepair(string defect)
        {
            Repair repair;
            repair = new Repair(Number, defect);
            Logic._databaseConnector.AddRepair(repair);
        }

        public void AddCleaning()
        {
            Cleaning cleaning;
            cleaning = new Cleaning(Number);
            Logic._databaseConnector.AddCleaning(cleaning);
        }
    }
}
