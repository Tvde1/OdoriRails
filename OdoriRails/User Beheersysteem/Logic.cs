using OdoriRails.BaseClasses;
using OdoriRails.DAL;
using System.Collections.Generic;

namespace User_Beheersysteem
{
    class Logic
    {
        private IUserContext _userContext = new UserContext();
        public List<BeheerUser> UsersSearch { get; set; } = new List<BeheerUser>();
        public List<BeheerUser> UsersAll { get; set; } = new List<BeheerUser>();

        public void GetAllUsersFromDatabase()
        {
            UsersAll.Clear();
            List<User> tempUsers = _userContext.GetAllUsers();
            foreach (User tempUser in tempUsers)
            {
                UsersAll.Add(new BeheerUser(tempUser.Id, tempUser.Name, tempUser.Username, tempUser.Email, tempUser.Password, tempUser.Role, tempUser.ManagerUsername));
            }
        }

        public void GetSelectUsersFromDatabase(int index)
        {
            UsersSearch.Clear();

            var tempUsers = index == 7 ? _userContext.GetAllUsers() : _userContext.GetAllUsersWithFunction((Role)index);

            foreach (User tempUser in tempUsers)
            {
                UsersSearch.Add(new BeheerUser(tempUser.Id, tempUser.Name, tempUser.Username, tempUser.Email, tempUser.Password, tempUser.Role, tempUser.ManagerUsername));
            }
        }


        public void DeleteUser(int delIndex)
        {
            _userContext.RemoveUser(UsersSearch[delIndex]);
        }

        public void UpdateUser(User user)
        {
            _userContext.UpdateUser(user);
        }

        public void AddUser(User user)
        {
            _userContext.AddUser(user);
        }

        public int GetIndex(string username)
        {
            return _userContext.GetUserId(username);
        }
    }
}
