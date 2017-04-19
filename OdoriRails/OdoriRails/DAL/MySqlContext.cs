using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using MySql.Data.MySqlClient;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    /// <summary>
    /// Tijdelijke databaseadapter.
    /// </summary>
    public class MySqlContext : IDatabaseConnector
    {
        //private string _connectionString = "Data Source=84.30.16.219;Initial Catalog=OdoriRails;Persist Security Info=True;User ID=OdoriRails;Password=12345678;";
        private readonly string _connectionString = @"Server=192.168.20.167;Database=OdoriRails;Uid=OdoriRails;Pwd=OdoriRails123;";
        private int _remiseNumber = 0;

        #region user
        public User AddUser(User user)
        {
            var query = new MySqlCommand("INSERT INTO User (Username,Password,Email,Name,Role,ManagedBy) VALUES (@username,@pass,@email,@name,@role,@managedBy); SELECT LAST_INSERT_ID();");
            query.Parameters.AddWithValue("@name", user.Name);
            query.Parameters.AddWithValue("@username", user.Username);
            query.Parameters.AddWithValue("@pass", user.Password);
            query.Parameters.AddWithValue("@email", user.Email);
            query.Parameters.AddWithValue("@role", (int)user.Role);

            if (string.IsNullOrEmpty(user.ManagerUsername)) query.Parameters.AddWithValue("@managedBy", DBNull.Value);
            else query.Parameters.AddWithValue("@managedBy", GetUserId(user.ManagerUsername));

            var data = GetData(query);
            var id = (ulong)data.Rows[0][0];

            user.SetId(Convert.ToInt32(id));
            return user;
        }

        public List<User> GetAllUsers()
        {
            var query = new MySqlCommand("SELECT * FROM User");
            var data = GetData(query);
            return GenerateListWithFunction(data, CreateUser);
        }

        public void RemoveUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username)) throw new Exception("The User to delete does not have a username.");
            var query = new MySqlCommand("DELETE FROM User WHERE UserPk = " + GetUserId(user.Username));
            GetData(query);
        }

        public void UpdateUser(User user)
        {
            var query = new MySqlCommand("UPDATE User SET Name = @name, Username = @username, Password = @password, Email = @email, Role = @role, ManagedBy = @managedby WHERE UserPk = @id");
            query.Parameters.AddWithValue("@username", user.Username);
            query.Parameters.AddWithValue("@name", user.Name);
            query.Parameters.AddWithValue("@password", user.Password);
            query.Parameters.AddWithValue("@email", user.Email);
            query.Parameters.AddWithValue("@role", (int)user.Role);

            if (string.IsNullOrEmpty(user.ManagerUsername)) query.Parameters.AddWithValue("@managedby", DBNull.Value);
            else query.Parameters.AddWithValue("@managedby", GetUserId(user.ManagerUsername));

            query.Parameters.AddWithValue("@id", user.Id);
            GetData(query);
        }

        public User GetUser(int id)
        {
            var command = new MySqlCommand($"SELECT * FROM User WHERE UserPk = {id}");
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        public User GetUser(string userName)
        {
            var command = new MySqlCommand("SELECT * FROM User WHERE UserPk = @id");
            command.Parameters.AddWithValue("@id", GetUserId(userName));
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        public List<User> GetAllUsersWithRole(Role role)
        {
            var command = new MySqlCommand($"SELECT * FROM User WHERE Role = {(int)role}");
            var data = GetData(command);
            return GenerateListWithFunction(data, CreateUser);
        }

        private User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //PK, Name, Usename, Password, Email, Role, ManagedBy, 
            string parentUserString = array[6] == DBNull.Value ? "" : GetUser((int)array[6]).Username;
            return new User((int)array[0], (string)array[1], (string)array[2], (string)array[4], (string)array[3], (Role)(int)array[5], parentUserString);
        }
        #endregion

        #region tram
        public void AddTram(Tram tram)
        {
            var query = new MySqlCommand("INSERT INTO [Tram] (TramPk,Line,Status,ModelFk,DriverFk,Location,DepartureTime), VALUES(@id,@line,@status,@model,@driver,@location,@departure)");
            query.Parameters.AddWithValue("@id", tram.Number);
            query.Parameters.AddWithValue("@line", tram.Line);
            query.Parameters.AddWithValue("@status", (int)tram.Status);
            query.Parameters.AddWithValue("@model", (int)tram.Model);
            query.Parameters.AddWithValue("@location", (int)tram.Location);
            query.Parameters.AddWithValue("@departure", tram.DepartureTime);
            if (tram.Driver != null) query.Parameters.AddWithValue("@driver", GetUserId(tram.Driver.Username));
            else query.Parameters.AddWithValue("@driver", DBNull.Value);

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

        public List<Tram> GetAllTrams()
        {
            return GenerateListWithFunction(GetData(new MySqlCommand("SELECT * FROM Tram")), CreateTram);
        }

        public List<Tram> GetAllTramsWithStatus(TramStatus status)
        {
            return GenerateListWithFunction(GetData(new MySqlCommand($"SELECT * FROM Tram WHERE Status = {(int)status}")), CreateTram);
        }

        public List<Tram> GetAllTramsWithlocation(TramLocation location)
        {
            return GenerateListWithFunction(GetData(new MySqlCommand($"SELECT * FROM Tram WHERE Status = {(int)location}")), CreateTram);
        }

        public Tram GetTramByDriver(User driver)
        {
            return CreateTram(GetData(new MySqlCommand($"SELECT * FROM Tram WHERE DriverFk = {driver.Id}")).Rows[0]);
        }

        public List<Tram> GetAllTramsOnATrack()
        {
            var command = new MySqlCommand($"SELECT Tram.* FROM Tram INNER JOIN Sector ON Tram.TramPk = Sector.TramFk WHERE Tram.RemiseFk = {_remiseNumber}");
            var data = GetData(command);
            return GenerateListWithFunction(data, CreateTram);
        }

        private Tram CreateTram(DataRow row)
        {
            //Pk, Line, Status, Driver, Model, Remise, Location, Depart
            var array = row.ItemArray;
            var id = (int)array[0];
            var line = (int)array[1];
            var status = (TramStatus)array[2];
            var driver = GetUser((int)array[3]);
            var model = (Model) array[4];
            var remise = (int) array[5];
            var location = (TramLocation) array[6];
            DateTime? depart = null;
            if (array[7] != DBNull.Value) depart = (DateTime)array[7];
            return new Tram(id, status, line, driver, model, location, depart);
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
            if (String.IsNullOrEmpty((string)array[3]) && array[3] != DBNull.Value) tram = GetTram((int)array[3]);

            return new Sector((int)array[0], (int)array[2], (SectorStatus)array[1], tram);
        }

        private Track CreateTrack(DataRow row)
        {
            var array = row.ItemArray;
            return new Track((int)array[0], (int)array[1], (TrackType)array[2]);
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
User ON ServiceUser.UserCk = User.UserPk
WHERE (User.UserPk = @id)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Repair.ServiceFk = derivedtbl_2.ServicePk";

            string cleans = @"SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
User ON ServiceUser.UserCk = User.UserPk
WHERE (User.UserPk = @id)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Clean.ServiceFk = derivedtbl_2.ServicePk";

            var repairQuery = new MySqlCommand(repairs);
            repairQuery.Parameters.AddWithValue("@id", user.Id);
            var repairData = GetData(repairQuery);

            var cleanQuery = new MySqlCommand(cleans);
            cleanQuery.Parameters.AddWithValue("@id", user.Id);
            var cleanData = GetData(cleanQuery);

            List<Service> returnList = new List<Service>();

            returnList.AddRange(GenerateListWithFunction(repairData, CreateRepair));
            returnList.AddRange(GenerateListWithFunction(cleanData, CreateCleaning));

            return returnList;
        }

        public List<Repair> GetAllRepairsWithoutUsers()
        {
            var repairQuery = new MySqlCommand(@"SELECT Repair.*
FROM Repair INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Repair.ServiceFk = derivedtbl_1.ServicePk");
            var repairData = GetData(repairQuery);
            return GenerateListWithFunction(repairData, CreateRepair);

        }

        public List<Cleaning> GetAllCleansWithoutUsers()
        {
            var cleanQuery = new MySqlCommand(@"SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Clean.ServiceFk = derivedtbl_1.ServicePk");
            var cleanData = GetData(cleanQuery);
            return GenerateListWithFunction(cleanData, CreateCleaning);
        }

        public Cleaning AddCleaning(Cleaning cleaning)
        {
            var serviceQuery = new MySqlCommand(@"INSERT INTO Service (StartDate, EndDate, TramFk) VALUES (@startdate, @enddate, @tramfk); SELECT LAST_INSERT_ID();");
            serviceQuery.Parameters.AddWithValue("@startdate", cleaning.StartDate);
            if (cleaning.StartDate == DateTime.MinValue)serviceQuery.Parameters.AddWithValue("@enddate", DBNull.Value);
            else serviceQuery.Parameters.AddWithValue("@enddate", cleaning.EndDate);
            serviceQuery.Parameters.AddWithValue("@tramfk", cleaning.TramId);

            var data = GetData(serviceQuery);

            var cleaningQuery = new SqlCommand(@"INSERT INTO Cleaning (ServiceFk, Size, Remarks) VALUES (@id, @size, @remarks)");
            cleaningQuery.Parameters.AddWithValue("@id", (int)data.Rows[0].ItemArray[0]);
            cleaningQuery.Parameters.AddWithValue("@size", (int)cleaning.Size);
            cleaningQuery.Parameters.AddWithValue("@remarks", cleaning.Comments);
            GetData(serviceQuery);

            cleaning.SetId((int)data.Rows[0].ItemArray[0]);
            return cleaning;
        }

        public Repair AddRepair(Repair repair)
        {
            var serviceQuery = new MySqlCommand(@"INSERT INTO Service (StartDate, EndDate, TramFk) VALUES (@startdate, @enddate, @tramfk); SELECT LAST_INSERT_ID();");
            serviceQuery.Parameters.AddWithValue("@startdate", repair.StartDate);
            serviceQuery.Parameters.AddWithValue("@enddate", repair.EndDate);
            serviceQuery.Parameters.AddWithValue("@tramfk", repair.TramId);

            var data = GetData(serviceQuery);

            var repairQuery = new SqlCommand(@"INSERT INTO Repair (ServiceFk, Solution, Defect, Type) VALUES (@id, @solution, @defect, @type)");
            repairQuery.Parameters.AddWithValue("@id", (int)data.Rows[0].ItemArray[0]);
            repairQuery.Parameters.AddWithValue("@solution", repair.Solution);
            repairQuery.Parameters.AddWithValue("@defect", repair.Defect);
            repairQuery.Parameters.AddWithValue("@type", (int)repair.Type);
            GetData(serviceQuery);

            repair.SetId((int)data.Rows[0].ItemArray[0]);
            return repair;
        }

        public void EditService(Service service)
        {
            switch (service.GetType().Name)
            {
                case "Repair":
                    {
                        var repair = (Repair)service;
                        var repairQuery = new MySqlCommand("UPDATE Repair SET Solution = @solution, Defect = @defect, Type = @type WHERE RepairFK = @id");
                        repairQuery.Parameters.AddWithValue("@solution", repair.Solution);
                        repairQuery.Parameters.AddWithValue("@defect", repair.Defect);
                        repairQuery.Parameters.AddWithValue("@type", (int)repair.Type);
                        repairQuery.Parameters.AddWithValue("@id", repair.Id);
                        GetData(repairQuery);
                        break;
                    }
                case "Cleaning":
                    {
                        var cleaning = (Cleaning)service;
                        var cleaningQuery = new MySqlCommand("UPDATE Clean SET Size = @size, Remarks = @remarks WHERE CleanPk = @id");
                        cleaningQuery.Parameters.AddWithValue("@size", (int)cleaning.Size);
                        cleaningQuery.Parameters.AddWithValue("@remarks", cleaning.Comments);
                        break;
                    }
            }
            var query = new MySqlCommand("UPDATE Service SET StartDate = @startdate, EndDate = @enddate, TramFk = @tramfk WHERE ServicePk = @id");
            query.Parameters.AddWithValue("@startdate", service.StartDate);
            query.Parameters.AddWithValue("@enddate", service.EndDate);
            query.Parameters.AddWithValue("@tramfk", service.TramId);
            GetData(query);
        }

        public void DeleteService(Service service)
        {
            var query = new MySqlCommand("DELETE FROM Service WHERE ServicePk = @id; DELETE FROM Clean WHERE ServiceFk = @id; DELETE FROM Repair WHERE ServiceFk = @id");
            query.Parameters.AddWithValue("@id", service.Id);
            GetData(query);
        }


        private Cleaning CreateCleaning(DataRow row)
        {
            var array = row.ItemArray;
            var serviceQuery = new MySqlCommand($"SELECT * FROM Service WHERE ServicePk = {(string)array[0]}");
            var serviceData = GetData(serviceQuery);
            var service = serviceData.Rows[0].ItemArray;
            return new Cleaning((int)service[0], (DateTime)service[1], (DateTime)service[2], (CleaningSize)array[1], (string)array[2], GetUsersInService((int)service[0]), (int)service[3]);
        }

        private Repair CreateRepair(DataRow row)
        {
            var array = row.ItemArray;
            var serviceQuery = new MySqlCommand($"SELECT * FROM Service WHERE ServicePk = {(string)array[0]}");
            var serviceData = GetData(serviceQuery);
            var service = serviceData.Rows[0].ItemArray;
            // ReSharper disable once PossibleInvalidCastException
            return new Repair((int)service[0], (DateTime)service[1], (DateTime)service[2], (RepairType)array[3], (string)array[3], (string)array[2], GetUsersInService((int)service[0]), (int)service[3]);
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
            var query = new MySqlCommand("SELECT UserPk FROM User WHERE Username = @usrname");
            query.Parameters.AddWithValue("@usrname", username);
            var data = GetData(query);
            return data.Rows.Count != 0;
        }

        public bool MatchUsernameAndPassword(string username, string password)
        {
            var query = new MySqlCommand("SELECT Password FROM User WHERE Username = @usrname");
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
            try
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
            catch (Exception ex)
            {
                throw new Exception("De uitgevoerde query is niet correct: \r\n" + command.CommandText + "\r\n\r\n" + ex);
            }
        }

        /// <summary>
        /// Haal het database ID op via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserId(string username)
        {
            var query = new MySqlCommand("SELECT UserPk FROM User WHERE Username = @username");
            query.Parameters.AddWithValue("@username", username);
            var table = GetData(query);
            return (int)table.Rows[0].ItemArray[0];
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
    }
}