using System;
using System.Collections.Generic;

namespace OdoriRails.BaseClasses
{
    public abstract class Service
    {
        public int Id { get; private set; }
        public List<User> AssignedUsers { get; }  
        public DateTime StartDate { get; private set; }
        public DateTime? EndDate { get; set; }
        public int TramId { get; private set; }

        protected Service(int? id, List<User> assignedUsers, DateTime startDate, DateTime? endDate, int? tramId)
        {
            Id = id ?? -1;
            AssignedUsers = assignedUsers;
            StartDate = startDate;
            EndDate = endDate ?? DateTime.MinValue;
            TramId = tramId ?? -1;
        }

        protected Service(List<User> assignedUsers, DateTime startDate, DateTime? endDate, int tramId)
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