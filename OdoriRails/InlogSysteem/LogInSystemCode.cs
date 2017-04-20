using System;
using System.IO;
using System.Reflection;
using System.Security.Authentication;
using System.Security.Permissions;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace LoginSystem
{
    internal class LogInSystemCode
    {
        private readonly ILoginDatabaseAdapter _databaseConnector = new MssqlDatabaseContext();
        //Dit moet later MssqlDatabaseContext worden.
        private readonly string _dataLocation = @"D:\"; //Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\OdoriRails\";

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
                    assembly = "SchoonmaakReparatieSysteem.dll";
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
            try
            {
                target.Invoke(null, new object[1] {new string[1] {user.Username}});
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}