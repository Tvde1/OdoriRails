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

        Cleaning AddCleaning(Cleaning cleaning);

        Repair AddRepair(Repair repair);
    }
}
