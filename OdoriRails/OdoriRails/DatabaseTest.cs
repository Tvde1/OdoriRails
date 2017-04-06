using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OdoriRails
{
    class DatabaseTest
    {
        public static void OnLoad()
        {
            MessageBox.Show(GetAdminName());
        }

        private static string GetAdminName()
        {
            IDatabaseConnector databaseConnector = new MySqlContext();
            var admin = databaseConnector.GetUser("admin");
            return admin.Name;
        }
    }
}
