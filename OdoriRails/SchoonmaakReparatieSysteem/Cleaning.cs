using System;
using System.Collections.Generic;

namespace OdoriRails
{
    public enum CleaningSize
    {
        Big,
        Small
    }

    class Cleaning : Service
    {
       
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
