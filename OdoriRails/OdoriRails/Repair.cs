using System;
using System.Collections.Generic;

namespace OdoriRails
{
    class Repair : Service
    {
        public enum RepairType
        {
            Maintenance,
            Repair
        }

        public Repair(int id, DateTime startDate, DateTime endDate, RepairType type, string defect, string solution, List<User> users, int tramId) : base(id, users, startDate, endDate, tramId)
        {
            Type = type;
            Defect = defect;
            Solution = solution;
        }

        public RepairType Type { get; protected set; }
        public string Defect { get; protected set; }
        public string Solution { get; protected set; }
    }
}
