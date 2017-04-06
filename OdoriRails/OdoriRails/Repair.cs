using System;
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

        public Repair(RepairType type, string defect, string solution, List<User> users)
        {
            Type = type;
            Defect = defect;
            Solution = solution;
            AssignedUsers = users;
        }

        public RepairType Type { get; private set; }
        public string Defect { get; private set; }
        public string Solution { get; private set; }
    }
}
