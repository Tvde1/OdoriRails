using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    /// <summary>
    /// Tijdelijke databaseadapter.
    /// </summary>
    public class MySqlContext : IBeheerDatabaseAdapter, IInUitrijDatabaseAdapter, ILoginDatabaseAdapter, ILogisticDatabaseAdapter, ISchoonmaakReparatieDatabaseAdapter
    {

        //private string _connectionString = "Data Source=84.30.16.219;Initial Catalog=OdoriRails;Persist Security Info=True;User ID=OdoriRails;Password=12345678;";
        private const string ConnectionString = @"Server=192.168.20.167;Database=OdoriRails;Uid=OdoriRails;Pwd=OdoriRails123;";
        private const int RemiseNumber = 0;

        #region IBeheerSysteem

        public User AddUser(User user)
        {
            var query = new MySqlCommand("INSERT INTO User (Username,Password,Email,Name,Role,ManagedBy) VALUES (@username,@pass,@email,@name,@role,@managedBy); LAST_INSERT_ID();");
            query.Parameters.AddWithValue("@name", user.Name);
            query.Parameters.AddWithValue("@username", user.Username);
            query.Parameters.AddWithValue("@pass", user.Password);
            query.Parameters.AddWithValue("@email", user.Email);
            query.Parameters.AddWithValue("@role", (int)user.Role);

            if (string.IsNullOrEmpty(user.ManagerUsername)) query.Parameters.AddWithValue("@managedBy", DBNull.Value);
            else query.Parameters.AddWithValue("@managedBy", GetUserId(user.ManagerUsername));

            var data = GetData(query);

            user.SetId((int)data.Rows[0][0]);
            return user;
        }

        public List<User> GetAllUsers()
        {
            return GenerateListWithFunction(GetData(new MySqlCommand("SELECT * FROM User")), CreateUser);
        }

        public void RemoveUser(User user)
        {
            GetData(new MySqlCommand("DELETE FROM User WHERE UserPk = " + user.Id));
            GetData(new MySqlCommand($"UPDATE [User] SET ManagedByFk = null WHERE ManagedByFk = {user.Id}"));
        }

        public User GetUser(int id)
        {
            return CreateUser(GetData(new MySqlCommand($"SELECT * FROM User WHERE UserPk = {id}")).Rows[0]);
        }

        public User GetUser(string userName)
        {
            var command = new MySqlCommand("SELECT * FROM User WHERE UserPk = @id");
            command.Parameters.AddWithValue("@id", GetUserId(userName));
            return CreateUser(GetData(command).Rows[0]);
        }

        public int GetUserId(string username)
        {
            var query = new MySqlCommand("SELECT UserPk FROM User WHERE Username = @username");
            query.Parameters.AddWithValue("@username", username);
            return (int)GetData(query).Rows[0].ItemArray[0];
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

        public List<User> GetAllUsersWithRole(Role role)
        {
            return GenerateListWithFunction(GetData(new MySqlCommand($"SELECT * FROM User WHERE Role = {(int)role}")), CreateUser);
        }

        #endregion

        #region ILogin
        public bool ValidateUsername(string username)
        {
            var query = new MySqlCommand("SELECT UserPk FROM User WHERE Username = @usrname");
            query.Parameters.AddWithValue("@usrname", username);
            return GetData(query).Rows.Count != 0;
        }

        public bool MatchUsernameAndPassword(string username, string password)
        {
            var query = new MySqlCommand("SELECT Password FROM User WHERE Username = @usrname");
            query.Parameters.AddWithValue("@usrname", username);

            var data = GetData(query);
            if (data.Rows.Count > 0) return (string)data.Rows[0][0] == password;
            return false;
        }
        #endregion

        #region Logistiek

        public void AddTram(Tram tram)
        {
            var query = new MySqlCommand("INSERT INTO Tram (TramPk,Line,Status,ModelFk,DriverFk,Location,DepartureTime), VALUES(@id,@line,@status,@model,@driver,@location,@departure)");
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
            GetData(new MySqlCommand($"DELETE FROM Tram WHERE TramPk = {tram.Number}"));
        }

        public Tram GetTram(int id)
        {
            return CreateTram(GetData(new MySqlCommand($"SELECT * FROM Tram WHERE TramPk = {id}")).Rows[0]);
        }

        public List<Tram> GetAllTrams()
        {
            return GenerateListWithFunction(GetData(new MySqlCommand("SELECT * FROM Tram")), CreateTram);
        }

        public Tram GetTramByDriver(User driver)
        {
            var data = GetData(new MySqlCommand($"SELECT * FROM Tram WHERE DriverFk = {driver.Id}"));
            if (data.Rows.Count > 0) return CreateTram(data.Rows[0]);
            return null;
        }

        public List<Tram> GetAllTramsWithStatus(TramStatus status)
        {
            return GenerateListWithFunction(GetData(new MySqlCommand($"SELECT * FROM Tram WHERE Status = {(int)status}")), CreateTram);
        }

        public List<Tram> GetAllTramsWithLocation(TramLocation location)
        {
            return GenerateListWithFunction(GetData(new MySqlCommand($"SELECT * FROM Tram WHERE Status = {(int)location}")), CreateTram);
        }

        public List<Track> GetTracksAndSectors()
        {
            var returnList = new List<Track>();
            var trackQuery = new MySqlCommand($"SELECT * FROM Track WHERE RemiseFk = {RemiseNumber}");
            var sectorQuery = new MySqlCommand($"SELECT * FROM Sector WHERE RemiseFk = {RemiseNumber}");
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

        #endregion

        #region schoonmaak

        public List<Repair> GetAllRepairsFromUser(User user)
        {
            var repairQuery = new MySqlCommand(@"
SELECT Repair.*
FROM Repair INNER JOIN
(SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
User ON ServiceUser.UserCk = User.UserPk
WHERE (User.UserPk = @id)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Repair.ServiceFk = derivedtbl_2.ServicePk");
            repairQuery.Parameters.AddWithValue("@id", user.Id);
            return GenerateListWithFunction(GetData(repairQuery), CreateRepair);
        }

        public List<Cleaning> GetAllCleansFromUser(User user)
        {
            var cleanQuery = new MySqlCommand(@"
SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
User ON ServiceUser.UserCk = User.UserPk
WHERE (User.UserPk = @id)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk) AS derivedtbl_2 ON Repair.ServiceFk = derivedtbl_2.ServicePk");
            cleanQuery.Parameters.AddWithValue("@id", user.Id);
            return GenerateListWithFunction(GetData(cleanQuery), CreateCleaning);
        }

        public List<Repair> GetAllRepairsWithoutUsers()
        {
            return GenerateListWithFunction(GetData(new MySqlCommand(@"SELECT Repair.*
FROM Repair INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Repair.ServiceFk = derivedtbl_1.ServicePk")), CreateRepair);
        }

        public List<Cleaning> GetAllCleansWithoutUsers()
        {
            return GenerateListWithFunction(GetData(new MySqlCommand(@"SELECT Clean.*
FROM Clean INNER JOIN
(SELECT Service.ServicePk
FROM ServiceUser RIGHT OUTER JOIN
Service ON ServiceUser.ServiceCk = Service.ServicePk
WHERE (ServiceUser.UserCk IS NULL)) AS derivedtbl_1 ON Clean.ServiceFk = derivedtbl_1.ServicePk")), CreateCleaning);
        }

        public Cleaning AddCleaning(Cleaning cleaning)
        {
            var serviceQuery = new MySqlCommand(@"INSERT INTO Service (StartDate, EndDate, TramFk) VALUES (@startdate, @enddate, @tramfk); SELECT SCOPE_IDENTITY();");
            serviceQuery.Parameters.AddWithValue("@startdate", cleaning.StartDate);
            if (cleaning.EndDate == DateTime.MinValue) serviceQuery.Parameters.AddWithValue("@enddate", DBNull.Value);
            else serviceQuery.Parameters.AddWithValue("@enddate", cleaning.EndDate);
            serviceQuery.Parameters.AddWithValue("@tramfk", cleaning.TramId);

            var data = GetData(serviceQuery);

            var cleaningQuery = new MySqlCommand(@"INSERT INTO Cleaning (ServiceFk, Size, Remarks) VALUES (@id, @size, @remarks)");
            cleaningQuery.Parameters.AddWithValue("@id", data.Rows[0].ItemArray[0]);
            cleaningQuery.Parameters.AddWithValue("@size", (int)cleaning.Size);
            cleaningQuery.Parameters.AddWithValue("@remarks", cleaning.Comments ?? "");
            GetData(cleaningQuery);

            SetUsersToServices(cleaning.AssignedUsers, cleaning);

            cleaning.SetId(Convert.ToInt32((decimal)data.Rows[0].ItemArray[0]));
            return cleaning;
        }

        public Repair AddRepair(Repair repair)
        {
            var serviceQuery = new MySqlCommand(@"INSERT INTO Service (StartDate, EndDate, TramFk) VALUES (@startdate, @enddate, @tramfk); SELECT SCOPE_IDENTITY();");
            serviceQuery.Parameters.AddWithValue("@startdate", repair.StartDate);
            if (repair.EndDate == DateTime.MinValue) serviceQuery.Parameters.AddWithValue("@enddate", DBNull.Value);
            else serviceQuery.Parameters.AddWithValue("@enddate", repair.EndDate);
            serviceQuery.Parameters.AddWithValue("@tramfk", repair.TramId);

            var data = GetData(serviceQuery);

            var repairQuery = new MySqlCommand(@"INSERT INTO Repair (ServiceFk, Solution, Defect, Type) VALUES (@id, @solution, @defect, @type)");
            repairQuery.Parameters.AddWithValue("@id", data.Rows[0].ItemArray[0]);
            repairQuery.Parameters.AddWithValue("@solution", repair.Solution ?? "");
            repairQuery.Parameters.AddWithValue("@defect", repair.Defect ?? "");
            repairQuery.Parameters.AddWithValue("@type", (int)repair.Type);
            GetData(repairQuery);

            SetUsersToServices(repair.AssignedUsers, repair);

            repair.SetId(Convert.ToInt32((decimal)data.Rows[0].ItemArray[0]));
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
                        repairQuery.Parameters.AddWithValue("@solution", repair.Solution ?? "");
                        repairQuery.Parameters.AddWithValue("@defect", repair.Defect ?? "");
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
                        cleaningQuery.Parameters.AddWithValue("@remarks", cleaning.Comments ?? "");
                        break;
                    }
            }
            var query = new MySqlCommand("UPDATE Service SET StartDate = @startdate, EndDate = @enddate, TramFk = @tramfk WHERE ServicePk = @id");
            query.Parameters.AddWithValue("@startdate", service.StartDate);
            if (service.EndDate == DateTime.MinValue) query.Parameters.AddWithValue("@enddate", DBNull.Value);
            else query.Parameters.AddWithValue("@enddate", service.EndDate);
            query.Parameters.AddWithValue("@tramfk", service.TramId);
            GetData(query);
            SetUsersToServices(service.AssignedUsers, service);
        }

        public void DeleteService(Service service)
        {
            var query = new MySqlCommand("DELETE FROM Service WHERE ServicePk = @id; DELETE FROM Clean WHERE ServiceFk = @id; DELETE FROM Repair WHERE ServiceFk = @id");
            query.Parameters.AddWithValue("@id", service.Id);
            GetData(query);
        }

        private List<User> GetUsersInServiceById(int serviceId)
        {
            var command = new MySqlCommand(@"SELECT User.*, Service.ServicePk
FROM Service INNER JOIN
ServiceUser ON Service.ServicePk = ServiceUser.ServiceCk INNER JOIN
User ON ServiceUser.UserCk = User.UserPk
WHERE (Service.ServicePk = @id)");
            command.Parameters.AddWithValue("@id", serviceId);
            return GenerateListWithFunction(GetData(command), CreateUser);
        }

        private static void SetUsersToServices(List<User> users, Service service)
        {
            if (users == null) return;
            var data = GetData(new MySqlCommand($"SELECT * FROM ServiceUser WHERE ServiceCk = {service.Id}"));
            foreach (DataRow dataRow in data.Rows)
            {
                if (users.All(x => x.Id != (int)dataRow.ItemArray[0]))
                {
                    GetData(new MySqlCommand($"DELETE FROM ServiceUser WHERE ServiceCk = {service.Id} AND UserCk = {(int)dataRow.ItemArray[0]}"));
                }
            }

            foreach (var user in users)
            {
                if (GetData(new MySqlCommand($"SELECT * FROM ServiceUser WHERE UserCk = {user.Id} AND ServiceCk = {service.Id}")).Rows.Count < 1)
                {
                    GetData(new MySqlCommand($"INSERT INTO ServiceUser (ServiceCk, UserCk) VALUES ({service.Id},{user.Id})"));
                }
            }
        }
        #endregion

        #region createFunctions

        private User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //name gebr wachtw email rol 
            string parentUserString = array[6] == DBNull.Value ? "" : GetUser((int)array[6]).Username;
            return new User((int)array[0], (string)array[1], (string)array[2], (string)array[4], (string)array[3], (Role)(int)array[5], parentUserString);
        }

        private Tram CreateTram(DataRow row)
        {
            //Pk, Line, Status, Driver, Model, Remise, Location, Depart
            var array = row.ItemArray;
            var id = (int)array[0];
            var line = (int)array[1];
            var status = (TramStatus)array[2];
            var driver = GetUser((int)array[3]);
            var model = (Model)array[4];
            //var remise = (int)array[5];
            var location = (TramLocation)array[6];
            DateTime? depart = null;
            if (array[7] != DBNull.Value) depart = (DateTime)array[7];

            return new Tram(id, status, line, driver, model, location, depart);
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

        private Cleaning CreateCleaning(DataRow row)
        {
            var array = row.ItemArray;
            var service = GetData(new MySqlCommand($"SELECT * FROM Service WHERE ServicePk = {(int)array[0]}")).Rows[0].ItemArray;

            var id = (int)service[0];
            var startDate = (DateTime)service[1];
            var endDate = service[2] == DBNull.Value ? DateTime.MinValue : (DateTime)service[2];
            var tramId = (int)service[3];

            var comments = (string)array[1];
            var type = (CleaningSize)array[2];
            var users = GetUsersInServiceById((int)service[0]);

            return new Cleaning(id, startDate, endDate, type, comments, users, tramId);
        }

        private Repair CreateRepair(DataRow row)
        {
            var array = row.ItemArray;
            var service = GetData(new MySqlCommand($"SELECT * FROM Service WHERE ServicePk = {(int)array[0]}")).Rows[0].ItemArray;

            var id = (int)service[0];
            var startDate = (DateTime)service[1];
            var endDate = service[2] == DBNull.Value ? DateTime.MinValue : (DateTime)service[2];
            var tramId = (int)service[3];

            var solution = (string)array[1];
            var defect = (string)array[2];
            var type = (RepairType)array[3];
            var users = GetUsersInServiceById((int)service[0]);

            return new Repair(id, startDate, endDate, type, defect, solution, users, tramId);
        }

        #endregion

        /// <summary>
        /// Haal een datatable op vanuit een query.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Een Datatable van alle rows.</returns>
        private static DataTable GetData(MySqlCommand command)
        {
            var dataTable = new DataTable();
            using (var conn = new MySqlConnection(ConnectionString))
            {
                command.Connection = conn;
                var adapter = new MySqlDataAdapter(command);
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private static List<T> GenerateListWithFunction<T>(DataTable data, Func<DataRow, T> func)
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