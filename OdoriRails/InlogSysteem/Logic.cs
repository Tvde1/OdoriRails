using System;
using System.IO;
using System.Reflection;
using System.Security.Authentication;
using OdoriRails.BaseClasses;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace LoginSystem
{
    internal class Logic
    {
        private readonly LoginRepository _loginRepository = new LoginRepository();
        private readonly string _dataLocation = Application.StartupPath + @"\Systems\";

        public void Login(string username, string password)
        {
            if (!_loginRepository.ValidateUsername(username)) throw new AuthenticationException("Gebruiker bestaat niet.");
            if (!_loginRepository.MatchUsernameAndPassword(username, password)) throw new AuthenticationException("De gebruikersnaam en wachtwoord komen niet overeen.");
            StartProgram(_loginRepository.GetUser(username));
        }
        
        private void StartProgram(User user)
        {

            var assemblyName = "";
            switch (user.Role)
            {
                case Role.Administrator:
                    assemblyName = "UserBeheersysteem.dll";
                    break;
                case Role.Logistic:
                    assemblyName = "BeheerSysteem.dll";
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

            OpenAssembly(assembly, user);
        }

        private static async void OpenAssembly(Assembly assembly, User user)
        {
            await Task.Delay(2000);
            assembly.EntryPoint.Invoke(null, new object[] { new[] { user.Username } });
        }
    }
}