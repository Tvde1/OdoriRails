using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    public abstract class Service
    {
        public int ID { get; protected set; }
        public List<User> AssignedUsers { get; protected set; }  
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }

        public Service(int id, DateTime startDate, DateTime endDate)
        {
            ID = id;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}