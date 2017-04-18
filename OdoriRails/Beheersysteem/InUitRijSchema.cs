using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beheersysteem.ObjectClasses
{
    public enum Status
    {
        inDienst,
        binnen
    }

    class InUitRijSchema
    {
        //TODO string van tijden naar datetime omzetten
        public string UitRijTijd { get; private set; }
        public string InRijTijd { get; private set; }
        public int Line { get; private set; }
        public int dw { get; private set; } //?
        public Status status { get; private set; }
        public int? wagenNr { get; set; }
        public int spoorNr { get; private set; }
        public string bijzonderheden { get; private set; }

        public InUitRijSchema(string _UitRijTijd, string _InRijTijd, int _line)
        {
            UitRijTijd = _UitRijTijd;
            InRijTijd = _UitRijTijd;
            Line = _line;
        }

    }
}
