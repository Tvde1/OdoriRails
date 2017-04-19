using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    public interface IBeheerDatabaseAdapter
    {

        /// <summary>
        /// Voegt een User toe aan de database.
        /// </summary>
        /// <param name="user"></param>
        User AddUser(User user);

        /// <summary>
        /// Haalt alle users op.
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Verwijdert een User uit de database.
        /// </summary>
        /// <param name="user"></param>
        void RemoveUser(User user);

        /// <summary>
        /// Haal een User op aan de hand van de userid.
        /// </summary>
        /// <param name="id"></param>
        User GetUser(int id);

        /// <summary>
        /// Get de user ID via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int GetUserId(string username);

        /// <summary>
        /// Slaat de bestaande user op in de database.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user);

        /// <summary>
        /// Haal een User op aan de hand van de username.
        /// </summary>
        /// <param name="userName"></param>
        User GetUser(string userName);

        /// <summary>
        /// Haalt alle users op die deze rol hebben.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        List<User> GetAllUsersWithRole(Role role);
    }
}
