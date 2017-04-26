using System.Collections.Generic;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL.Subclasses
{
    public interface ITrackSectorContext
    {
        /// <summary>
        /// Haalt alle tracks, sectoren en trams op.
        /// </summary>
        /// <returns></returns>
        List<Track> GetTracksAndSectors();

        void AddTrack(Track track);

        void AddSector(Sector sector, Track track);

        /// <summary>
        /// Updated de track in de database met de nieuwe informatie.
        /// </summary>
        void EditTrack(Track track);

        /// <summary>
        /// Updated de sector in de database met de nieuwe informatie.
        /// </summary>
        void EditSector(Sector sector);

        void WipeTramsFromSectors();

        void WipeTramFromSectorByTramId(int id);
    }
}
