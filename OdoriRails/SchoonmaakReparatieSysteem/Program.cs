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
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IDatabaseConnector dbconnector = new MssqlDatabaseContext();
            User user =  dbconnector.GetUser(4);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainService(user));
        }
    }
}
