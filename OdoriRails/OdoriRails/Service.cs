using System;
using System.Collections.Generic;

namespace OdoriRails
{
    public abstract class Service
    {
        public int ID { get; protected set; }
        public List<User> AssignedUsers { get; protected set; }  
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }

        protected Service(int id, DateTime startDate, DateTime endDate)
        {
            ID = id;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void deleteService(Service service) 
        {
            // TODO: GET DELETE METHOD HERE
        }
    }
}