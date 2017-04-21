using System.Collections.Generic;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    public interface IUserContext
    {
        User AddUser(User user);

        List<User> GetAllUsers();

        void RemoveUser(User user);

        void UpdateUser(User user);

        List<User> GetAllUsersWithFunction(Role role);
    }
}
