using OdoriRails.BaseClasses;
using System.Collections.Generic;

namespace User_Beheersysteem
{
    class Logic
    {
        private readonly UserBeheerRepository _userBeheerRepository = new UserBeheerRepository();
        public List<BeheerUser> UsersSearch { get; set; } = new List<BeheerUser>();
        public List<BeheerUser> UsersAll { get; set; } = new List<BeheerUser>();

        public void GetAllUsersFromDatabase()
        {
            UsersAll.Clear();
            List<User> tempUsers = _userBeheerRepository.GetAllUsers();
            foreach (User tempUser in tempUsers)
            {
                UsersAll.Add(new BeheerUser(tempUser.Id, tempUser.Name, tempUser.Username, tempUser.Email, tempUser.Password, tempUser.Role, tempUser.ManagerUsername));
            }
        }

        public void GetSelectUsersFromDatabase(int index)
        {
            UsersSearch.Clear();

            var tempUsers = index == 7 ? _userBeheerRepository.GetAllUsers() : _userBeheerRepository.GetAllUsersWithFunction((Role)index);

            foreach (User tempUser in tempUsers)
            {
                UsersSearch.Add(new BeheerUser(tempUser.Id, tempUser.Name, tempUser.Username, tempUser.Email, tempUser.Password, tempUser.Role, tempUser.ManagerUsername));
            }
        }


        public void DeleteUser(int delIndex)
        {
            _userBeheerRepository.RemoveUser(UsersSearch[delIndex]);
        }

        public void UpdateUser(User user)
        {
            _userBeheerRepository.UpdateUser(user);
        }

        public void AddUser(User user)
        {
            _userBeheerRepository.AddUser(user);
        }

        public int GetIndex(string username)
        {
            return _userBeheerRepository.GetUserId(username);
        }
    }
}
