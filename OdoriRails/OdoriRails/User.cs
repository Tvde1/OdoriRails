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
        /// <summary>
        /// Database ID van de User.
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Ophalen naam van User
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Ophalen emailadres van User
        /// </summary>
        public string Email { get; protected set; }

        /// <summary>
        /// Ophalen rol van User
        /// </summary>
        public Role Role { get; protected set; }

        /// <summary>
        /// Ophalen username van User
        /// </summary>
        public string Username { get; protected set; }

        /// <summary>
        /// Ophalen password van User
        /// </summary>
        public string Password { get; protected set; }

        /// <summary>
        /// Ophalen manager van User
        /// </summary>
        public string ManagerUsername { get; protected set; }

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
        public User(int id, string name, string username, string email, string password, Role role, string managedByUsername)
        {
            ID = id;
            Name = name;
            Email = email;
            Role = role;
            Username = username;
            Password = password;
            ManagerUsername = managedByUsername;
        }
    }
}
