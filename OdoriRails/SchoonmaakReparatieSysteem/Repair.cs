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

        public RepairType Type { get; protected set; }
        public string Defect { get; protected set; }
        public string Solution { get; protected set; }

        public override void AddLog()
        {
            base.AddLog();
        }
        public override void EditLog()
        {
            // edits current entry of cleaning log
        }
    }
}
