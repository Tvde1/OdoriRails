using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace Beheersysteem
{
    class BeheerTrack : Track
    {
        public List<BeheerSector> BeheerSectors = new List<BeheerSector>();

        public BeheerTrack(int number, int? line, TrackType type, List<Sector> sectors) : base(number, line, type, sectors)
        {}

        public static BeheerTrack ToBeheerTrack(Track track)
        {
            return new BeheerTrack(track.Number, track.Line, track.Type, track.Sectors);
        }


        /// <summary>
        /// Zet elke sectoren's status op 'Locked'
        /// </summary>
        public void LockTrack()
        {
            foreach (var sector in Sectors)
            {
                BeheerSector beheerSector;
                beheerSector = sector == null ? null : BeheerSector.ToBeheerSector(sector);
                beheerSector.Lock();
            }
        }

        /// <summary>
        /// Zet alle sectoren's status op 'Open'.
        /// </summary>
        public void UnlockTrack()
        {
            foreach (var sector in Sectors)
            {
                BeheerSector beheerSector;
                beheerSector = sector == null ? null : BeheerSector.ToBeheerSector(sector);
                beheerSector.UnLock();
            }
        }
    }
}
