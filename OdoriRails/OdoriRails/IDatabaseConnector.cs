using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    interface IDatabaseConnector
    {
        /// <summary>
        /// Voegt een User toe aan de database.
        /// </summary>
        /// <param name="user"></param>
        void AddUser(User user);

        /// <summary>
        /// Verwijdert een User uit de database.
        /// </summary>
        /// <param name="user"></param>
        void RemoveUser(User user);

        /// <summary>
        /// Haal een User op aan de hand van de userid.
        /// </summary>
        /// <param name="id"></param>
        User GetUser(int id);

        /// <summary>
        /// Haal een User op aan de hand van de username.
        /// </summary>
        /// <param name="userName"></param>
        User GetUser(string userName);

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
        /// Haalt alle tracks, sectoren en trams op sectoren op.
        /// </summary>
        /// <returns></returns>
        List<Track> GetTracksAndSectors();

        /// <summary>
        /// Een lijst met trams die op een track staan.
        /// </summary>
        /// <returns></returns>
        List<Tram> GetAllTramsOnATrack();
    }
}
