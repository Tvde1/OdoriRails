using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace SchoonmaakReparatieSysteem
{
    static class Program
    {
        private static readonly ISchoonmaakReparatieDatabaseAdapter _databaseConnector = new MssqlDatabaseContext();
        private static readonly bool _gebruikInlogSysteem = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            User user;

            if (_gebruikInlogSysteem)
            {
                if (args.Length < 1)
                {
                    MessageBox.Show(@"Zorg dat je inlogt via de inlogapplicatie.");
                    return;
                }
                user = _databaseConnector.GetUser(args[0]);
            }
            else
            {
                //Haal hier de user op:
                user = _databaseConnector.GetUser("HeadEngineer");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }

            new MainService(user).ShowDialog();
        }
    }
}