using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    public interface IInUitrijDatabaseAdapter
    {
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
        /// Get de user ID via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int GetUserId(string username);
    }
}
