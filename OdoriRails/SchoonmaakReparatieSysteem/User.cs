using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoonmaakReparatieSysteem
{
    public class User
    {
<<<<<<< HEAD
        private string userName;
        private bool isAdmin = true;
        private string role;

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }

            set
            {
                isAdmin = value;
            }
        }

        private void checkLogin()
        {
            // checks role of logged in user and brings out correct GUI
        }
        public User(string username, string rol)
        {
            userName = username;
            Role = rol;
        }
=======
>>>>>>> cf1466da50b22f825ea10f8ee70f5551e5271063
    }
}
