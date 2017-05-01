using System;
using System.Collections.Generic;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL.Subclasses
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
        /// </summary>
        /// Delete de service van de database.
        /// <param name="service"></param>
        void DeleteService(Service service);

        Cleaning AddCleaning(Cleaning cleaning);

        Repair AddRepair(Repair repair);

        List<Repair> GetAllRepairsFromTram(Tram tram);

        List<Cleaning> GetAllCleaningsFromTram(Tram tram);

        bool HadBigMaintenance(Tram tram);

        bool HadSmallMaintenance(Tram tram);

        /// <summary>
        /// Returnt een int[] met Repairs,Queries
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        int[] RepairsForDate(DateTime day);

        /// <summary>
        /// Returnt een int[] met bigclean, smallclean
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        int[] CleansForDate(DateTime day);
    }
}
