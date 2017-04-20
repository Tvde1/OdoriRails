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
        private readonly ILoginDatabaseAdapter _databaseConnector = new MssqlDatabaseContext();
        private readonly string _dataLocation = Application.StartupPath + @"\Systems\";

        public void Login(string username, string password)
        {
            if (!_databaseConnector.ValidateUsername(username)) throw new AuthenticationException("Gebruiker bestaat niet.");
            if (!_databaseConnector.MatchUsernameAndPassword(username, password)) throw new AuthenticationException("De gebruikersnaam en wachtwoord komen niet overeen.");
            StartProgram(_databaseConnector.GetUser(username));
        }

        private void StartProgram(User user)
        {

            string assembly = "";
            switch (user.Role)
            {
                case Role.Administrator:
                    assembly = "UserBeheersysteem.dll";
                    break;
                case Role.Logistic:
                    assembly = "LogistiekSysteem.dll";
                    break;
                case Role.Driver:
                    assembly = "InUitritSysteem.dll";
                    break;
                case Role.Cleaner:
                    assembly = "SchoonmaakReparatieSysteem.dll";
                    break;
                case Role.HeadCleaner:
                    assembly = "SchoonmaakReparatieSysteem.dll";
                    break;
                case Role.Engineer:
                    assembly = "SchoonmaakReparatieSysteem.dll";
                    break;
                case Role.HeadEngineer:
                    assembly = "SchoonmaakReparatieSysteem.dll";
                    break;
            }

            Assembly ass = null;

            try
            {
                ass = Assembly.LoadFrom(Path.Combine(_dataLocation, assembly));
            }
            catch (Exception ex)
            {
                throw new Exception($"Het bestand {assembly} kan niet gevonden worden.");
            }

            MethodInfo target = ass.EntryPoint;
            (new ReflectionPermission(ReflectionPermissionFlag.RestrictedMemberAccess)).Assert();
            var args = new string[1] {user.Username};
            target.Invoke(null, new object[1] {args});
        }


        /*
        private void StartProgram(User user)
        {
            Assembly assembly;
            Type type;
            switch (user.Role)
            {
                case Role.HeadEngineer:
                    {
                        assembly = Assembly.LoadFrom(_dataLocation + Enum.GetName(typeof(Role), Role.Engineer) + ".dll");
                        type = assembly.GetType(Enum.GetName(typeof(Role), Role.Engineer));
                        break;
                    }
                case Role.HeadCleaner:
                    {
                        assembly = Assembly.LoadFrom(_dataLocation + Enum.GetName(typeof(Role), Role.Cleaner) + ".dll");
                        type = assembly.GetType(Enum.GetName(typeof(Role), Role.Cleaner));
                        break;
                    }
                default:
                    {
                        assembly = Assembly.LoadFrom(_dataLocation + Enum.GetName(typeof(Role), user.Role) + ".dll");
                        type = assembly.GetType(Enum.GetName(typeof(Role), user.Role));
                        break;
                    }
            }
            type.GetMethod("Main").Invoke(new object[1] { user }, null);
        }*/
    }
}