using System.Collections.Generic;

namespace OdoriRails.BaseClasses
{
    public class Track
    {
        public List<Sector> Sectors { get; } = new List<Sector>();

        public int Number { get; private set; }
        public List<Model> AcceptedModels { get; protected set; }

        /// <summary>
        /// Constructor, requires number.
        /// </summary>
        /// <param name="trackNumber"></param>
        public Track(int trackNumber)
        {
            Number = trackNumber;
        }

        /// <summary>
        /// Voegt een nieuwe sector toe aan het track.
        /// </summary>
        /// <param name="sector"></param>
        public void AddSector(Sector sector)
        {
            Sectors.Add(sector);
        }
    }
}