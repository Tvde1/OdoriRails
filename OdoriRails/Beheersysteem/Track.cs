using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beheersysteem
{
    class Track
    {
        List<Sector> sectors = new List<Sector>();
        public int trackNumber { get; private set; }

        public Track()
        {
            //Constuctor van Track
        }
        
        public void LockTrack()
        {
            //Gaat door alle sectoren en verandert de status naar Closed
        }

        public void OpenTrack()
        {
            //Gaat door alle sectoren en verandert de status naar Open
        }

        public void AddSector(Sector sector)
        {
            //Toevoegen van een sector aan een track
        }

        public void RemoveSector(int sectorNumber)
        {
            //Verwijderen van een sector in een track
        }
    }
}
