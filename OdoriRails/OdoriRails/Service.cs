using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    abstract class Service
    {
        public List<User> AssignedUsers { get; protected set; }  
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
    }
}
