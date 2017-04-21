using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    public static class Database
    {
        public const string ConnectionString =@"Data Source=192.168.20.189;Initial Catalog=OdoriRails;User ID=sa;Password=OdoriRails123;";
        public static DataTable GetData(SqlCommand command)
        {
            var dataTable = new DataTable();
            using (var conn = new SqlConnection(ConnectionString))
            {
                command.Connection = conn;
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        public static List<T> GenerateListWithFunction<T>(DataTable data, Func<DataRow, T> func)
        {
            var returnList = new List<T>();
            foreach (DataRow row in data.Rows)
            {
                returnList.Add(func(row));
            }
            return returnList;
        }

        public static User GetUser(int id)
        {
            return CreateUser(GetData(new SqlCommand($"SELECT * FROM [User] WHERE UserPk = {id}")).Rows[0]);
        }

        public static User GetUser(string userName)
        {
            var command = new SqlCommand("SELECT * FROM [User] WHERE UserPk = @id");
            command.Parameters.AddWithValue("@id", GetUserId(userName));
            return CreateUser(GetData(command).Rows[0]);
        }

        public static int GetUserId(string username)
        {
            var query = new SqlCommand("SELECT UserPk FROM [User] WHERE Username = @username");
            query.Parameters.AddWithValue("@username", username);
            return (int)GetData(query).Rows[0].ItemArray[0];
        }

        public static User CreateUser(DataRow row)
        {
            var array = row.ItemArray;
            //name gebr wachtw email rol 
            string parentUserString = array[6] == DBNull.Value ? "" : GetUser((int)array[6]).Username;
            return new User((int)array[0], (string)array[1], (string)array[2], (string)array[4], (string)array[3], (Role)(int)array[5], parentUserString);
        }

        public static Tram GetTram(int id)
        {
            return CreateTram(GetData(new SqlCommand($"SELECT * FROM Tram WHERE TramPk = {id}")).Rows[0]);
        }

        public static Tram CreateTram(DataRow row)
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

        public static Sector CreateSector(DataRow row)
        {
            var array = row.ItemArray;
            Tram tram = null;
            if (String.IsNullOrEmpty((string)array[3]) && array[3] != DBNull.Value) tram = GetTram((int)array[3]);

            return new Sector((int)array[0], (int)array[2], (SectorStatus)array[1], tram);
        }

        public static Track CreateTrack(DataRow row)
        {
            var array = row.ItemArray;
            return new Track((int)array[0], (int)array[1], (TrackType)array[2]);
        }
    }
}
