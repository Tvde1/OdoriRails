using System;
using System.Collections.Generic;

namespace OdoriRails
{
    class Cleaning : Service
    {
        public enum CleaningSize
        {
            Big,
            Small
        }
        
        public Cleaning(int id, DateTime startDate, DateTime endDate, CleaningSize size, string comments, List<User> users, int tramId) : base(id,users, startDate, endDate, tramId)
        {
            Size = size;
            Comments = comments;
        }

        public CleaningSize Size { get; protected set; }
        public string Comments { get; protected set; }
    }
}
