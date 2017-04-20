using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
