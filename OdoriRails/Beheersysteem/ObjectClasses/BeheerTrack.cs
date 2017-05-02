using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;
using System.Windows.Forms;

namespace Beheersysteem
{
    class BeheerTrack : Track
    {
        public List<BeheerSector> BeheerSectors = new List<BeheerSector>();

        public BeheerTrack(int number, int? line, TrackType type, List<Sector> sectors) : base(number, line, type, sectors)
        { }

        public static BeheerTrack ToBeheerTrack(Track track)
        {
            return new BeheerTrack(track.Number, track.Line, track.Type, track.Sectors);
        }

        /// <summary>
        /// Zet elke sectoren's status op 'Locked'
        /// </summary>
        public void LockTrack()
        {
            bool occupied = false;
            foreach (BeheerSector sector in BeheerSectors)
            {
                if (sector.OccupyingTram != null)
                {
                    occupied = true;
                }
            }

            if (occupied == true)
            {
                DialogResult dialogResult = MessageBox.Show("There are trams on the location you are trying to lock, are you sure?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    occupied = false;
                }
            }

            if (occupied == false)
            {
                for (int i = 0; i < Sectors.Count; i++)
                {
                    BeheerSector beheerSector = Sectors[i] == null ? null : BeheerSector.ToBeheerSector(Sectors[i]);
                    beheerSector.Lock();
                    Sectors[i] = beheerSector;
                }
            }
        }

        /// <summary>
        /// Zet alle sectoren's status op 'Open'.
        /// </summary>
        public void UnlockTrack()
        {
            for (int i = 0; i < Sectors.Count; i++)
            {
                BeheerSector beheerSector = Sectors[i] == null ? null : BeheerSector.ToBeheerSector(Sectors[i]);
                beheerSector.UnLock();
                Sectors[i] = beheerSector;
            }
        }
    }
}
