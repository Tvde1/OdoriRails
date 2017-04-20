using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    public interface ITrackSectorContext
    {
        List<Track> GetTracksAndSectors();
    }
}
