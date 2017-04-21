using OdoriRails.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace OdoriRails.DAL
{
    public class UserContext : IUserContext
    {
        public User AddUser(User user)
        {
            var query = new SqlCommand("INSERT INTO [User] (Username,Password,Email,Name,Role,ManagedBy) VALUES (@username,@pass,@email,@name,@role,@managedBy); SELECT SCOPE_IDENTITY();");
            query.Parameters.AddWithValue("@name", user.Name);
            query.Parameters.AddWithValue("@username", user.Username);
            query.Parameters.AddWithValue("@pass", user.Password);
            query.Parameters.AddWithValue("@email", user.Email);
            query.Parameters.AddWithValue("@role", (int)user.Role);

            if (string.IsNullOrEmpty(user.ManagerUsername)) query.Parameters.AddWithValue("@managedBy", DBNull.Value);
            else query.Parameters.AddWithValue("@managedBy", Database.GetUserId(user.ManagerUsername));

            user.SetId((int)Database.GetData(query).Rows[0][0]);
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
            else query.Parameters.AddWithValue("@managedby", Database.GetUserId(user.ManagerUsername));
            query.Parameters.AddWithValue("@id", user.Id);
            Database.GetData(query);
        }

        public List<User> GetAllUsersWithFunction(Role role)
        {
            return Database.GenerateListWithFunction(Database.GetData(new SqlCommand($"SELECT * FROM [User] WHERE Role = {(int)role}")), CreateUser);
        }

        private User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //name gebr wachtw email rol 
            string parentUserString = array[6] == DBNull.Value ? "" : Database.GetUser((int)array[6]).Username;
            return new User((int)array[0], (string)array[1], (string)array[2], (string)array[4], (string)array[3], (Role)(int)array[5], parentUserString);
        }
    }
}
