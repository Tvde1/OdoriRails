using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;

namespace OdoriRails.DAL
{
    interface ILogisticDatabaseAdapter
    {
        /// <summary>
        /// Voegt een nieuwe tram toe aan de database.
        /// </summary>
        /// <param name="tram"></param>
        void AddTram(Tram tram);

        /// <summary>
        /// Verwijdert een Tram uit de database.
        /// </summary>
        /// <param name="tram"></param>
        void RemoveTram(Tram tram);

        /// <summary>
        /// Haal een Tram op aan de hand van de tramid.
        /// </summary>
        /// <param name="id"></param>
        Tram GetTram(int id);

        /// <summary>
        /// Haal alle trams op.
        /// </summary>
        List<Tram> GetAllTrams();

        /// <summary>
        /// Haal de tram op waar deze meneer in rijdt.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        Tram GetTramByDriver(User driver);

        /// <summary>
        /// Gets alle trams met een bepaalde status.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        List<Tram> GetAllTramsWithStatus(TramStatus status);

        /// <summary>
        /// Haal trams op met locatie.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        List<Tram> GetAllTramsWithlocation(TramLocation location);

        /// <summary>
        /// Haalt alle tracks, sectoren en trams op sectoren op.
        /// </summary>
        /// <returns></returns>
        List<Track> GetTracksAndSectors();
    }
}
