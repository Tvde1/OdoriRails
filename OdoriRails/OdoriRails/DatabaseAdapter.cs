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
    public static class DatabaseAdapter
    {
        private static string _connectionString = @"";
        private static int _remiseNumber = 0;

        #region user
        /// <summary>
        /// Voegt een User toe aan de database.
        /// </summary>
        /// <param name="user"></param>
        public static void Adduser(User user)
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

        /// <summary>
        /// Verwijdert een User uit de database.
        /// </summary>
        /// <param name="user"></param>
        public static void RemoveUser(User user)
        {
            if (user.Username == null || user.Username == "") throw new Exception("The User to delete does not have a username.");
            var query = new SqlCommand("DELETE FROM [User] WHERE UserPk = " + GetUserId(user.Username));
        }

        /// <summary>
        /// Haal een User op aan de hand van de userid.
        /// </summary>
        /// <param name="id"></param>
        public static User GetUser(int id)
        {
            var command = new SqlCommand($"SELECT * FROM [User] WHERE UserPk = {id}");
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        /// <summary>
        /// Haal een User op aan de hand van de naam.
        /// </summary>
        /// <param name="userName"></param>
        public static User GetUser(string userName)
        {
            var command = new SqlCommand("SELECT * FROM [User] WHERE UserPk = {id}");
            command.Parameters.AddWithValue("{id}", GetUserId(userName));
            var table = GetData(command);
            return CreateUser(table.Rows[0]);
        }

        private static User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            return new User((string)array[0], (string)array[1], (Role)(int)array[2]);
        }
        #endregion

        #region tram
        /// <summary>
        /// Voegt een nieuwe tram toe aan de database.
        /// </summary>
        /// <param name="tram"></param>
        public static void AddTram(Tram tram)
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

        /// <summary>
        /// Verwijdert een Tram uit de database.
        /// </summary>
        /// <param name="tram"></param>
        public static void RemoveTram(Tram tram)
        {
            var query = new SqlCommand($"DELETE FROM Tram WHERE TramPk = {tram.Number}");
        }

        /// <summary>
        /// Haal een Tram op aan de hand van de tramid.
        /// </summary>
        /// <param name="id"></param>
        public static Tram GetTram(int id)
        {
            var command = new SqlCommand($"SELECT * FROM Tram WHERE TramPk = {id}");
            var table = GetData(command);
            return CreateTram(table.Rows[0]);
        }

        /// <summary>
        /// Een lijst met trams die op een track staan.
        /// </summary>
        /// <returns></returns>
        public static List<Tram> GetAllTramsOnTrack()
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

        private static Tram CreateTram(DataRow row)
        {
            var array = row.ItemArray;
            return new Tram((int)array[0], (TramStatus)array[2], (int)array[1], GetUser((int)array[4]), (Model)array[3]);
        }
        #endregion

        #region track and sector

        /// <summary>
        /// Haalt alle tracks, sectoren en trams op sectoren op.
        /// </summary>
        /// <returns></returns>
        public static List<Track> GetTracksAndSectors()
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

        private static Sector CreateSector(DataRow row)
        {
            var array = row.ItemArray;
            Tram tram = null;
            if (array[3] != null) tram = GetTram((int)array[3]);

            return new Sector((int)array[0], (int)array[2], (SectorStatus)array[1], tram);
        }

        private static Track CreateTrack(DataRow row)
        {
            var array = row.ItemArray;
            return new Track((int)array[0]);
        }
        #endregion

        /// <summary>
        /// Haal een datatable op vanuit een query.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>Een Datatable van alle rows.</returns>
        private static DataTable GetData(SqlCommand command)
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
        private static int GetUserId(string username)
        {
            var query = new SqlCommand("SELECT UserPk FROM [User] WHERE Username = {username}");
            query.Parameters.AddWithValue("{username}", username);
            var table = GetData(query);
            return (int)table.Rows[0][0];
        }
    }
}