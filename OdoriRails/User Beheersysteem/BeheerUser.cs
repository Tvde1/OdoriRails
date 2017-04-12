using OdoriRails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Beheersysteem
{
    class BeheerUser : User
    {
        public BeheerUser(int id, string name, string username, string email, string password, Role role, string managedByUsername) : base(id, name, username, email, password, role, managedByUsername)
        { }

        public string ToString(bool manager)
        {
            if (manager == false)
            {
                return Name;
            }
            else
            {
                return Username;
            }

        }
    }
}
