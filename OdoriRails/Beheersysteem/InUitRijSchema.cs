namespace Beheersysteem.ObjectClasses
{
    class InUitRijSchema
    {
        //TODO string van tijden naar datetime omzetten
        public string UitRijTijd { get; private set; }
        public string InRijTijd { get; private set; }
        public int Line { get; private set; }
        public int dw { get; private set; } 
        public int? TramNumber { get; set; }
        public int TrackNumber { get; private set; }
        public string bijzonderheden { get; private set; }

        public InUitRijSchema(string _UitRijTijd, string _InRijTijd, int _line)
        {
            UitRijTijd = _UitRijTijd;
            InRijTijd = _UitRijTijd;
            Line = _line;
        }

    }
}
