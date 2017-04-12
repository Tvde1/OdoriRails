using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails;

namespace In_Uitrit_Systeem
{
    class InUitRitTram : Tram
    {
        public InUitRitTram(int number, TramStatus status, int line, User driver, Model model) : base(number, status, line, driver, model)
        {
            
        }

        public void EditTramStatus(TramStatus tramstatus)
        {
            Status = tramstatus;
        }

        
    }
}
