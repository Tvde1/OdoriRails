using System.Collections.Generic;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL.Subclasses
{
    public interface IUserContext
    {
        User GetUser(string userName);

        User GetUser(int userId);

        int GetUserId(string userName);

        User AddUser(User user);

        List<User> GetAllUsers();

        void RemoveUser(User user);

        void UpdateUser(User user);

        List<User> GetAllUsersWithFunction(Role role);
    }
}
