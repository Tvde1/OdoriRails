using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace Beheersysteem
{
    class BeheerTram: Tram
    {
        public BeheerTram(int number, TramStatus status, int line, User driver, Model model) : base(number, status, line, driver, model)
        { }

        public BeheerTram(int number, Model model) : base(number, model)
        { }
    }
}
