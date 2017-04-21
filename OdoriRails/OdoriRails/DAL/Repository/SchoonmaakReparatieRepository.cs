using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace OdoriRails.DAL.Repository
{
    class SchoonmaakReparatieRepository
    {
        private readonly IServiceContext _serviceContext = new ServiceContext();
        private readonly IUserContext _userContext = new UserContext();

        /// <summary>
        /// Haal alle reparaties op die deze user heeft.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Repair> GetAllRepairsFromUser(User user)
        {
            return _serviceContext.GetAllRepairsFromUser(user);
        }

        /// <summary>
        /// Haal alle schoonmaaks op die deze user heeft.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Cleaning> GetAllCleansFromUser(User user)
        {
            return _serviceContext.GetAllCleansFromUser(user);
        }

        /// <summary>
        /// Haalt een lijst op van repairs zonder users.
        /// </summary>
        /// <returns></returns>
        List<Repair> GetAllRepairsWithoutUsers()
        {
            return _serviceContext.GetAllRepairsWithoutUsers();
        }

        /// <summary>
        /// Haalt een lijst op van cleanings zonder users.
        /// </summary>
        /// <returns></returns>
        List<Cleaning> GetAllCleansWithoutUsers()
        {
            return _serviceContext.GetAllCleansWithoutUsers();
        }

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
        /// Past de service aan in de database.
        /// </summary>
        /// <param name="service"></param>
        void EditService(Service service)
        {
            _serviceContext.EditService(service);
        }

        /// <summary>
        /// Verweider een service uit de database.
        /// </summary>
        /// <param name="service"></param>
        void DeleteService(Service service)
        {
            _serviceContext.DeleteService(service);
        }

        /// <summary>
        /// Haal een User op aan de hand van de username.
        /// </summary>
        /// <param name="userName"></param>
        User GetUser(string userName)
        {
            return _userContext.GetUser(userName);
        }

        /// <summary>
        /// Haalt alle users op die deze rol hebben.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        List<User> GetAllUsersWithFunction(Role role)
        {
            return _userContext.GetAllUsersWithFunction(role);
        }
    }
}
