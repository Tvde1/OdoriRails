using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beheersysteem
{
    class Sector
    {
        Tram tram;
        public SectorStatus status { get; private set; }
        public int sectorNumber { get; private set; }

        public Sector()
        {
            //Constuctor van Sector
        }

        public void LockSector()
        {
            //Verandert de status van sector naar locked
        }

        public void OpenSector()
        {
            //Verandert de status van sector naar open
        }

        public void AddTram(Tram tram)
        {
            //Voegt een tram aan de sector toe
        }

        public void RemoveTram()
        {
            //Verwijderen van een tram die op een sector staat
        }
    }
}
