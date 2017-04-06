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
        /// <summary>
        /// Ophalen naam van User
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Ophalen emailadres van User
        /// </summary>
        public string Email { get; private set; }

        /// <summary>
        /// Ophalen rol van User
        /// </summary>
        public Role Role { get; private set; }

        /// <summary>
        /// Ophalen username van User
        /// </summary>
        public string Username { get; private set; }

        /// <summary>
        /// Ophalen password van User
        /// </summary>
        public string Password { get; private set; }

        /// <summary>
        /// Ophalen manager van User
        /// </summary>
        public string ManagerUsername { get; private set; }

        /// <summary>
        /// Toevoegen User, minimale hoeveelheid benodigde data.
        /// </summary>
        public User(string name, string email, Role role)
        {
            Name = name;
            Email = email;
            Role = role;
        }

        /// <summary>
        /// Toevoegen User, alle benodigde data.
        /// </summary>
        public User (string name, string email, Role role, string username, string password, string managedByUsername)
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
