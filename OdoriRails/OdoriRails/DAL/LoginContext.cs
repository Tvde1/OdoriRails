using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails.DAL
{
    class LoginContext : ILoginContext
    {
        private const string ConnectionString = Database.ConnectionString;

        public bool ValidateUsername(string username)
        {
            var query = new SqlCommand("SELECT UserPk FROM [User] WHERE Username = @usrname");
            query.Parameters.AddWithValue("@usrname", username);
            return Database.GetData(query).Rows.Count != 0;
        }

        public bool MatchUsernameAndPassword(string username, string password)
        {
            var query = new SqlCommand("SELECT Password FROM [User] WHERE Username = @usrname");
            query.Parameters.AddWithValue("@usrname", username);

            var data = Database.GetData(query);
            if (data.Rows.Count > 0) return (string)data.Rows[0][0] == password;
            return false;
        }

    }
}
