﻿using System;
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
        private static ILoginContext _loginContext = new LoginContext();
        private static readonly bool _gebruikInlogSysteem = false;

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
                user = Database.GetUser(args[0]);
            }
            else
            {
                //Haal hier de user op:
                user = Database.GetUser("HeadEngineer");
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }

            new MainService(user).ShowDialog();
        }
    }
}