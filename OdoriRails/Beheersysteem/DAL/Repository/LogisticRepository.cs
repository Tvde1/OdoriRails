﻿using System.Collections.Generic;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Subclasses;

namespace Beheersysteem.DAL.Repository
{
    public class LogisticRepository
    {
        private static readonly IUserContext UserContext = new UserContext();
        private static readonly ITramContext TramContext = new TramContext();
        private static readonly ITrackSectorContext TrackSectorContext = new TrackSectorContext();
        private static readonly IServiceContext ServiceContext = new ServiceContext();

        /// <summary>
        /// Voegt een nieuwe tram toe aan de database.
        /// </summary>
        /// <param name="tram"></param>
        public void AddTram(Tram tram)
        {
            TramContext.AddTram(tram);
        }

        /// <summary>
        /// Verwijdert een Tram uit de database.
        /// </summary>
        /// <param name="tram"></param>
        public void RemoveTram(Tram tram)
        {
            TramContext.RemoveTram(tram);
        }

        /// <summary>
        /// Haal een Tram op aan de hand van de tramid.
        /// </summary>
        /// <param name="id"></param>
        public Tram GetTram(int id)
        {
            return TramContext.GetTram(id);
        }

        /// <summary>
        /// Haal alle trams op.
        /// </summary>
        public List<Tram> GetAllTrams()
        {
            return TramContext.GetAllTrams();
        }

        /// <summary>
        /// Haal de tram op waar deze meneer in rijdt.
        /// </summary>
        /// <param name="driver"></param>
        /// <returns></returns>
        public Tram GetTramByDriver(User driver)
        {
            return TramContext.GetTramByDriver(driver);
        }

        /// <summary>
        /// Gets alle trams met een bepaalde status.
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Tram> GetAllTramsWithStatus(TramStatus status)
        {
            return TramContext.GetAllTramsWithStatus(status);
        }

        /// <summary>
        /// Haal trams op met locatie.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public List<Tram> GetAllTramsWithLocation(TramLocation location)
        {
            return TramContext.GetAllTramsWithLocation(location);
        }

        /// <summary>
        /// Haalt alle tracks, sectoren en trams op sectoren op.
        /// </summary>
        /// <returns></returns>
        public List<Track> GetTracksAndSectors()
        {
            return TrackSectorContext.GetTracksAndSectors();
        }

        /// <summary>
        /// Haal een User op aan de hand van de username.
        /// </summary>
        /// <param name="userName"></param>
        public User GetUser(string userName)
        {
            return UserContext.GetUser(userName);
        }

        public void WipeAllDepartureTimes()
        {
            TramContext.WipeDepartureTimes();
        }

        public void WipeAllTramsFromSectors()
        {
            TrackSectorContext.WipeTramsFromSectors();
        }

        public void WipeSectorByTramId(int id)
        {
            TrackSectorContext.WipeTramFromSectorByTramId(id);
        }

        public void EditTram(Tram tram)
        {
            TramContext.EditTram(tram);
        }

        public void AddTrack(Track track)
        {
            TrackSectorContext.AddTrack(track);
        }

        public void AddSector(Sector sector, Track track)
        {
            TrackSectorContext.AddSector(sector, track);
        }

        public void EditSector(Sector sector)
        {
            TrackSectorContext.EditSector(sector);
        }

        public void DeleteSectorFromTrack(Track track, Sector sector)
        {
            TrackSectorContext.DeleteSectorFromTrack(track, sector);
        }

        public void EditTrack(Track track)
        {
            TrackSectorContext.EditTrack(track);
        }

        public void DeleteTrack(Track track)
        {
            TrackSectorContext.DeleteTrack(track);
        }

        public bool HadBigMaintenance(Tram tram)
        {
            return ServiceContext.HadBigMaintenance(tram);
        }

        public bool HadSmallMaintenance(Tram tram)
        {
            return ServiceContext.HadSmallMaintenance(tram);
        }

        public Repair AddRepair(Repair repair)
        {
            return ServiceContext.AddRepair(repair);
        }

        public Cleaning AddCleaning(Cleaning cleaning)
        {
            return ServiceContext.AddCleaning(cleaning);
        }

        public void DeleteService(Service service)
        {
            ServiceContext.DeleteService(service);
        }

        public List<Repair> GetAllRepairsFromUser(User user)
        {
            return ServiceContext.GetAllRepairsFromUser(user);
        }
    }
}
