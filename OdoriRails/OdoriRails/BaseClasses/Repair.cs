﻿using System;
using System.Collections.Generic;

namespace OdoriRails.BaseClasses
{
    public enum RepairType
    {
        Maintenance,
        Repair
    }

    public class Repair : Service
    {
        public RepairType Type { get; }
        public string Defect { get; }
        public string Solution { get; }

        public Repair(DateTime startDate, DateTime? endDate, RepairType type, string defect, string solution, List<User> users, int tramId) : base(users, startDate, endDate, tramId)
        {
            Type = type;
            Defect = defect;
            Solution = solution;
        }

        public Repair(int id, DateTime startDate, DateTime? endDate, RepairType type, string defect, string solution, List<User> users, int tramId) : base(id, users, startDate, endDate, tramId)
        {
            Type = type;
            Defect = defect;
            Solution = solution;
        }

        public Repair(int tramId, string defect) : base(null, null, DateTime.Now, null, tramId)
        {
            Defect = defect;
            Type = RepairType.Repair;
        }
    }
}
