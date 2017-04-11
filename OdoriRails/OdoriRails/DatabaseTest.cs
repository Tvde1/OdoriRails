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
