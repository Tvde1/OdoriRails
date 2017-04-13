using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails;

namespace Beheersysteem
{
    class BeheerTrack : Track
    {
        public List<BeheerSector> BeheerSectors = new List<BeheerSector>();

        public BeheerTrack(int tracknumber) : base(tracknumber)
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
