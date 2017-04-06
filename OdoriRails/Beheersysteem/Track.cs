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
        public List<Sector> BeheerSectors = new List<Sector>();

        public Track(int tracknumber) : base(tracknumber)
        { }

        /// <summary>
        /// Zet elke sectoren's status op 'Locked'
        /// </summary>
        public void LockTrack()
        {
            foreach (var sector in BeheerSectors)
            {
                sector.Lock();
            }
        }

        /// <summary>
        /// Zet alle sectoren's status op 'Open'.
        /// </summary>
        public void UnlockTrack()
        {
            foreach (var sector in BeheerSectors)
            {
                sector.Unlock();
            }
        }
    }
}
