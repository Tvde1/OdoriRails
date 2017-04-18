using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    /// <summary>
    /// Database Adapter voor de mssql datatabase.
    /// </summary>
    public class MssqlDatabaseContext : IDatabaseConnector
    {
        private readonly string _connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=OdoriRailsDatabase;Trusted_Connection=True;";
        //Deze werkt als Microsoft SQL Server Management Studio geinstalleerd is.
        private int _remiseNumber = 0;

        #region user
        public User AddUser(User user)
        {
            var query = new SqlCommand("INSERT INTO [User] (Username,Password,Email,Name,Role,ManagedBy) VALUES (@username,@pass,@email,@name,@role,@managedBy); SELECT LAST_INSERT_ID();");
            query.Parameters.AddWithValue("@name", user.Name);
            query.Parameters.AddWithValue("@username", user.Username);
            query.Parameters.AddWithValue("@pass", user.Password);
            query.Parameters.AddWithValue("@email", user.Email);
            query.Parameters.AddWithValue("@role", (int)user.Role);

            if (string.IsNullOrEmpty(user.ManagerUsername)) query.Parameters.AddWithValue("@managedBy", null);
            else query.Parameters.AddWithValue("@managedBy", GetUserId(user.ManagerUsername));

            var data = GetData(query);
            var id = (ulong)data.Rows[0][0];

            user.SetId(Convert.ToInt32(id));
            return user;
        }

        public List<User> GetAllUsers()
        {
            var query = new SqlCommand("SELECT * FROM [User]");
            var data = GetData(query);
            return GenerateListWithFunction(data, CreateUser);
        }

        public void RemoveUser(User user)
        {
            if (string.IsNullOrEmpty(user.Username)) throw new Exception("The User to delete does not have a username.");
            var query = new SqlCommand("DELETE FROM [User] WHERE UserPk = " + GetUserId(user.Username));
            GetData(query);
        }

        public User GetUser(int id)
        {
            var command = new SqlCommand($"SELECT * FROM [User] WHERE UserPk = {id}");
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        public void UpdateUser(User user)
        {
            var query = new SqlCommand("UPDATE User SET Name = @name, Username = @username, Password = @password, Email = @email, Role = @role, ManagedBy = @managedby WHERE UserPk = @id");
            query.Parameters.AddWithValue("@username", user.Username);
            query.Parameters.AddWithValue("@name", user.Name);
            query.Parameters.AddWithValue("@password", user.Password);
            query.Parameters.AddWithValue("@email", user.Email);
            query.Parameters.AddWithValue("@role", (int)user.Role);
            if (string.IsNullOrEmpty(user.ManagerUsername)) query.Parameters.AddWithValue("@managedby", null);
            else query.Parameters.AddWithValue("@managedby", GetUserId(user.ManagerUsername));
            query.Parameters.AddWithValue("@id", user.Id);
            GetData(query);
        }

        public User GetUser(string userName)
        {
            var command = new SqlCommand("SELECT * FROM [User] WHERE UserPk = @id");
            command.Parameters.AddWithValue("@id", GetUserId(userName));
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        public List<User> GetAllUsersWithRole(Role role)
        {
            var command = new SqlCommand($"SELECT * FROM [User] WHERE Role = {(int)role}");
            var data = GetData(command);
            return GenerateListWithFunction(data, CreateUser);
        }

        private User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //name gebr wachtw email rol 
            string parentUserString = array[6] == DBNull.Value ? "" : GetUser((int)array[6]).Username;
            return new User((int)array[0], (string)array[1], (string)array[2], (string)array[4], (string)array[3], (Role)(int)array[5], parentUserString);
        }
        #endregion

        #region tram
        public void AddTram(Tram tram)
        {
            var query = new SqlCommand("INSERT INTO [Tram] (TramPk,Line,Status,ModelFk,DriverFk), VALUES(@id,@line,@status,@model,@driver)");
            query.Parameters.AddWithValue("@id", tram.Number);
            query.Parameters.AddWithValue("@line", tram.Line);
            query.Parameters.AddWithValue("@status", (int)tram.Status);
            query.Parameters.AddWithValue("@model", (int)tram.Model);
            if (tram.Driver != null)
            {
                query.Parameters.AddWithValue("@driver", GetUserId(tram.Driver.Username));
            }
            else
            {
                query.Parameters.AddWithValue("@driver", null);
            }

            GetData(query);
        }

        public void RemoveTram(Tram tram)
        {
            var query = new SqlCommand($"DELETE FROM Tram WHERE TramPk = {tram.Number}");
            GetData(query);
        }

        public Tram GetTram(int id)
        {
            var command = new SqlCommand($"SELECT * FROM Tram WHERE TramPk = {id}");
            var table = GetData(command);
            return CreateTram(table.Rows[0]);
        }

        public List<Tram> GetAllTramsOnATrack()
        {
            var command = new SqlCommand($"SELECT Tram.* FROM Tram INNER JOIN Sector ON Tram.TramPk = Sector.TramFk WHERE Tram.RemiseFk = {_remiseNumber}");
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
            var trackQuery = new SqlCommand($"SELECT * FROM Track WHERE RemiseFk = {_remiseNumber}");
            var sectorQuery = new SqlCommand($"SELECT * FROM Sector WHERE RemiseFk = {_remiseNumber}");
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
[User] ON ServiceUser.UserCk = [User].UserPk
WHERE ([User].UserPk = @id)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Repair.ServiceFk = derivedtbl_2.ServicePk";

            string cleans = @"SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
[User] ON ServiceUser.UserCk = [User].UserPk
WHERE ([User].UserPk = @id)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Repair.ServiceFk = derivedtbl_2.ServicePk";

            var repairQuery = new SqlCommand(repairs);
            repairQuery.Parameters.AddWithValue("@id", user.Id);
            var repairData = GetData(repairQuery);

            var cleanQuery = new SqlCommand(cleans);
            cleanQuery.Parameters.AddWithValue("@id", user.Id);
            var cleanData = GetData(cleanQuery);

            List<Service> returnList = new List<Service>();

            returnList.AddRange(GenerateListWithFunction(repairData, CreateRepair));
            returnList.AddRange(GenerateListWithFunction(cleanData, CreateCleaning));

            return returnList;
        }

        public Cleaning AddCleaning(Cleaning cleaning)
        {
            var serviceQuery = new SqlCommand(@"INSERT INTO Service (StartDate, EndDate, TramFk) VALUES (@startdate, @enddate, @tramfk); SELECT LAST_INSERT_ID();");
            serviceQuery.Parameters.AddWithValue("@startdate", cleaning.StartDate);
            if (cleaning.StartDate == DateTime.MinValue)
            {
                serviceQuery.Parameters.AddWithValue("@enddate", null);
            }
            else
            {
                serviceQuery.Parameters.AddWithValue("@enddate", cleaning.EndDate);
            }
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
            var serviceQuery = new SqlCommand(@"INSERT INTO Service (StartDate, EndDate, TramFk) VALUES (@startdate, @enddate, @tramfk); SELECT LAST_INSERT_ID();");
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

        public List<Repair> GetAllRepairsWithoutUsers()
        {
            var repairQuery = new SqlCommand(@"SELECT Repair.*
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
            var cleanQuery = new SqlCommand(@"SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Clean.ServiceFk = derivedtbl_1.ServicePk");
            var cleanData = GetData(cleanQuery);
            return GenerateListWithFunction(cleanData, CreateCleaning);
        }


        private Cleaning CreateCleaning(DataRow row)
        {
            var array = row.ItemArray;
            var serviceQuery = new SqlCommand($"SELECT * FROM Service WHERE ServicePk = {(string)array[0]}");
            var serviceData = GetData(serviceQuery);
            var service = serviceData.Rows[0].ItemArray;
            return new Cleaning((int)service[0], (DateTime)service[1], (DateTime)service[2], (CleaningSize)array[1], (string)array[2], GetUsersInService((int)service[0]), (int)service[3]);
        }

        private Repair CreateRepair(DataRow row)
        {
            var array = row.ItemArray;
            var serviceQuery = new SqlCommand($"SELECT * FROM Service WHERE ServicePk = {(string)array[0]}");
            var serviceData = GetData(serviceQuery);
            var service = serviceData.Rows[0].ItemArray;
            // ReSharper disable once PossibleInvalidCastException
            return new Repair((int)service[0], (DateTime)service[1], (DateTime)service[2], (RepairType)array[3], (string)array[3], (string)array[2], GetUsersInService((int)service[0]), (int)service[3]);
        }

        private List<User> GetUsersInService(int serviceId)
        {
            var query = new SqlCommand($"SELECT UserCk FROM ServiceUser WHERE ServiceCk = {serviceId}");
            var data = GetData(query);
            return GenerateListWithFunction(data, CreateUser);
        }

        public void EditService(Service service)
        {
            switch (service.GetType().Name)
            {
                case "Repair":
                    {
                        var repair = (Repair)service;
                        var repairQuery = new SqlCommand("UPDATE Repair SET Solution = @solution, Defect = @defect, Type = @type WHERE RepairFK = @id");
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
                        var cleaningQuery = new SqlCommand("UPDATE Clean SET Size = @size, Remarks = @remarks WHERE CleanPk = @id");
                        cleaningQuery.Parameters.AddWithValue("@size", (int)cleaning.Size);
                        cleaningQuery.Parameters.AddWithValue("@remarks", cleaning.Comments);
                        break;
                    }
            }
            var query = new SqlCommand("UPDATE Service SET StartDate = @startdate, EndDate = @enddate, TramFk = @tramfk WHERE ServicePk = @id");
            query.Parameters.AddWithValue("@startdate", service.StartDate);
            query.Parameters.AddWithValue("@enddate", service.EndDate);
            query.Parameters.AddWithValue("@tramfk", service.TramId);
            GetData(query);
        }

        public void DeleteService(Service service)
        {
            var query = new SqlCommand("DELETE FROM Service WHERE ServicePk = @id; DELETE FROM Clean WHERE ServiceFk = @id; DELETE FROM Repair WHERE ServiceFk = @id");
            query.Parameters.AddWithValue("@id", service.Id);
            GetData(query);
        }

        #endregion

        #region login

        public bool ValidateUsername(string username)
        {
            var query = new SqlCommand("SELECT UserPk FROM [User] WHERE Username = @usrname");
            query.Parameters.AddWithValue("@usrname", username);
            var data = GetData(query);
            return data.Rows.Count != 0;
        }

        public bool MatchUsernameAndPassword(string username, string password)
        {
            var query = new SqlCommand("SELECT Password FROM [User] WHERE Username = @usrname");
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
        private DataTable GetData(SqlCommand command)
        {
            try
            {
                var dataTable = new DataTable();
                using (var conn = new SqlConnection(_connectionString))
                {
                    command.Connection = conn;
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch
            {
                throw new Exception("De uitgevoerde query is niet correct: \r\n" + command.CommandText);
            }
        }

        /// <summary>
        /// Haal het database ID op via de username.
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public int GetUserId(string username)
        {
            var query = new SqlCommand("SELECT UserPk FROM [User] WHERE Username = @username");
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