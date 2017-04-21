using System;
using OdoriRails.BaseClasses;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OdoriRails.DAL
{
    public class TrackSectorContext : ITrackSectorContext
    {
        private readonly TramContext _tramContext = new TramContext();
        private const int RemiseNumber = 1;

        public List<Track> GetTracksAndSectors()
        {
            var returnList = new List<Track>();
            var trackQuery = new SqlCommand($"SELECT * FROM Track WHERE RemiseFk = {RemiseNumber}");
            var sectorQuery = new SqlCommand($"SELECT * FROM Sector WHERE RemiseFk = {RemiseNumber}");
            var trackData = Database.GetData(trackQuery);
            var sectorData = Database.GetData(sectorQuery);

            var sectorList = Database.GenerateListWithFunction(sectorData, CreateSector);
            var trackList = Database.GenerateListWithFunction<Track>(trackData, CreateTrack);

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
            query.Parameters.AddWithValue("@remise", RemiseNumber);
            query.Parameters.AddWithValue("@id", track.Number);
            Database.GetData(query);
        }

        public void EditSector(Sector sector)
        {
            var query = new SqlCommand("UPDATE Sector SET Status = @stat, TrackFk = @track, TramFk = @tram, RemiseFk = @remis WHERE SectorPk = @id");
            query.Parameters.AddWithValue("@stat", (int)sector.Status);
            query.Parameters.AddWithValue("@track", sector.TrackNumber);
            query.Parameters.AddWithValue("@tram", sector.OccupyingTram.Number);
            query.Parameters.AddWithValue("@remis", RemiseNumber);
            query.Parameters.AddWithValue("@id", sector.Number);
            Database.GetData(query);
        }

        public Sector CreateSector(DataRow row)
        {
            var array = row.ItemArray;
            Tram tram = null;
            if (String.IsNullOrEmpty((string)array[3]) && array[3] != DBNull.Value) tram = _tramContext.GetTram((int)array[3]);

            return new Sector((int)array[0], (int)array[2], (SectorStatus)array[1], tram);
        }

        public static Track CreateTrack(DataRow row)
        {
            var array = row.ItemArray;
            return new Track((int)array[0], (int)array[1], (TrackType)array[2]);
        }
    }
}
