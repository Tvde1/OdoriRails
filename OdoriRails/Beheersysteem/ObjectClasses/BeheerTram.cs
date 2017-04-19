using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace Beheersysteem.ObjectClasses
{
    class BeheerTram : Tram
    {
        public BeheerTram(int number, Model model) : base(number, model)
        { }

        public void EditTramStatus(TramStatus tramStatus)
        {
            Status = tramStatus;
        }

        public void EditTramLocation(TramLocation tramLocation)
        {
            Location = tramLocation;
        }

        public void EditTramDepartureTime(DateTime? departureTime)
        {
            DepartureTime = departureTime;
        }
    }
}
