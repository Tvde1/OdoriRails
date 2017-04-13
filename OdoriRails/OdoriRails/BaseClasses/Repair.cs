using System;
using System.Collections.Generic;

namespace OdoriRails
{
    public enum RepairType
    {
        Maintenance,
        Repair
    }

    public class Repair : Service
    {
        public RepairType Type { get; protected set; }
        public string Defect { get; protected set; }
        public string Solution { get; protected set; }

        public Repair(DateTime startDate, DateTime endDate, RepairType type, string defect, string solution, List<User> users, int tramId) : base(users, startDate, endDate, tramId)
        {
            Type = type;
            Defect = defect;
            Solution = solution;
        }

        public Repair(int id, DateTime startDate, DateTime endDate, RepairType type, string defect, string solution, List<User> users, int tramId) : base(id, users, startDate, endDate, tramId)
        {
            Type = type;
            Defect = defect;
            Solution = solution;
        }
    }
}
