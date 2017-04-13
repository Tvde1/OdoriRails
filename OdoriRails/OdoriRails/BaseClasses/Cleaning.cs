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
        public CleaningSize Size { get; protected set; }
        public string Comments { get; protected set; }

       public Cleaning(int id, DateTime startDate, DateTime endDate, CleaningSize size, string comments, List<User> users, int tramId) : base(id, users, startDate, endDate, tramId)
        {
            Size = size;
            Comments = comments;
        }

        public Cleaning(DateTime startDate, DateTime endDate, CleaningSize size, string comments, List<User> users, int tramId) : base(users, startDate, endDate, tramId)
        {
            Size = size;
            Comments = comments;
        }
    }
}
