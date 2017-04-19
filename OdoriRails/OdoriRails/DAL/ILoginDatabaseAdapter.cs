namespace OdoriRails.DAL
{
    public interface ILoginDatabaseAdapter
    {
        /// <summary>
        /// Kijkt of de username bestaat in de database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool ValidateUsername(string username);

        /// <summary>
        /// Een bool om de gebruikersnaam en wachtwoord te controleren.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool MatchUsernameAndPassword(string username, string password);
    }
}