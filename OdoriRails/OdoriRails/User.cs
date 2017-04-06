using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    public enum Role
    {
        Administrator,
        Logistic,
        Driver,
        Cleaner,
        Engineer
    }

    public class User
    {
        public string Name { get; protected set; }
        public string Email { get; protected set; }
        public Role Role { get; protected set; }
        public string Username { get; protected set; }
        public string Password { get; protected set; }
        public string ManagerUsername { get; protected set; }

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
