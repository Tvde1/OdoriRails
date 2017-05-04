using OdoriRails.BaseClasses;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

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

        public void AddUserAndAssignTram(User user, string tramId)
        {
            var newUser = _userBeheerRepository.AddUser(user);

            int tramIdResult;
            if (tramId == null) _userBeheerRepository.SetUserToTram(newUser, null);
            if (int.TryParse(tramId, out tramIdResult)) _userBeheerRepository.SetUserToTram(newUser, tramIdResult);
        }

        public int GetIndex(string username)
        {
            return _userBeheerRepository.GetUserId(username);
        }

        internal bool AddUser(string name, string userName, string email, string password, Role role, string managedName, string tramId)
        {
            int tramIdResult = -1;
            if (userName == "")
            {
                MessageBox.Show("De username kan niet leeg zijn.");
                return false;
            }
            if (_userBeheerRepository.DoesUserExist(userName))
            {
                MessageBox.Show("Deze username is al in gebruik.");
                return false;
            }
            if (tramId != "" && int.TryParse(tramId, out tramIdResult) && !_userBeheerRepository.DoesTramExist(tramIdResult))
            {
                MessageBox.Show("Deze tram bestaat niet.");
                return false;
            }
            if (password == "")
            {
                MessageBox.Show("Het wachtwoord kan niet leeg zijn.");
                return false;
            }

            var tramIdString = tramIdResult == -1 ? null : tramIdResult.ToString();

            var newUser = new User(0, name, userName, email, password, role, managedName == "" ? null : managedName);
            AddUserAndAssignTram(newUser, tramIdString);
            return true;
        }

        public bool EditUser(string username, int id, string newName, string newUsername, string newEmail, string newPassword, Role role, string managedText, string tramIdText)
        {
            if (username != newUsername && _userBeheerRepository.DoesUserExist(newUsername))
            {
                MessageBox.Show("Deze gebruikersnaam is al in gebruik.");
                return false;
            }
            if (newPassword == "")
            {
                MessageBox.Show("Het wachtwoord kan niet leeg zijn.");
                return false;
            }

            var newUser = new User(id, newName, newUsername, newEmail, newPassword, role, managedText == "" ? null : managedText);
            _userBeheerRepository.UpdateUser(newUser);

            var tramResult = -1;
            if (int.TryParse(tramIdText, out tramResult)) return true;
            _userBeheerRepository.SetUserToTram(newUser, tramResult);
            return true;
        }
    }
}
