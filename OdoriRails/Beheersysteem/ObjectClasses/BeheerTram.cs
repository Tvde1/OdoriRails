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
        public BeheerTram(int number, TramStatus status, int line, User driver, Model model, TramLocation location, DateTime? departureTime) : base(number, status, line, driver, model, location, departureTime)
        {
            Number = number;
            Status = status;
            Line = line;
            Driver = driver;
            Model = model;
            Location = location;
            DepartureTime = departureTime;
        }

        public static BeheerTram ToBeheerTram(Tram tram)
        {
            return new BeheerTram(tram.Number, tram.Status, tram.Line, tram.Driver, tram.Model, tram.Location, tram.DepartureTime);
        }

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
