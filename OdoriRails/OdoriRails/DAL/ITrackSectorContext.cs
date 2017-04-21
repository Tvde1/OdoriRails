using System.Collections.Generic;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    public interface ITrackSectorContext
    {
        List<Track> GetTracksAndSectors();
    }
}
