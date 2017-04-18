using System.Linq;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace OdoriRails
{
    internal static class DatabaseTest
    {
        public static void OnLoad()
        {
            MessageBox.Show(GetAdminName());
        }

        private static string GetAdminName()
        {
            IDatabaseConnector databaseConnector = new MySqlContext();
            //var admin = databaseConnector.GetUser("admin");

            //User user = new User(4, "Mark Rutte", "markiee1", "mark@hotmail.com", "ikwordgeilvanwilders", Role.Logistic, "admin");
            //return databaseConnector.AddUser(user).ToString();

            var users = databaseConnector.GetAllUsers();
            // ReSharper disable once UnusedVariable
            var schoonmakersTest = users.Where(x => x.Role == Role.Cleaner).ToList();

            return null;
        }
    }
}