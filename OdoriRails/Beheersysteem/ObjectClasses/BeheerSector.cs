using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;
using System.Windows.Forms;

namespace Beheersysteem
{
    class BeheerSector : Sector
    {
        public BeheerSector(int number, int trackNumber, SectorStatus status, Tram tram) : base(number, trackNumber, status, tram)
        { }

        public static BeheerSector ToBeheerSector(Sector sector)
        {
            return new BeheerSector(sector.Number, sector.TrackNumber, sector.Status, sector.OccupyingTram);
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
        public void UnLock()
        {
            if (OccupyingTram == null)
            {
                Status = SectorStatus.Open;
            }
            else
            {
                Status = SectorStatus.Occupied;
            }
        }

        /// <summary>
        /// Zet de occupying tram. Gebruik `null` om de tram leeg te maken.
        /// </summary>
        /// <param name="tram"></param>
        public bool SetOccupyingTram(Tram tram)
        {
            if (Status == SectorStatus.Locked || Status == SectorStatus.Occupied) return false;
            else
            {
                Status = SectorStatus.Occupied;
                OccupyingTram = tram;
                return true;
            }

        }
    }
}
