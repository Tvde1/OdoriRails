using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace OdoriRails.DAL
{
    public static class Database
    {
        private const string ConnectionString = @"Data Source=192.168.20.189;Initial Catalog=OdoriRails;User ID=sa;Password=OdoriRails123;";

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
    }
}