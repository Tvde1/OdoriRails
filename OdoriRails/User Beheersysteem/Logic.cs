using OdoriRails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Beheersysteem
{
    class Logic
    {
        IDatabaseConnector databaseConnector = new MySqlContext();
        public List<BeheerUser> UsersAll = new List<BeheerUser>();
        public List<BeheerUser> UsersSearch = new List<BeheerUser>();

        public void GetAllUsersFromDatabase()
        {
            UsersAll.Clear();
            List<User> TempUsers = databaseConnector.GetAllUsers();
            foreach (User TempUser in TempUsers)
            {
                UsersAll.Add(new BeheerUser(TempUser.Id, TempUser.Name, TempUser.Username, TempUser.Email, TempUser.Password, TempUser.Role, TempUser.ManagerUsername));
            }
        }

        public void GetSelectUsersFromDatabase(SearchRole role)
        {
            UsersSearch.Clear();

            List<User> TempUsers = null;

            switch (role)
            {
                case SearchRole.All:
                    TempUsers = databaseConnector.GetAllUsers();
                    break;
                case SearchRole.Administrator:
                    TempUsers = databaseConnector.GetAllUsersWithRole(Role.Administrator);
                    break;
                case SearchRole.Cleaner:
                    TempUsers = databaseConnector.GetAllUsersWithRole(Role.Cleaner);
                    break;
                case SearchRole.Driver:
                    TempUsers = databaseConnector.GetAllUsersWithRole(Role.Driver);
                    break;
                case SearchRole.Engineer:
                    TempUsers = databaseConnector.GetAllUsersWithRole(Role.Engineer);
                    break;
                case SearchRole.Logistic:
                    TempUsers = databaseConnector.GetAllUsersWithRole(Role.Logistic);
                    break;
            }

            foreach (User TempUser in TempUsers)
            {
                UsersSearch.Add(new BeheerUser(TempUser.Id, TempUser.Name, TempUser.Username, TempUser.Email, TempUser.Password, TempUser.Role, TempUser.ManagerUsername));
            }
        }


        public void DeleteUser(int delIndex)
        {
            databaseConnector.RemoveUser(UsersSearch[delIndex]);
        }

        public void UpdateUser(User user)
        {
            databaseConnector.UpdateUser(user);
        }

        public void AddUser(User user)
        {
            databaseConnector.AddUser(user);
        }


    }
}
