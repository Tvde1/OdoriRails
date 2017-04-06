using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoonmaakReparatieSysteem
{
    class Repair : Service
    {
        private string defect;
        private string solution;
        private ServiceType reparationType;

        public Repair(int day, int month, int year, string def, string sol, ServiceType stype) : base(day, month, year)
        {
            defect = def;
            solution = sol;
            reparationType = stype;
        }

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
