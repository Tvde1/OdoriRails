using System.Collections.Generic;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace OdoriRails.DAL.Repository
{
    class LogisticRepository
    {
        private readonly IUserContext _userContext = new UserContext();
        private readonly ITramContext _tramContext = new TramContext();
        private  readonly ITrackSectorContext _trackSectorContext = new TrackSectorContext();

        /// <summary>
        /// Voegt een nieuwe tram toe aan de database.
        /// </summary>
        /// <param name="tram"></param>
        void AddTram(Tram tram)
        {
            _tramContext.AddTram(tram);
        }

        /// <summary>
        /// Verwijdert een Tram uit de database.
        /// </summary>
        /// <param name="tram"></param>
        void RemoveTram(Tram tram)
        {
            _tramContext.RemoveTram(tram);
        }

        /// <summary>
        /// Haal een Tram op aan de hand van de tramid.
        /// </summary>
        /// <param name="id"></param>
        Tram GetTram(int id)
        {
            return _tramContext.GetTram(id);
        }

        /// <summary>
        /// Haal alle trams op.
        /// </summary>
        List<Tram> GetAllTrams()
        {
            return _tramContext.GetAllTrams();
        }

        /// <summary>
        /// Haal de tram op waar deze meneer in rijdt.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        Tram GetTramByDriver(User driver)
        {
            return _tramContext.GetTramByDriver(driver);
        }

        /// <summary>
        /// Gets alle trams met een bepaalde status.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        List<Tram> GetAllTramsWithStatus(TramStatus status)
        {
            return _tramContext.GetAllTramsWithStatus(status);
        }

        /// <summary>
        /// Haal trams op met locatie.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        List<Tram> GetAllTramsWithLocation(TramLocation location)
        {
            return _tramContext.GetAllTramsWithLocation(location);
        }

        /// <summary>
        /// Haalt alle tracks, sectoren en trams op sectoren op.
        /// </summary>
        /// <returns></returns>
        List<Track> GetTracksAndSectors()
        {
            return _trackSectorContext.GetTracksAndSectors();
        }

        /// <summary>
        /// Haal een User op aan de hand van de username.
        /// </summary>
        /// <param name="userName"></param>
        User GetUser(string userName)
        {
            return _userContext.GetUser(userName);
        }
    }
}
