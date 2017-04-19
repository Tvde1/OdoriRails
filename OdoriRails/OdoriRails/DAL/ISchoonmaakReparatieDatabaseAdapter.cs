using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    interface ISchoonmaakReparatieDatabaseAdapter
    {
        /// <summary>
        /// Haal alle services op (reparatie en schoonmaak) die deze user hebben.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Service> GetAllServicesFromUser(User user);

        /// <summary>
        /// Haalt een lijst op van repairs zonder users.
        /// </summary>
        /// <returns></returns>
        List<Repair> GetAllRepairsWithoutUsers();

        /// <summary>
        /// Haalt een lijst op van cleanings zonder users.
        /// </summary>
        /// <returns></returns>
        List<Cleaning> GetAllCleansWithoutUsers();
        
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

        /// <summary>
        /// Verweider een service uit de database.
        /// </summary>
        /// <param name="service"></param>
        void DeleteService(Service service);
    }
}
