using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    public enum Role
    {
        Cleaner,
        Admin,
        Homeless
    }

    public class User
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Role Role { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string ManagerUsername { get; private set; }

        public User(string name, string email, Role role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        public User (string name, string username, string email, string password, Role role, string managedByUsername)
        {
            Name = name;
            Email = email;
            Role = role;
            Username = username;
            Password = password;
            ManagerUsername = managedByUsername;
        }
    }
}
