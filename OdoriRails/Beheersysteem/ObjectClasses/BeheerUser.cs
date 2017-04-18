using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace Beheersysteem
{
    class BeheerUser : User
    {        
        /// <summary>
        /// Load existing user from database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <param name="managedByUsername"></param>
        public BeheerUser(int id, string name, string username, string email, string password, Role role, string managedByUsername) : base(id, name, username, email, password, role, managedByUsername)
        {

        }
    }
}
