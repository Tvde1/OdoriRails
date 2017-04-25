using System;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace In_Uitrit_Systeem
{
    public class InUitrijRepository
    {
        private static readonly IUserContext UserContext = new UserContext();
        private static readonly IServiceContext ServiceContext = new ServiceContext();
        private static readonly ITramContext TramContext = new TramContext();

        /// <summary>
        /// Voegt een Schoonmaak toe en geeft de schoonmaak met ID terug.
        /// </summary>
        /// <param name="cleaning"></param>
        /// <returns></returns>
        public Cleaning AddCleaning(Cleaning cleaning)
        {
            return ServiceContext.AddCleaning(cleaning);
        }

        /// <summary>
        /// Voegt een Repair toe en geeft de repair met ID terug.
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        public Repair AddRepair(Repair repair)
        {
            return ServiceContext.AddRepair(repair);
        }

        /// <summary>
        /// Get de user ID via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public User GetUser(string username)
        {
            return UserContext.GetUser(username);
        }

        /// <summary>
        /// Haal de tram op waar deze meneer in rijdt.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public Tram GetTramByDriver(User driver)
        {
            return TramContext.GetTramByDriver(driver);
        }

        /// <summary>
        /// Haal de sector op waar deze tram op staat.
        /// </summary>
        /// <param name="tram"></param>
        /// <returns></returns>
        public Sector GetAssignedSector(Tram tram)
        {
            return TramContext.GetAssignedSector(tram);
        }

        /// <summary>
        /// Edit tram.
        /// </summary>
        /// <param name="tram"></param>
        public void EditTram(Tram tram)
        {
            TramContext.EditTram(tram);
        }

        public Tram FetchTram(Tram tram)
        {
            return TramContext.FetchTram(tram);
        }
    }
}
