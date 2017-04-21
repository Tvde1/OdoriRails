using System.Collections.Generic;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL.Subclasses
{
    public interface ITramContext
    {
        /// <summary>
        /// Get een tram via het Id.
        /// </summary>
        /// <param name="tramId"></param>
        /// <returns></returns>
        Tram GetTram(int tramId);

        /// <summary>
        /// Voegt een nieuwe tram toe aan de database.
        /// </summary>
        /// <param name="tram">Het tram object.</param>
        void AddTram(Tram tram);

        /// <summary>
        /// Verwijder een tram uit de database.
        /// </summary>
        /// <param name="tram">Het tram object.</param>
        void RemoveTram(Tram tram);

        /// <summary>
        /// Een lijst van alle trams.
        /// </summary>
        /// <returns></returns>
        List<Tram> GetAllTrams();

        /// <summary>
        /// Haalt de tram op van de user die het bestuurt (kan null zijn).
        /// </summary>
        /// <param name="user">De bestuurder.</param>
        /// <returns></returns>
        Tram GetTramByDriver(User user);

        /// <summary>
        /// Edit deze tram in de database.
        /// </summary>
        /// <param name="tram"></param>
        void EditTram(Tram tram);

        /// <summary>
        /// Haalt alle trams op met status:
        /// </summary>
        /// <param name="tramStatus">De status</param>
        /// <returns></returns>
        List<Tram> GetAllTramsWithStatus(TramStatus tramStatus);

        /// <summary>
        /// Haalt alle trams op met locatie:
        /// </summary>
        /// <param name="tramLocation">De locatie.</param>
        /// <returns></returns>
        List<Tram> GetAllTramsWithLocation(TramLocation tramLocation);
    }
}
