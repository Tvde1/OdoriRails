using OdoriRails.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OdoriRails.DAL.Subclasses
{
    public class UserContext : IUserContext
    {
        private static readonly TramContext TramContext = new TramContext();

        public User AddUser(User user)
        {
            var query = new SqlCommand("INSERT INTO [User] (Username,Password,Email,Name,Role,ManagedBy) VALUES (@username,@pass,@email,@name,@role,@managedBy); SELECT SCOPE_IDENTITY();");
            query.Parameters.AddWithValue("@name", user.Name);
            query.Parameters.AddWithValue("@username", user.Username);
            query.Parameters.AddWithValue("@pass", user.Password);
            query.Parameters.AddWithValue("@email", user.Email);
            query.Parameters.AddWithValue("@role", (int)user.Role);

            if (string.IsNullOrEmpty(user.ManagerUsername)) query.Parameters.AddWithValue("@managedBy", DBNull.Value);
            else query.Parameters.AddWithValue("@managedBy", GetUserId(user.ManagerUsername));

            user.SetId(Convert.ToInt32((decimal)Database.GetData(query).Rows[0][0]));
            return user;
        }

        public List<User> GetAllUsers()
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand("SELECT * FROM [User]")), CreateUser);
        }

        public void RemoveUser(User user)
        {
            Database.GetData(new SqlCommand($"DELETE FROM [User] WHERE UserPk = {user.Id}"));
            Database.GetData(new SqlCommand($"UPDATE [User] SET ManagedByFk = null WHERE ManagedByFk = {user.Id}"));
        }

        public void UpdateUser(User user)
        {
            var query = new SqlCommand("UPDATE [User] SET Name = @name, Username = @username, Password = @password, Email = @email, Role = @role, ManagedBy = @managedby WHERE UserPk = @id");
            query.Parameters.AddWithValue("@username", user.Username);
            query.Parameters.AddWithValue("@name", user.Name);
            query.Parameters.AddWithValue("@password", user.Password);
            query.Parameters.AddWithValue("@email", user.Email);
            query.Parameters.AddWithValue("@role", (int)user.Role);
            if (string.IsNullOrEmpty(user.ManagerUsername)) query.Parameters.AddWithValue("@managedby", DBNull.Value);
            else query.Parameters.AddWithValue("@managedby", GetUserId(user.ManagerUsername));
            query.Parameters.AddWithValue("@id", user.Id);
            Database.GetData(query);
        }

        public List<User> GetAllUsersWithFunction(Role role)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($"SELECT * FROM [User] WHERE Role = {(int)role}")), CreateUser);
        }

        public User GetUser(int id)
        {
            return CreateUser(Database.GetData(new SqlCommand($"SELECT * FROM [User] WHERE UserPk = {id}")).Rows[0]);
        }

        public User GetUser(string userName)
        {
            var command = new SqlCommand("SELECT * FROM [User] WHERE UserPk = @id");
            command.Parameters.AddWithValue("@id", GetUserId(userName));
            return CreateUser(Database.GetData(command).Rows[0]);
        }

        public int GetUserId(string username)
        {
            var query = new SqlCommand("SELECT UserPk FROM [User] WHERE Username = @username");
            query.Parameters.AddWithValue("@username", username);
            return (int)Database.GetData(query).Rows[0].ItemArray[0];
        }

        public User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //name gebr wachtw email rol 
            var parentUserString = array[6] == DBNull.Value ? "" : GetUser((int)array[6]).Username;
            var tramList = TramContext.GetTramIdByDriverId((int) array[0]);

            int? tram;
            tram = tramList.Count > 0 ? (int?) tramList[0] : null;

            return new User((int)array[0], (string)array[1], (string)array[2], (string)array[4], (string)array[3], (Role)(int)array[5], parentUserString, tram);
        }
    }
}
