using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails;

namespace In_Uitrit_Systeem
{
    class InUitRitUser : User
    {
        public string UserName { get; private set; }

        public InUitRitUser(string username, string name, string email, Role role): base(name, email, role)
        {
            username = UserName;
        }
    }
}
