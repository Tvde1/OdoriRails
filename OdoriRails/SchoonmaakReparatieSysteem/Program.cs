using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;
using OdoriRails.DAL.Repository;

namespace SchoonmaakReparatieSysteem
{
    static class Program
    {
        private static readonly bool _gebruikInlogSysteem = true;
        private static SchoonmaakReparatieRepository _repo = new SchoonmaakReparatieRepository();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            User user;

            args = new[] {"HeadEngineer"};


            if (_gebruikInlogSysteem)
            {
                if (args.Length < 1)
                {
                    MessageBox.Show(@"Zorg dat je inlogt via de inlogapplicatie.");
                    return;
                }
                user = _repo.GetUser(args[0]);
            }
            else
            {
                //Haal hier de user op:
                user = _repo.GetUser("HeadEngineer");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }

            new MainService(user).ShowDialog();
        }
    }
}