using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    public enum SectorStatus
    {
        Open,
        Locked,
        Occupied
    }

    public class Sector
    {
        public int Number { get; private set; }
        public SectorStatus Status { get; set; }
        public Tram OccupyingTram { get; set; }
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
    }
}
