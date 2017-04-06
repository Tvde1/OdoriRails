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

        public Cleaning(CleaningSize size, string comments, List<User> users)
        {
            Size = size;
            Comments = comments;
            AssignedUsers = users;
        }

        public CleaningSize Size { get; protected set; }
        public string Comments { get; protected set; }
    }
}
