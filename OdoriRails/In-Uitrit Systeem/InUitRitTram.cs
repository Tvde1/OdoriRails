using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public class InUitRitTram : Tram
    {
        public InUitRitTram(int number, TramStatus status, int line, User driver, Model model, TramLocation location, DateTime? departureTime): base(number, status, line, driver, model, location, departureTime)
        { }

        public static InUitRitTram ToTram(Tram tram)
        {
            return new InUitRitTram(tram.Number, tram.Status, tram.Line, tram.Driver, tram.Model, tram.Location, tram.DepartureTime);
        }

        public void EditTramStatus(TramStatus tramStatus)
        {
            Status = tramStatus;
        }

        public void EditTramLocation(TramLocation tramLocation)
        {
            Location = tramLocation;
        }

        public void ResetTramDeparture()
        {
            DepartureTime = null;
        }

        public void ResetTramTrackAndSector()
        {

        }
    }
}
