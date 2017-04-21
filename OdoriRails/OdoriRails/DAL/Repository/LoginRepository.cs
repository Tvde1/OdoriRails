using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace OdoriRails.DAL.Repository
{
    class LoginRepository
    {
        private readonly ILoginContext _loginContext = new LoginContext();
        private readonly IUserContext _userContext = new UserContext();

        /// <summary>
        /// Kijkt of de username bestaat in de database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        bool ValidateUsername(string username)
        {
            return _loginContext.ValidateUsername(username);
        }

        /// <summary>
        /// Een bool om de gebruikersnaam en wachtwoord te controleren.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        bool MatchUsernameAndPassword(string username, string password)
        {
            return _loginContext.MatchUsernameAndPassword(username, password);
        }

        /// <summary>
        /// Gets user by username.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        User GetUser(string userName)
        {
            return _userContext.GetUser(userName);
        }
    }
}
