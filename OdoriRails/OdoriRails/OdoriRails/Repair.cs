﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    class Repair : Service
    {
        public enum RepairType
        {
            Maintenance,
            Repair
        }

        public Repair(int id, DateTime startDate, DateTime endDate, RepairType type, string defect, string solution, List<User> users) : base(id, startDate, endDate)
        {
            Type = type;
            Defect = defect;
            Solution = solution;
            AssignedUsers = users;
        }

        public RepairType Type { get; protected set; }
        public string Defect { get; protected set; }
        public string Solution { get; protected set; }
    }
}