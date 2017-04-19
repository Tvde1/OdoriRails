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

        public void GetSelectUsersFromDatabase(int index)
        {
            UsersSearch.Clear();

            List<User> TempUsers = null;

            if (index == 7)
            {
                TempUsers = databaseConnector.GetAllUsers();
            }
            else
            {
                TempUsers = databaseConnector.GetAllUsersWithRole((Role)index);
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

        public int GetIndex(string username)
        {
            return databaseConnector.GetUserId(username);
        }


    }
}
