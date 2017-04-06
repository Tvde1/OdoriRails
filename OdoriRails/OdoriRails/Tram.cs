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
        public int Number { get; protected set; }
        public TramStatus Status { get; protected set; }
        public int Line { get; protected set; }
        public User Driver { get; protected set; }
        public Model Model { get; protected set; }

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