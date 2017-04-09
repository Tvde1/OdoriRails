using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    class Cleaning : Service
    {
        public enum CleaningSize
        {
            Big,
            Small
        }
        
        public Cleaning(int id, DateTime startDate, DateTime endDate, CleaningSize size, string comments, List<User> users) : base(id, startDate, endDate)
        {
            Size = size;
            Comments = comments;
            AssignedUsers = users;
        }

        public CleaningSize Size { get; protected set; }
        public string Comments { get; protected set; }
    }
}
