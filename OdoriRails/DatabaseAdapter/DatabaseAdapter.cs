using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails;


namespace DatabaseAdapter
{
    public class DatabaseAdapter
    {
        private string _connectionString = @"";

        #region users
        /// <summary>
        /// Voegt een User toe aan de database.
        /// </summary>
        /// <param name="user"></param>
        public void Adduser(User user)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Verwijdert een User uit de database.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Haal een User op aan de hand van de userid.
        /// </summary>
        /// <param name="id"></param>
        public User GetUser(int id)
        {
            var command = "SELECT TOP(1) * FROM [User]";
            var table = GetData(command);
            var array = table.Rows[0].ItemArray;

            return new User((string)array[0], (string)array[1], (Role)(int)array[2]);
        }

        /// <summary>
        /// Haal een User op aan de hand van de naam.
        /// </summary>
        /// <param name="naam"></param>
        public User GetUser(string naam)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region trams

        #endregion
        private DataTable GetData(string query)
        {
            var dataTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(query, _connectionString);
            adapter.Fill(dataTable);
            return dataTable;
        }
    }
}