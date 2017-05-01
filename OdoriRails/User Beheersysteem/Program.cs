using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace User_Beheersysteem
{
    static class Program
    {
        private static readonly bool _gebruikInlogSysteem = true;
        private static readonly UserBeheerRepository UserBeheerRepository = new UserBeheerRepository();

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
                user = UserBeheerRepository.GetUser(args[0]);

            }
            else
            {
                //Haal hier de user op:
                user = UserBeheerRepository.GetUser("Admin");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }

            new UserInterface(user).ShowDialog();
        }
    }
}
