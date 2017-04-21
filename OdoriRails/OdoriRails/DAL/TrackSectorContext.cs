﻿using OdoriRails.BaseClasses;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq; 

namespace OdoriRails.DAL
{
    public class TrackSectorContext : ITrackSectorContext
    {
        private const int RemiseNumber = 1;
        public List<Track> GetTracksAndSectors()
        {
            var returnList = new List<Track>();
            var trackQuery = new SqlCommand($"SELECT * FROM Track WHERE RemiseFk = {RemiseNumber}");
            var sectorQuery = new SqlCommand($"SELECT * FROM Sector WHERE RemiseFk = {RemiseNumber}");
            var trackData = Database.GetData(trackQuery);
            var sectorData = Database.GetData(sectorQuery);

            var sectorList = Database.GenerateListWithFunction(sectorData, Database.CreateSector);
            var trackList = Database.GenerateListWithFunction(trackData, Database.CreateTrack);

            foreach (var track in trackList)
            {
                sectorList.Where(x => x.TrackNumber == track.Number).ToList().ForEach(x => track.AddSector(x));
                returnList.Add(track);
            }
            return returnList;
        }

        public void EditTrack(Track track)
        {
            var query = new SqlCommand("UPDATE Track SET Line = @line, Type = @type, RemiseFk = @remise WHERE TrackPk = @id");
            query.Parameters.AddWithValue("@line", track.Line);
            query.Parameters.AddWithValue("@type", (int)track.Type);
            query.Parameters.AddWithValue("@remise", RemiseNumber); //TODO: Deze actueel maken.
            query.Parameters.AddWithValue("@id", track.Number);
            Database.GetData(query);
        }

        public void EditSector(Sector sector)
        {
            var query = new SqlCommand("UPDATE Sector SET Status = @stat, TramFk = @tram, RemiseFk = @remis WHERE SectorPk = @id AND TrackFk = @track");
            query.Parameters.AddWithValue("@stat", (int)sector.Status);
            query.Parameters.AddWithValue("@track", sector.TrackNumber);
            query.Parameters.AddWithValue("@tram", sector.OccupyingTram.Number);
            query.Parameters.AddWithValue("@remis", RemiseNumber); //TODO: Deze acueel maken.
            query.Parameters.AddWithValue("@id", sector.Number);
            Database.GetData(query);
        }
    }
}
