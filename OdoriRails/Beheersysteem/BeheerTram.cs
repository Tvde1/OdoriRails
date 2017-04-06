using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails;

namespace Beheersysteem
{
    class BeheerTram: Tram
    {
        public BeheerTram(string name, string email, Role role, string username, string password, string managedByUsername) : base(name, email, role, username, password, managedByUsername)
        { }

        public BeheerTram(int number, Model model) : base(number, model)
        { }


    }
}
