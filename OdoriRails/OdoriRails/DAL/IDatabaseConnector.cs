using System.Collections.Generic;

namespace OdoriRails
{
    public interface IDatabaseConnector
    {
        #region users
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
        #endregion

        #region trams
        /// <summary>
        /// Voegt een nieuwe tram toe aan de database.
        /// </summary>
        /// <param name="tram"></param>
        void AddTram(Tram tram);

        /// <summary>
        /// Verwijdert een Tram uit de database.
        /// </summary>
        /// <param name="tram"></param>
        void RemoveTram(Tram tram);

        /// <summary>
        /// Haal een Tram op aan de hand van de tramid.
        /// </summary>
        /// <param name="id"></param>
        Tram GetTram(int id);
        #endregion

        #region tracks and sector
        /// <summary>
        /// Haalt alle tracks, sectoren en trams op sectoren op.
        /// </summary>
        /// <returns></returns>
        List<Track> GetTracksAndSectors();

        /// <summary>
        /// Een lijst met trams die op een track staan.
        /// </summary>
        /// <returns></returns>
        List<Tram> GetAllTramsOnATrack();
        #endregion

        #region services
        /// <summary>
        /// Haal alle services op (reparatie en schoonmaak) die deze user hebben.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Service> GetAllServicesFromUser(User user);

        /// <summary>
        /// Haalt een lijst op van services zonder users.
        /// </summary>
        /// <returns></returns>
        List<Service> GetAllServicesWithoutUsers()

        /// <summary>
        /// Voegt een Schoonmaak toe en geeft de schoonmaak met ID terug.
        /// </summary>
        /// <param name="cleaning"></param>
        /// <returns></returns>
        Cleaning AddCleaning(Cleaning cleaning);

        /// <summary>
        /// Voegt een Repair toe en geeft de repair met ID terug.
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        Repair AddRepair(Repair repair);

        /// <summary>
        /// Past de service aan in de database.
        /// </summary>
        /// <param name="service"></param>
        void EditService(Service service);
        #endregion

        #region login
        /// <summary>
        /// Kijkt of de username bestaat in de database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool ValidateUsername(string username);

        /// <summary>
        /// Een bool om de gebruikersnaam en wachtwoord te controleren.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool MatchUsernameAndPassword(string username, string password);
        #endregion

        //Erbij
        /*
         * Wijzigen trams.
         * 
         * 
         */
    }
}
