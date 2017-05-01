using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace LoginSystem
{
    public class LoginRepository
    {
        private static readonly ILoginContext LoginContext = new LoginContext();
        private static readonly IUserContext UserContext = new UserContext();

        /// <summary>
        /// Kijkt of de username bestaat in de database.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool ValidateUsername(string username)
        {
            return LoginContext.ValidateUsername(username);
        }

        /// <summary>
        /// Een bool om de gebruikersnaam en wachtwoord te controleren.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool MatchUsernameAndPassword(string username, string password)
        {
            return LoginContext.MatchUsernameAndPassword(username, password);
        }

        /// <summary>
        /// Gets user by username.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public User GetUser(string userName)
        {
            return UserContext.GetUser(userName);
        }
    }
}
