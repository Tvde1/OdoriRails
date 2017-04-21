using System.Collections.Generic;
using System.Windows.Forms;

namespace OdoriRails.BaseClasses
{
    public enum TrackType
    {
        Normal,
        Service,
        Exit
    }

    public class Track
    {
        public List<Sector> Sectors { get; } = new List<Sector>();

        public int Number { get; private set; }
        public int? Line { get; private set; }

        public TrackType Type { get; private set; }

        /// <summary>
        /// Voledige constructor.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="line"></param>
        /// <param name="type"></param>
        public Track(int number, int? line, TrackType type)
        {
            Number = number;
            Line = line;
            Type = type;
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