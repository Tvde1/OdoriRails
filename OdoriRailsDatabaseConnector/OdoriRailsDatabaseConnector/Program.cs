using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DatabaseConnector
{
    class Program
    {
        private string _connectionString = @"";

        #region users
        /// <summary>
        /// Voegt een User toe aan de database.
        /// </summary>
        /// <param name="user"></param>
        public void Adduser(User user)
        {

        }
        /// <summary>
        /// Verwijdert een User uit de database.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {

        }

        /// <summary>
        /// Haal een User op aan de hand van de userid.
        /// </summary>
        /// <param name="id"></param>
        public User GetUser(int id)
        {
            var command = "SELECT TOP(1) * FROM [User]";
            var table = GetData(command);

            var x = table.Rows[0].ItemArray;
            int y = (int)x[0];

            return null;

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
