namespace OdoriRails.BaseClasses
{
    public enum SectorStatus
    {
        Open,
        Locked,
        Occupied
    }

    public class Sector
    {
        public int Number { get; protected set; }
        public SectorStatus Status { get; protected set; }
        public Tram OccupyingTram { get; protected set; }
        public int TrackNumber { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="number"></param>
        /// <param name="trackNumber"></param>
        /// <param name="status"></param>
        /// <param name="tram"></param>
        public Sector(int number, int trackNumber, SectorStatus status, Tram tram)
        {
            Number = number;
            Status = status;
            OccupyingTram = tram;
            TrackNumber = trackNumber;
        }

        /// <summary>
        /// Zet de status van de tram naar locked.
        /// </summary>
        public void Lock()
        {
            Status = SectorStatus.Locked;
        }

        /// <summary>
        /// Zet de status van de tram naar open.
        /// </summary>
        public void Unlock()
        {
            Status = SectorStatus.Open;
        }

        /// <summary>
        /// Zet de status van de tram naar occupied.
        /// </summary>
        public void Occupy()
        {
            if (Status == SectorStatus.Locked) //throw new InvalidOperationException("Can't occupy a locked sector. Please unlock it first.");
            Status = SectorStatus.Occupied;
        }

        /// <summary>
        /// Zet de status van de tram naar open.
        /// </summary>
        public void UnOccupy()
        {
            if (Status != SectorStatus.Occupied) //throw new InvalidOperationException("Can't unoccupy a sector with a state other than Occupied. Current state is " + Status + ".");
            Status = SectorStatus.Open;
        }

        /// <summary>
        /// Zet de occupying tram. Gebruik `null` om de tram leeg te maken.
        /// </summary>
        /// <param name="tram"></param>
        public void SetOccupyingTram(Tram tram)
        {
            OccupyingTram = tram;
        }
    }
}
