using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OdoriRails
{
    /// <summary>
    /// De DAL-Klasse
    /// </summary>
    public class MSSQLDatabaseContext : IDatabaseConnector
    {
        private string _connectionString = @"Server=(LocalDB)\MSSQLLocalDB;Database=OdoriRailsDatabase;Trusted_Connection=True;";
        //Deze werkt als Microsoft SQL Server Management Studio geinstalleerd is.
        private int _remiseNumber = 0;

        //public MSSQLDatabaseContext()

        #region user
        public void AddUser(User user)
        {

            var query = new SqlCommand("INSERT INTO [User] (Username,Password,Email,Name,Email,Role,ManagedBy), VALUES({name},{pass},{email},{role},{managedBy})");
            query.Parameters.AddWithValue("{name}", user.Username);
            query.Parameters.AddWithValue("{pass}", user.Password);
            query.Parameters.AddWithValue("{email}", user.Email);
            query.Parameters.AddWithValue("{role}", (int)user.Role);


            if (user.ManagerUsername == null) query.Parameters.AddWithValue("{managedBy}", null);
            else query.Parameters.AddWithValue("{managedBy}", GetUserId(user.ManagerUsername));

            GetData(query);
        }

        public void RemoveUser(User user)
        {
            if (user.Username == null || user.Username == "") throw new Exception("The User to delete does not have a username.");
            var query = new SqlCommand("DELETE FROM [User] WHERE UserPk = " + GetUserId(user.Username));
        }

        public User GetUser(int id)
        {
            var command = new SqlCommand($"SELECT * FROM [User] WHERE UserPk = {id}");
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
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
            var returnList = new List<User>();
            foreach (DataRow row in data.Rows)
            {
                returnList.Add(CreateUser(row));
            }
            return returnList;
        }

        private User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //name gebr usern wachtw rol 
            string parentUserString = array[6] == DBNull.Value ? "" : GetUser((string)array[6]).Username;
            return new User((string)array[1], (string)array[2], (string)array[3], (string)array[4], (Role)(int)array[5], parentUserString);
        }
        #endregion

        #region tram
        public void AddTram(Tram tram)
        {
            var query = new SqlCommand("INSERT INTO [Tram] (TramPk,Line,Status,ModelFk,DriverFk), VALUES({id},{line},{status},{model},{driver})");
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
            var query = new SqlCommand($"DELETE FROM Tram WHERE TramPk = {tram.Number}");
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

            List<Tram> returnList = new List<Tram>();
            foreach (DataRow row in data.Rows)
            {
                returnList.Add(CreateTram(row));
            }
            return returnList;
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
            //var tramList = GetAllTramsOnTrack();

            var sectorList = new List<Sector>();
            foreach (DataRow row in sectorData.Rows)
            {
                var array = row.ItemArray;
                Sector tempSector = CreateSector(row);

            }

            foreach (DataRow row in trackData.Rows)
            {
                var array = row.ItemArray;
                Track tempTrack = new Track((int)array[0]);
                sectorList.Where(x => x.TrackNumber == tempTrack.Number).ToList().ForEach(x => tempTrack.AddSector(x));
                returnList.Add(tempTrack);
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
            string text = @"SELECT Service.ServicePk
FROM Service INNER JOIN
(SELECT ServiceUser.ServiceCk
FROM ServiceUser INNER JOIN
[User] ON ServiceUser.UserCk = [User].UserPk
WHERE ([User].Username = @usrname)) AS derivedtbl_1 ON Service.ServicePk = derivedtbl_1.ServiceCk";
            var query = new SqlCommand(text);
            var data = GetData(query);


        }


        private Cleaning CreateCleaning(DataRow row)
        {

        }

        private Repair CreateRepair(DataRow row)
        {

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
            var dataTable = new DataTable();
            using (var conn = new SqlConnection(_connectionString))
            {
                command.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
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
            var query = new SqlCommand("SELECT UserPk FROM [User] WHERE Username = @username");
            query.Parameters.AddWithValue("@username", username);
            var table = GetData(query);
            return (int)table.Rows[0][0];
        }

        private List<T> GetList<T>(DataTable table)
        {

        }
    }
}