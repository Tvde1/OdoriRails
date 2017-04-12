using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    public abstract class Service
    {
        
        public List<User> AssignedUsers { get; protected set; }  
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }

        public Service(int day, int month, int year)
        {
            StartDate = new DateTime(day, month, year);
        }

        public virtual void AddLog()
        {
            // adds database entry of cleaning service log
        }

        public virtual void EditLog()
        {
            // edits a entry of log
        }
        private void DeleteLog(int logID)
        {
            // deletes log entry
        }
        private void AssignService(List<User> users)
        {
            // assigns service to users
        }
    }
}
