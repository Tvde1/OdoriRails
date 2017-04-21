using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace User_Beheersysteem
{
    static class Program
    {
        private static readonly bool _gebruikInlogSysteem = true;
        private static readonly IUserContext UserContext = new UserContext();

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
                    MessageBox.Show(@"Log eerst in via de Inlog app.");
                    return;
                }
                user = UserContext.GetUser(args[0]);

            }
            else
            {
                //Haal hier de user op:
                user = UserContext.GetUser("admin");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }


            new UserInterface(user).ShowDialog();
        }
    }
}
