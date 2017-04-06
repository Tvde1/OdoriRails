﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails
{
    interface IDatabaseConnector
    {
        #region users
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
        /// Haalt alle users op die deze rol hebben.
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        List<User> GetAllUsersWithRole(Role role);
        #endregion

        #region trams
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
        #endregion

        #region tracks and sector
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
        #endregion

        #region services
        /// <summary>
        /// Haal alle services op (reparatie en schoonmaak) die deze user hebben.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<Service> GetAllServicesFromUser(User user);

        /// <summary>
        /// Haalt een lijst op van services zonder users.
        /// </summary>
        /// <returns></returns>
        List<Service> GetAllServicesWithoutUsers();


        #endregion
    }
}
