using System;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public class InUitRitTram : Tram
    {
        public InUitRitTram(int number, TramStatus status, int line, User driver, TramModel model, TramLocation location, DateTime? departureTime): base(number, status, line, driver, model, location, departureTime)
        { }

        public static InUitRitTram ToInUitRitTram(Tram tram)
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
    }
}
