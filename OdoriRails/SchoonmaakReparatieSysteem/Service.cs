using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoonmaakReparatieSysteem
{
    enum ServiceType
    {
        SMALL,
        LARGE,
        CUSTOM
    }
    abstract class Service
    {
        private DateTime startDate;
        private DateTime endDate;
        private List<User> assignedWorkers;

        public Service(int day, int month, int year)
        {
            startDate = new DateTime(day, month, year);
        }
// adds database entry of cleaning service log
        public virtual void AddLog()
        {
            
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
