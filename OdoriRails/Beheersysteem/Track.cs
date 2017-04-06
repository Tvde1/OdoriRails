using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails;

namespace Beheersysteem
{
    class Track : OdoriRails.Track
    {
        public List<Sector> Sectors = new List<Sector>();

        public Track(int tracknumber) : base(tracknumber)
        { }

        /// <summary>
        /// Zet elke sectoren's status op 'Locked'
        /// </summary>
        public void LockTrack()
        {
            foreach (var sector in Sectors)
            {
                sector.Lock();
            }
        }

        /// <summary>
        /// Zet alle sectoren's status op 'Open'.
        /// </summary>
        public void UnlockTrack()
        {
            foreach (var sector in Sectors)
            {
                sector.Unlock();
            }
        }

        /// <summary>
        /// Voegt een nieuwe sector toe aan het track.
        /// </summary>
        /// <param name="sector"></param>
        public void AddSector(Sector sector)
        {
            Sectors.Add(sector);
        }

        /// <summary>
        /// Haalt sector n weg uit de track.
        /// </summary>
        /// <param name="sectorNumber"></param>
        public void RemoveSector(int sectorNumber)
        {

        }
    }
}
