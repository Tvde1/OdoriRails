using System;
using System.IO;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Permissions;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;
using System.Windows.Forms;

namespace LoginSystem
{
    internal class LogInSystemCode
    {
        private readonly IUserContext _userContext = new UserContext();
        private readonly ILoginContext _loginDatabaseConnector = new LoginContext();
        private readonly string _dataLocation = Application.StartupPath + @"\Systems\";

        public void Login(string username, string password)
        {
            if (!_loginDatabaseConnector.ValidateUsername(username)) throw new AuthenticationException("Gebruiker bestaat niet.");
            if (!_loginDatabaseConnector.MatchUsernameAndPassword(username, password)) throw new AuthenticationException("De gebruikersnaam en wachtwoord komen niet overeen.");
            StartProgram(_userContext.GetUser(username));
        }

        private void StartProgram(User user)
        {

            string assemblyName = "";
            switch (user.Role)
            {
                case Role.Administrator:
                    assemblyName = "UserBeheersysteem.dll";
                    break;
                case Role.Logistic:
                    assemblyName = "LogistiekSysteem.dll";
                    break;
                case Role.Driver:
                    assemblyName = "InUitritSysteem.dll";
                    break;
                case Role.Cleaner:
                    assemblyName = "SchoonmaakReparatieSysteem.dll";
                    break;
                case Role.HeadCleaner:
                    assemblyName = "SchoonmaakReparatieSysteem.dll";
                    break;
                case Role.Engineer:
                    assemblyName = "SchoonmaakReparatieSysteem.dll";
                    break;
                case Role.HeadEngineer:
                    assemblyName = "SchoonmaakReparatieSysteem.dll";
                    break;
            }

            Assembly assembly;

            try
            {
                assembly = Assembly.LoadFrom(Path.Combine(_dataLocation, assemblyName));
            }
            catch (Exception)
            {
                throw new Exception($"Het bestand {assemblyName} kan niet gevonden worden.");
            }

            MethodInfo target = assembly.EntryPoint;
            (new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)).Assert();
            var args = new[] {user.Username};
            target.Invoke(null, new object[] {args});
        }
    }
}