using System;
using System.Collections.Generic;

namespace OdoriRails.BaseClasses
{
    public enum CleaningSize
    {
        Big,
        Small
    }

    public class Cleaning : Service
    {
        public CleaningSize Size { get; protected set; }
        public string Comments { get; protected set; }

       public Cleaning(int id, DateTime startDate, DateTime? endDate, CleaningSize size, string comments, List<User> users, int tramId) : base(id, users, startDate, endDate, tramId)
        {
            Size = size;
            Comments = comments;
        }

        public Cleaning(DateTime startDate, DateTime? endDate, CleaningSize size, string comments, List<User> users, int tramId) : base(users, startDate, endDate, tramId)
        {
            Size = size;
            Comments = comments;
        }

        public Cleaning(int tramId, string comments) : base(null, null, DateTime.Now, null, tramId)
        {
            Size = CleaningSize.Small;
            Comments = comments;
        }
    }
}
