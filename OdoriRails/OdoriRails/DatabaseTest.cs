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
            //var admin = databaseConnector.GetUser("admin");

            //User user = new User(4, "Mark Rutte", "markiee1", "mark@hotmail.com", "ikwordgeilvanwilders", Role.Logistic, "admin");
            //return databaseConnector.AddUser(user).ToString();

            var users = databaseConnector.GetAllUsers();
            var user = users[2];

            MessageBox.Show(user.Email);

            //user.Email = "new-email";
            databaseConnector.UpdateUser(user);

            var user2 = databaseConnector.GetUser(user.Id);
            MessageBox.Show(user2.Email);

            return null;
        }
    }
}
