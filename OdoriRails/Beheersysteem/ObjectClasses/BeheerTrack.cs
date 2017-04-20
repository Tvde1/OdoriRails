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

        public BeheerTrack(int number, int line, TrackType type) : base(number, line, type)
        {
        }

    }
}
