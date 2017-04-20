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
        public InUitRitTram(int number, Model model) : base(number, model)
        { }

        public static InUitRitTram ConvertToInUitRitTram(Tram tram)
        {
            return new InUitRitTram(tram.Number, tram.Model);
        }

        public void EditTramStatus(TramStatus tramStatus)
        {
            Status = tramStatus;
        }

        public void EditTramLocation(TramLocation tramLocation)
        {
            Location = tramLocation;
        }
    }
}
