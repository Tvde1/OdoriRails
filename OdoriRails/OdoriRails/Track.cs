using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    public class Track
    {
        public int Number { get; private set; }

        /// <summary>
        /// Constructor, requires number.
        /// </summary>
        /// <param name="trackNumber"></param>
        public Track(int trackNumber)
        {
            Number = trackNumber;
        }
<<<<<<< HEAD
=======

        /// <summary>
        /// Voegt een nieuwe sector toe aan het track.
        /// </summary>
        /// <param name="sector"></param>
        public void AddSector(Sector sector)
        {
            Sectors.Add(sector);
        }
>>>>>>> refs/remotes/origin/master
    }
}