using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Data;
using System.Linq;

namespace OdoriRails
{
    public class MySqlContext : IDatabaseConnector
    {
        private string _connectionString = "Data Source=84.30.16.219;Initial Catalog=OdoriRails;Persist Security Info=True;User ID=OdoriRails;Password=12345678;";


        private int _remiseNumber = 0;

        #region user
        public User AddUser(User user)
        {
            var query = new MySqlCommand("INSERT INTO [User] (Username,Password,Email,Name,Email,Role,ManagedBy), VALUES({name},{pass},{email},{role},{managedBy}); SELECT LAST_INSERT_ID();");
            query.Parameters.AddWithValue("{name}", user.Username);
            query.Parameters.AddWithValue("{pass}", user.Password);
            query.Parameters.AddWithValue("{email}", user.Email);
            query.Parameters.AddWithValue("{role}", (int)user.Role);

            if (user.ManagerUsername == null) query.Parameters.AddWithValue("{managedBy}", null);
            else query.Parameters.AddWithValue("{managedBy}", GetUserId(user.ManagerUsername));

            user.SetID((int)GetData(query).Rows[0][0]);
            return user;
        }

        public List<User> GetAllUsers()
        {
            var query = new MySqlCommand("SELECT * FROM [User]");
            var data = GetData(query);
            return GenerateListWithFunction(data, CreateUser);
        }

