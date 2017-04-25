using System;

namespace Beheersysteem
{
    class InUitRijSchema
    {
        //TODO string van tijden naar datetime omzetten
        public DateTime ExitTime { get; private set; }
        public DateTime EntryTime { get; private set; }
        public int Line { get; private set; }
        public int dw { get; private set; } 
        public int? TramNumber { get; set; }
        public int TrackNumber { get; private set; }
        public string bijzonderheden { get; private set; }

        public InUitRijSchema(string _UitRijTijd, string _InRijTijd, int _line)
        {
            ExitTime = Convert.ToDateTime(_UitRijTijd);
            EntryTime = Convert.ToDateTime(_InRijTijd);
            Line = _line;
        }

        public override string ToString()
        {
            return ExitTime + " " + EntryTime + " " + Line + " " + TramNumber;
        }

    }
}
