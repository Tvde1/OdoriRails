using OdoriRails.BaseClasses;
using System.Collections.Generic;
using System.Linq;

namespace User_Beheersysteem
{
    internal class Logic
    {
        private readonly UserBeheerRepository _userBeheerRepository = new UserBeheerRepository();
        public List<BeheerUser> UsersSearch { get; } = new List<BeheerUser>();
        public List<BeheerUser> UsersAll { get; } = new List<BeheerUser>();

        public void GetAllUsersFromDatabase()
        {
            UsersAll.Clear();
            var tempUsers = _userBeheerRepository.GetAllUsers();
            foreach (var tempUser in tempUsers)
            {
                var ids = _userBeheerRepository.GetTramIdByDriverId(tempUser.Id);
                int? tramId = null;
                if (ids.Count > 0) tramId = ids[0];
                UsersAll.Add(new BeheerUser(tempUser.Id, tempUser.Name, tempUser.Username, tempUser.Email, tempUser.Password, tempUser.Role, tempUser.ManagerUsername, tramId));
            }
        }

        public void GetSelectUsersFromDatabase(int index)
        {
            UsersSearch.Clear();

            var tempUsers = index == 7 ? _userBeheerRepository.GetAllUsers() : _userBeheerRepository.GetAllUsersWithFunction((Role)index);

            foreach (var tempUser in tempUsers)
            {
                var ids = _userBeheerRepository.GetTramIdByDriverId(tempUser.Id);
                int? tramId = null;
                if (ids.Count > 0) tramId = ids[0];
                UsersSearch.Add(new BeheerUser(tempUser.Id, tempUser.Name, tempUser.Username, tempUser.Email, tempUser.Password, tempUser.Role, tempUser.ManagerUsername, tramId));
            }
        }

        public void DeleteUser(int delIndex)
        {
            _userBeheerRepository.RemoveUser(UsersSearch[delIndex]);
        }

        public void UpdateUser(User user, string tramId)
        {
            int tramIdResult;
            if (tramId == null) _userBeheerRepository.SetUserToTram(user, null);
            if (int.TryParse(tramId, out tramIdResult)) _userBeheerRepository.SetUserToTram(user, tramIdResult);
            _userBeheerRepository.UpdateUser(user);
        }

        public void AddUser(User user, string tramId)
        {
            _userBeheerRepository.AddUser(user);

            int tramIdResult;
            if (tramId == null) _userBeheerRepository.SetUserToTram(user, null);
            if (int.TryParse(tramId, out tramIdResult)) _userBeheerRepository.SetUserToTram(user, tramIdResult);
        }

        public int GetIndex(string username)
        {
            return _userBeheerRepository.GetUserId(username);
        }
    }
}
