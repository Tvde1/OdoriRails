using System;
using System.Collections.Generic;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace SchoonmaakReparatieSysteem
{
    public class SchoonmaakReparatieRepository
    {
        private static readonly IServiceContext ServiceContext = new ServiceContext();
        private static readonly IUserContext UserContext = new UserContext();
        private static readonly ITramContext TramContext = new TramContext();

        /// <summary>
        /// Haal alle reparaties op die deze user heeft.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Repair> GetAllRepairsFromUser(User user)
        {
            return ServiceContext.GetAllRepairsFromUser(user);
        }

        /// <summary>
        /// Haal alle schoonmaaks op die deze user heeft.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public List<Cleaning> GetAllCleansFromUser(User user)
        {
            return ServiceContext.GetAllCleansFromUser(user);
        }

        /// <summary>
        /// Haalt een lijst op van repairs zonder users.
        /// </summary>
        /// <returns></returns>
        public List<Repair> GetAllRepairsWithoutUsers()
        {
            return ServiceContext.GetAllRepairsWithoutUsers();
        }

        /// <summary>
        /// Haalt een lijst op van cleanings zonder users.
        /// </summary>
        /// <returns></returns>
        public List<Cleaning> GetAllCleansWithoutUsers()
        {
            return ServiceContext.GetAllCleansWithoutUsers();
        }

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
        /// Past de service aan in de database.
        /// </summary>
        /// <param name="service"></param>
        public void EditService(Service service)
        {
            ServiceContext.EditService(service);
        }

        /// <summary>
        /// Verweider een service uit de database.
        /// </summary>
        /// <param name="service"></param>
        public void DeleteService(Service service)
        {
            ServiceContext.DeleteService(service);
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

        public List<Repair> GetAllRepairsFromTram(int tramId)
        {
            return ServiceContext.GetAllRepairsFromTram(tramId);
        }

        public List<Cleaning> GetAllCleaningsFromTram(int tramId)
        {
            return ServiceContext.GetAllCleaningsFromTram(tramId);
        }

        /// <summary>
        /// Returnt een int[] met Repairs,Queries
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public int[] GetAllRepairsForDay(DateTime day)
        {
            return ServiceContext.RepairsForDate(day);
        }

        /// <summary>
        /// Returnt een int[] met bigclean, smallclean
        /// </summary>
        /// <param name="day"></param>
        /// <returns></returns>
        public int[] GetAllCleansFromDay(DateTime day)
        {
            return ServiceContext.CleansForDate(day);
        }

        public bool DoesTramExist(int id)
        {
            return TramContext.DoesTramExist(id);
        }

        /// <summary>
        /// Sets the tram's status to idle (when service is finished).
        /// </summary>
        /// <param name="tramId"></param>
        public void SetTramStatusToIdle(int tramId)
        {
            TramContext.SetStatusToIdle(tramId);
        }

        public void GetRepairsFromTram(int tramId)
        {
            ServiceContext.GetAllRepairsFromTram(tramId);
        }

        public void GetCleansFromTram(int tramId)
        {
            ServiceContext.GetAllRepairsFromTram(tramId);
        }

        public void AddSolution(Repair repair, string solution)
        {
            var newRepair = new Repair(repair.Id, repair.StartDate, (DateTime)repair.EndDate, repair.Type, repair.Defect, solution, repair.AssignedUsers, repair.TramId);
            ServiceContext.EditService(newRepair);
        }
    }
}