using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails;

namespace In_Uitrit_Systeem
{
    public class Logic
    {
        public IDatabaseConnector _databaseConnector { get; private set; }

        public Logic()
        {
            _databaseConnector = new MySqlContext();
        }
    }
}
