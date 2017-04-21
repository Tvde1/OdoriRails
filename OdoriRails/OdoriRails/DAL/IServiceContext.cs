using System.Collections.Generic;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    public interface IServiceContext
    {
        List<Repair> GetAllRepairsFromUser(User user);

        List<Cleaning> GetAllCleansFromUser(User user);

        List<Repair> GetAllRepairsWithoutUsers();

        List<Cleaning> GetAllCleansWithoutUsers();

        /// <summary>
        /// Edit de service in de database.
        /// </summary>
        /// <param name="service"></param>
        void EditService(Service service);

        /// <summary>
        /// Delete de service van de database.
        /// </summary>
        /// <param name="service"></param>
        void DeleteService(Service service);

        Cleaning AddCleaning(Cleaning cleaning);

        Repair AddRepair(Repair repair);
    }
}
