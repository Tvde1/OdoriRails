using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    class DatabaseTest
    {
        private string GetAdminName()
        {
            var admin = DatabaseAdapter.GetUser("Jan");
            return admin.Name;
        }
    }
}
