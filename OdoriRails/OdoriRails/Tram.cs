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
        /// <summary>
        /// Ophalen tramnummer
        /// </summary>
        public int Number { get; private set; }

        /// <summary>
        /// Ophalen Tramstatus
        /// </summary>
        public TramStatus Status { get; private set; }

        /// <summary>
        /// Get/Set lijn waar de tram opstaat
        /// </summary>
        public int Line { get; set; }

        /// <summary>
        /// Get/Set bestuurder van de tram
        /// </summary>
        public User Driver { get; set; }

        /// <summary>
        /// Ophalen model van de tram
        /// </summary>
        public Model Model { get; private set; }

        /// <summary>
        /// Aanmaken nieuwe tram met bestuurder
        /// </summary>
        /// <param name="number"></param>
        /// <param name="status"></param>
        /// <param name="line"></param>
        /// <param name="driver"></param>
        /// <param name="model"></param>
        public Tram(int number, TramStatus status, int line, User driver, Model model)
        {
            Number = number;
            Status = status;
            Line = line;
            Driver = driver;
            Model = model;
        }

        /// <summary>
        /// Minimale constructor tram zonder driver en line
        /// </summary>
        /// <param name="number"></param>
        /// <param name="model"></param>
        public Tram(int number, Model model)
        {
            Number = number;
            Model = model;
            Status = TramStatus.Idle;
        }

    }
}