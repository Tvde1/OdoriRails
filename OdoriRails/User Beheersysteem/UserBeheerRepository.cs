using System.Collections.Generic;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace User_Beheersysteem
{
    public class UserBeheerRepository
    {
        private static readonly IUserContext UserContext = new UserContext();
        private static readonly ITramContext TramContext = new TramContext();
        private static readonly ILoginContext LoginContext = new LoginContext();

        /// <summary>
        /// Voegt een User toe aan de database.
        /// </summary>
        /// <param name="user"></param>
        public User AddUser(User user)
        {
            return UserContext.AddUser(user);
        }

        /// <summary>
        /// Haalt alle users op.
        /// </summary>
        /// <returns></returns>
        public List<User> GetAllUsers()
        {
            return UserContext.GetAllUsers();
        }

        /// <summary>
        /// Verwijdert een User uit de database.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            UserContext.RemoveUser(user);
        }

        /// <summary>
        /// Haal een User op aan de hand van de userid.
        /// </summary>
        /// <param name="id"></param>
        public User GetUser(int id)
        {
            return UserContext.GetUser(id);
        }

        /// <summary>
        /// Get de user ID via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserId(string username)
        {
            return UserContext.GetUserId(username);
        }

        /// <summary>
        /// Slaat de bestaande user op in de database.
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUser(User user)
        {
            UserContext.UpdateUser(user);
        }

        /// <summary>
        /// Haal een User op aan de hand van de username.
        /// </summary>
        /// <param name="userName"></param>
        public User GetUser(string userName)
        {
            return UserContext.GetUser(userName);
        }

        /// <summary>
        /// Haalt alle users op die deze rol hebben.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<User> GetAllUsersWithFunction(Role role)
        {
            return UserContext.GetAllUsersWithFunction(role);
        }

        public bool DoesTramExist(int id)
        {
            return TramContext.DoesTramExist(id);
        }

        public List<int> GetTramIdByDriverId(int id)
        {
            return TramContext.GetTramIdByDriverId(id);
        }

        public void SetUserToTram(User user, int? tramId)
        {
            if (tramId != null && DoesTramExist((int)tramId)) TramContext.SetUserToTram(TramContext.GetTram((int)tramId), user);
            else TramContext.SetUserToTram(null, user);
        }

        /// <summary>
        /// Returns true if there already is an user with such name.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool DoesUserExist(string userName)
        {
            return LoginContext.ValidateUsername(userName);
        }
    }
}
