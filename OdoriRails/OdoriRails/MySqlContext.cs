using System;
using System.Collections.Generic;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace OdoriRails
{
    class MySqlContext : IDatabaseConnector
    {
        private string _connectionString = "Data Source=84.30.16.219;Initial Catalog=OdoriRails;Persist Security Info=True;User ID=OdoriRails;Password=12345678;";

        public void AddTram(Tram tram)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Service> GetAllServicesFromUser(User user)
        {
            throw new NotImplementedException();
        }

        public List<Service> GetAllServicesWithoutUsers()
        {
            throw new NotImplementedException();
        }

        public List<Tram> GetAllTramsOnATrack()
        {
            throw new NotImplementedException();
        }

        public List<User> GetAllUsersWithRole(Role role)
        {
            throw new NotImplementedException();
        }

        public List<Track> GetTracksAndSectors()
        {
            throw new NotImplementedException();
        }

        public Tram GetTram(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userName)
        {
            var command = new MySqlCommand($"SELECT * FROM User WHERE Username LIKE '%@username%'");
            command.Parameters.AddWithValue("@username", userName);
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        public User GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public bool MatchUsernameAndPassword(string username, string password)
        {
            throw new NotImplementedException();
        }

        public void RemoveTram(Tram tram)
        {
            throw new NotImplementedException();
        }

        public void RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUsername(string username)
        {
            throw new NotImplementedException();
        }

        private DataTable GetData(MySqlCommand command)
        {
            var dataTable = new DataTable();
            using (var conn = new MySqlConnection(_connectionString))
            {
                command.Connection = conn;
                var adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //name gebr wachtw email rol 
            string parentUserString = array[6] == DBNull.Value ? "" : GetUser((string)array[6]).Username;
            return new User((int)array[0], (string)array[1], (string)array[2], (string)array[3], (string)array[4], (Role)(int)array[5], parentUserString);
        }
    }
}