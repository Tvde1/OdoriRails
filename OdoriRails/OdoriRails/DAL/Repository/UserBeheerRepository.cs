using System.Collections.Generic;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace OdoriRails.DAL.Repository
{
    class UserBeheerRepository
    {
        private readonly IUserContext _userContext = new UserContext();

        /// <summary>
        /// Voegt een User toe aan de database.
        /// </summary>
        /// <param name="user"></param>
        User AddUser(User user)
        {
            return _userContext.AddUser(user);
        }

        /// <summary>
        /// Haalt alle users op.
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers()
        {
            return _userContext.GetAllUsers();
        }

        /// <summary>
        /// Verwijdert een User uit de database.
        /// </summary>
        /// <param name="user"></param>
        void RemoveUser(User user)
        {
            _userContext.RemoveUser(user);
        }

        /// <summary>
        /// Haal een User op aan de hand van de userid.
        /// </summary>
        /// <param name="id"></param>
        User GetUser(int id)
        {
            return _userContext.GetUser(id);
        }

        /// <summary>
        /// Get de user ID via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int GetUserId(string username)
        {
            return _userContext.GetUserId(username);
        }

        /// <summary>
        /// Slaat de bestaande user op in de database.
        /// </summary>
        /// <param name="user"></param>
        void UpdateUser(User user)
        {
            _userContext.UpdateUser(user);
        }

        /// <summary>
        /// Haal een User op aan de hand van de username.
        /// </summary>
        /// <param name="userName"></param>
        User GetUser(string userName)
        {
            return _userContext.GetUser(userName);
        }

        /// <summary>
        /// Haalt alle users op die deze rol hebben.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        List<User> GetAllUsersWithRole(Role role)
        {
            return _userContext.GetAllUsersWithFunction(role);
        }
    }
}
