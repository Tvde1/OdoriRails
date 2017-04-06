namespace OdoriRails
{
    public enum TramStatus
    {
        Idle,
        InUse,
        Cleaning,
        Maintenance
    }

    public enum Model
    {
        Classic
    }

    public class Tram
    {
        public int Number { get; private set; }
        public TramStatus Status { get; private set; }
        public int Line { get; private set; }
        public User Driver { get; private set; }
        public Model Model { get; private set; }

        public Tram(int number, TramStatus status, int line, User driver, Model model)
        {
            Number = number;
            Status = status;
            Line = line;
            Driver = driver;
            Model = model;
        }


    }
}