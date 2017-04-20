using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace In_Uitrit_Systeem
{
    static class Program
    {
        private static readonly IInUitrijDatabaseAdapter _databaseConnector = new MssqlDatabaseContext();
        private static readonly bool _gebruikInlogSysteem = true;

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


            Application.Run(new FormUserInterface(user));
        }
    }
}
