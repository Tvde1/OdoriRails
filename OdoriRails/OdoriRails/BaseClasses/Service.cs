using System;
using System.Collections.Generic;

namespace OdoriRails
{
    public abstract class Service
    {
        public int Id { get; protected set; }
        public List<User> AssignedUsers { get; protected set; }  
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public int TramId { get; protected set; }

        protected Service(int? id, List<User> assignedUsers, DateTime startDate, DateTime? endDate, int? tramId)
        {
            Id = id ?? -1;
            AssignedUsers = assignedUsers;
            StartDate = startDate;
            EndDate = endDate ?? DateTime.MinValue;
            TramId = tramId ?? -1;
        }

        protected Service(List<User> assignedUsers, DateTime startDate, DateTime endDate, int tramId)
        {
            AssignedUsers = assignedUsers;
            StartDate = startDate;
            EndDate = endDate;
            TramId = tramId;
        }

        public void SetId(int id)
        {
            Id = id;
        }
    }
}