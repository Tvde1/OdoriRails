using System;

namespace OdoriRails.BaseClasses
{
    public enum TramStatus
    {
        Idle,
        Cleaning,
        Maintenance,
        CleaningMaintenance,
        Defect
    }

    public enum TramLocation
    {
        Home,
        Away,
        Entering
    }

    public enum Model
    {
        Classic
    }

    public enum TramLocation
    {
        In,
        ComingIn,
        Out
    }

    public class Tram
    {
        /// <summary>
        /// Ophalen tramnummer
        /// </summary>
        public int Number { get; protected set; }

        /// <summary>
        /// Ophalen Tramstatus
        /// </summary>
        public TramStatus Status { get; protected set; }

        /// <summary>
        /// Ophalen TramLocation
        /// </summary>
        public TramLocation Location { get; protected set; }

        /// <summary>
        /// Get/Set lijn waar de tram opstaat
        /// </summary>
        public int Line { get; protected set; }

        /// <summary>
        /// Get/Set bestuurder van de tram
        /// </summary>
        public User Driver { get; protected set; }

        /// <summary>
        /// Ophalen model van de tram
        /// </summary>
        public Model Model { get; protected set; }

        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// De locatie van de tram.
        /// </summary>
        public TramLocation Location { get; private set; }

        /// <summary>
        /// Aanmaken nieuwe tram met bestuurder
        /// </summary>
        /// <param name="number"></param>
        /// <param name="status"></param>
        /// <param name="line"></param>
        /// <param name="driver"></param>
        /// <param name="model"></param>
        public Tram(int number, TramStatus status, int line, User driver, Model model, TramLocation location)
        {
            Number = number;
            Status = status;
            Line = line;
            Driver = driver;
            Model = model;
            Location = location;
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