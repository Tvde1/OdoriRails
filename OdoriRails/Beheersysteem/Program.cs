using System;
using System.Windows.Forms;

namespace Beheersysteem
{
    static class Program
    {
        private static readonly bool UseLoginSystem = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (!UseLoginSystem)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
            }
            new UserInterface().ShowDialog();
        }
    }
}
