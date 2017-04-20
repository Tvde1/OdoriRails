using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using In_Uitrit_Systeem;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;
using User_Beheersysteem;

namespace In_Uitrit_Systeem
{
    static class Program
    {
        private static readonly IInUitrijDatabaseAdapter _databaseConnector = new MssqlDatabaseContext();
        private static readonly bool _gebruikInlogSysteem = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            User user = null;

            if (_gebruikInlogSysteem)
            {
                if (args.Length < 1)
                {
                    MessageBox.Show(@"Zorg dat je inlogt via de inlogapllicatie.");
                    return;
                }
                user = _databaseConnector.GetUser(args[0]);

            }
            else
            {
                //Haal hier de user op:
                user = _databaseConnector.GetUser("admin");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }


            new UserInterface(user).ShowDialog();
        }
    }
}
