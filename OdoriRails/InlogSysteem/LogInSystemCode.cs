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
            StartProgram(_databaseConnector.GetUser(username).Role);
        }

        private void StartProgram(Role role)
        {
            Assembly assembly = Assembly.LoadFrom(_dataLocation + Enum.GetName(typeof(Role), role) + ".dll");
            Type type = assembly.GetType(Enum.GetName(typeof(Role), role));
            type.GetMethod("Main").Invoke(null, null);
        }
    }
}