using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace OdoriRails.DAL.Repository
{
    class InUitrijRepository
    {
        private readonly IUserContext _userContext = new UserContext();
        private readonly IServiceContext _serviceContext = new ServiceContext();
        private readonly ITramContext _tramContext = new TramContext();

        /// <summary>
        /// Voegt een Schoonmaak toe en geeft de schoonmaak met ID terug.
        /// </summary>
        /// <param name="cleaning"></param>
        /// <returns></returns>
        Cleaning AddCleaning(Cleaning cleaning)
        {
            return _serviceContext.AddCleaning(cleaning);
        }

        /// <summary>
        /// Voegt een Repair toe en geeft de repair met ID terug.
        /// </summary>
        /// <param name="repair"></param>
        /// <returns></returns>
        Repair AddRepair(Repair repair)
        {
            return _serviceContext.AddRepair(repair);
        }

        /// <summary>
        /// Get de user ID via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        User GetUser(string username)
        {
            return _userContext.GetUser(username);
        }

        /// <summary>
        /// Haal de tram op waar deze meneer in rijdt.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        Tram GetTramByDriver(User driver)
        {
            return _tramContext.GetTramByDriver(driver);
        }
    }
}