        public void RemoveUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username)) throw new Exception("The User to delete does not have a username.");
            var query = new MySqlCommand("DELETE FROM [User] WHERE UserPk = " + GetUserId(user.Username));
            GetData(query);
        }

        public User GetUser(int id)
        {
            var command = new MySqlCommand($"SELECT * FROM [User] WHERE UserPk = {id}");
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        public User GetUser(string userName)
        {
            var command = new MySqlCommand("SELECT * FROM [User] WHERE UserPk = @id");
            command.Parameters.AddWithValue("@id", GetUserId(userName));
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        public List<User> GetAllUsersWithRole(Role role)
        {
            var command = new MySqlCommand($"SELECT * FROM [User] WHERE Role = {(int)role}");
            var data = GetData(command);
            return GenerateListWithFunction(data, CreateUser);
        }

        private User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //name gebr wachtw email rol 
            string parentUserString = array[6] == DBNull.Value ? "" : GetUser((string)array[6]).Username;
            return new User((int)array[0], (string)array[1], (string)array[2], (string)array[3], (string)array[4], (Role)(int)array[5], parentUserString);
        }
        #endregion

        #region tram
        public void AddTram(Tram tram)
        {
            var query = new MySqlCommand("INSERT INTO [Tram] (TramPk,Line,Status,ModelFk,DriverFk), VALUES({id},{line},{status},{model},{driver})");
            query.Parameters.AddWithValue("{id}", tram.Number);
            query.Parameters.AddWithValue("{line}", tram.Line);
            query.Parameters.AddWithValue("{status}", (int)tram.Status);
            query.Parameters.AddWithValue("{model}", (int)tram.Model);
            if (tram.Driver != null)
            {
                query.Parameters.AddWithValue("{driver}", GetUserId(tram.Driver.Username));
            }
            else
            {
                query.Parameters.AddWithValue("{driver}", null);
            }

            GetData(query);
        }

        public void RemoveTram(Tram tram)
        {
            var query = new MySqlCommand($"DELETE FROM Tram WHERE TramPk = {tram.Number}");
            GetData(query);
        }

        public Tram GetTram(int id)
        {
            var command = new MySqlCommand($"SELECT * FROM Tram WHERE TramPk = {id}");
            var table = GetData(command);
            return CreateTram(table.Rows[0]);
        }

        public List<Tram> GetAllTramsOnATrack()
        {
            var command = new MySqlCommand($"SELECT Tram.* FROM Tram INNER JOIN Sector ON Tram.TramPk = Sector.TramFk WHERE Tram.RemiseFk = {_remiseNumber}");
            var data = GetData(command);
            return GenerateListWithFunction(data, CreateTram);
        }

        private Tram CreateTram(DataRow row)
        {
            var array = row.ItemArray;
            return new Tram((int)array[0], (TramStatus)array[2], (int)array[1], GetUser((int)array[4]), (Model)array[3]);
        }
        #endregion

        #region track and sector
        public List<Track> GetTracksAndSectors()
        {
            var returnList = new List<Track>();
            var trackQuery = new MySqlCommand($"SELECT * FROM Track WHERE RemiseFk = {_remiseNumber}");
            var sectorQuery = new MySqlCommand($"SELECT * FROM Sector WHERE RemiseFk = {_remiseNumber}");
            var trackData = GetData(trackQuery);
            var sectorData = GetData(sectorQuery);

            var sectorList = GenerateListWithFunction(sectorData, CreateSector);
            var trackList = GenerateListWithFunction(trackData, CreateTrack);

            foreach (var track in trackList)
            {
                sectorList.Where(x => x.TrackNumber == track.Number).ToList().ForEach(x => track.AddSector(x));
                returnList.Add(track);
            }
            return returnList;
        }

        private Sector CreateSector(DataRow row)
        {
            var array = row.ItemArray;
            Tram tram = null;
            if (array[3] != null) tram = GetTram((int)array[3]);

            return new Sector((int)array[0], (int)array[2], (SectorStatus)array[1], tram);
        }

        private Track CreateTrack(DataRow row)
        {
            var array = row.ItemArray;
            return new Track((int)array[0]);
        }
        #endregion

        #region service
        public List<Service> GetAllServicesFromUser(User user)
        {
            string repairs = @"SELECT Repair.*
FROM Repair INNER JOIN
(SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
[User] ON ServiceUser.UserCk = [User].UserPk
WHERE ([User].UserPk = @id)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Repair.ServiceFk = derivedtbl_2.ServicePk";

            string cleans = @"SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
[User] ON ServiceUser.UserCk = [User].UserPk
WHERE ([User].Username = @usrname)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Repair.ServiceFk = derivedtbl_2.ServicePk";

            var repairQuery = new MySqlCommand(repairs);
            repairQuery.Parameters.AddWithValue("@id", user.ID);
            var repairData = GetData(repairQuery);

            var cleanQuery = new MySqlCommand(cleans);
            cleanQuery.Parameters.AddWithValue("@id", user.ID);
            var cleanData = GetData(cleanQuery);

            List<Service> returnList = new List<Service>();

            returnList.AddRange(GenerateListWithFunction(repairData, CreateRepair));
            returnList.AddRange(GenerateListWithFunction(cleanData, CreateCleaning));

            return returnList;
        }

        public List<Service> GetAllServicesWithoutUser(User user)
        {
 var repairQuery = new MySqlCommand(@"SELECT Repair.*
FROM Repair INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Repair.ServiceFk = derivedtbl_1.ServicePk");

 var cleanQuery = new MySqlCommand(@"SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Clean.ServiceFk = derivedtbl_1.ServicePk");
            var repairData = GetData(repairQuery);
            var cleanData = GetData(cleanQuery);

            var returnList = new List<Service>();

            returnList.AddRange(GenerateListWithFunction(repairData, CreateRepair));
            returnList.AddRange(GenerateListWithFunction(cleanData, CreateCleaning));

            return returnList;
        }


        private Cleaning CreateCleaning(DataRow row)
        {
            var array = row.ItemArray;
            var serviceQuery = new MySqlCommand($"SELECT * FROM Service WHERE ServicePk = {(string)array[0]}");
            var serviceData = GetData(serviceQuery);
            var service = serviceData.Rows[0].ItemArray;
            return new Cleaning((int)service[0], (DateTime)service[1], (DateTime)service[2], (Cleaning.CleaningSize)array[1], (string)array[2], GetUsersInService((int)service[0]));
        }

        private Repair CreateRepair(DataRow row)
        {
            var array = row.ItemArray;
            var serviceQuery = new MySqlCommand($"SELECT * FROM Service WHERE ServicePk = {(string)array[0]}");
            var serviceData = GetData(serviceQuery);
            var service = serviceData.Rows[0].ItemArray;
            return new Repair((int)service[0], (DateTime)service[1], (DateTime)service[2], (Repair.RepairType)array[3], (string)array[3], (string)array[2], GetUsersInService((int)service[0]));
        }

        private List<User> GetUsersInService(int serviceId)
        {
            var query = new MySqlCommand($"SELECT UserCk FROM ServiceUser WHERE ServiceCk = {serviceId}");
            var data = GetData(query);
            return GenerateListWithFunction(data, CreateUser);
        }

        #endregion

        #region login
        public bool ValidateUsername(string username)
        {
            var query = new MySqlCommand("SELECT UserPk FROM [User] WHERE Username = @usrname");
            query.Parameters.AddWithValue("@usrname", username);
            var data = GetData(query);
            return data.Rows.Count != 0;
        }

        public bool MatchUsernameAndPassword(string username, string password)
        {
            var query = new MySqlCommand("SELECT Password FROM [User] WHERE Username = @usrname");
            query.Parameters.AddWithValue("@usrname", username);

            var data = GetData(query);
            try
            {
                return (string)data.Rows[0][0] == password;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        /// <summary>
        /// Haal een datatable op vanuit een query.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Een Datatable van alle rows.</returns>
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

        /// <summary>
        /// Haal het database ID op via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        private int GetUserId(string username)
        {
            var query = new MySqlCommand("SELECT UserPk FROM [User] WHERE Username = @username");
            query.Parameters.AddWithValue("@username", username);
            var table = GetData(query);
            return (int)table.Rows[0][0];
        }

        private List<T> GenerateListWithFunction<T>(DataTable data, Func<DataRow, T> func)
        {
            var returnList = new List<T>();
            foreach (DataRow row in data.Rows)
            {
                returnList.Add(func(row));
            }
            return returnList;
        }

        public List<Service> GetAllServicesWithoutUsers()
        {
            throw new NotImplementedException();
        }
    }
}