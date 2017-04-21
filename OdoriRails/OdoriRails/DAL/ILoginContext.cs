using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails.DAL
{
    public interface ILoginContext
    {
        bool ValidateUsername(string username);

        bool MatchUsernameAndPassword(string username, string password);
    }
}
