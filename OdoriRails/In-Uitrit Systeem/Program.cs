using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using In_Uitrit_Systeem;
using OdoriRails.DAL;

namespace In_Uitrit_Systeem
{
    static class Program
    {
        static readonly IDatabaseConnector _databaseConnector = new MssqlDatabaseContext();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length < 1) args = new string[1] { "admin" };
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormUserInterface(_databaseConnector.GetUser(args[0])));
        }
    }
}
