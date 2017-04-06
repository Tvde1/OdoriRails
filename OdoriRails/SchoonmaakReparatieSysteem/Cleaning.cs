using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoonmaakReparatieSysteem
{
    class Cleaning : Service
    {
        private string comment;

        public Cleaning(int day, int month, int year, string cmt, string stype) : base(day, month, year)
        {
            comment = cmt;
            //cleaningType = stype;
        }

        public override void AddLog()
        {
           // adds entry of this instance of service

        }
        public override void EditLog()
        {
            // edits current entry of cleaning log
        }
        
    }
}
