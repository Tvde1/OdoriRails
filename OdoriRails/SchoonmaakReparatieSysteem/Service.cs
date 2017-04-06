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

        public Service(int day, int month, int year)
        {
            startDate = new DateTime(day, month, year);
        }

        private void AddCleaningLog(List<string> userlist, string comment, ServiceType cleaningtype)
        {
            // adds database entry of cleaning service log
        }
        private void AddReparationLog(List<string> userlist, string deffect, string solution, ServiceType reparationtype)
        {
            // adds database entry of reparation service log
        }
        private void EditLog(List<string> userlist, string comment, ServiceType cleaningtype)
        {
            // edits current entry of cleaning log
        }
        private void EditLog(List<User> userlist, string deffect, string solution, ServiceType reparationtype)
        {
            // edits current entry of cleaning log
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
