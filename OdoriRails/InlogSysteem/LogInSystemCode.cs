using System;
using System.Reflection;
using System.Security.Authentication;
using OdoriRails;

namespace LoginSystem
{
    internal class LogInSystemCode
    {
        private readonly IDatabaseConnector _databaseConnector = new MySqlContext();
        //Dit moet later MssqlDatabaseContext worden.
        private readonly string _dataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\OdoriRails\";

        public void Login(string username, string password)
        {
            if (!_databaseConnector.ValidateUsername(username)) throw new AuthenticationException("Gebruiker bestaat niet.");
            if (!_databaseConnector.MatchUsernameAndPassword(username, password)) throw new AuthenticationException("De gebruikersnaam en wachtwoord komen niet overeen.");
            StartProgram(_databaseConnector.GetUser(username));
        }

        private void StartProgram(User user)
        {
            Assembly assembly = Assembly.LoadFrom(_dataLocation + Enum.GetName(typeof(Role), user.Role) + ".dll");
            Type type = assembly.GetType(Enum.GetName(typeof(Role), user.Role));
            switch (user.Role)
            {
                    case Role.HeadEngineer
            }
            type.GetMethod("Main").Invoke(user, null);
        }
    }
}