using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace In_Uitrit_Systeem
{
    static class Program
    {
        private static readonly bool _gebruikInlogSysteem = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            User user;
            args = new string[1] {"driver"}; // for testing so we dont have to use the login everytime

            if (_gebruikInlogSysteem)
            {
                if (args.Length < 1)
                {
                    MessageBox.Show(@"Log eerst in via de Inlog app.");
                    return;
                }
                user = Database.GetUser(args[0]);
            }
            else
            {
                //Haal hier de user op:
                user = Database.GetUser("driver");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }


            new FormUserInterface(user).ShowDialog();
        }
    }
}
