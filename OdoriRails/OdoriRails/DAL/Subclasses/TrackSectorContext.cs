using System;
using OdoriRails.BaseClasses;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace OdoriRails.DAL.Subclasses
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
            var trackList = Database.GenerateListWithFunction(trackData, CreateTrack);

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

            foreach (var sector in track.Sectors)
            {
                EditSector(sector);
            }
        }

        public void EditSector(Sector sector)
        {
            var query = new SqlCommand("UPDATE Sector SET Status = @stat, TramFk = @tram, RemiseFk = @remis WHERE SectorPk = @id AND TrackFk = @track");
            query.Parameters.AddWithValue("@stat", (int)sector.Status);
            query.Parameters.AddWithValue("@track", sector.TrackNumber);
            if (sector.OccupyingTram != null) query.Parameters.AddWithValue("@tram", sector.OccupyingTram.Number);
            else query.Parameters.AddWithValue("@tram", DBNull.Value);
            query.Parameters.AddWithValue("@remis", RemiseNumber);
            query.Parameters.AddWithValue("@id", sector.Number);
            Database.GetData(query);
        }

        public void WipeTramFromSectorByTramId(int id)
        {
            var query = new SqlCommand("UPDATE Sector SET TramFk = null WHERE TramFk = @id");
            query.Parameters.AddWithValue("@id", id);
            Database.GetData(query);

            query = new SqlCommand("UPDATE Sector SET Status = 0 WHERE Status = 2 AND TramFk = @id");
            query.Parameters.AddWithValue("@id", id);
            Database.GetData(query);
        }

        public void WipeTramsFromSectors()
        {
            Database.GetData(new SqlCommand("UPDATE Sector SET TramFk = null"));
            Database.GetData(new SqlCommand("UPDATE Sector SET Status = 0 WHERE Status = 2"));
        }

        public Sector CreateSector(DataRow row)
        {
            var array = row.ItemArray;
            Tram tram = null;
            if (array[3] != DBNull.Value) tram = _tramContext.GetTram((int)array[3]);

            return new Sector((int)array[0], (int)array[2], (SectorStatus)array[1], tram);
        }

        private static Track CreateTrack(DataRow row)
        {
            var array = row.ItemArray;
            return new Track((int)array[0], (int)array[1], (TrackType)array[2]);
        }
    }
}
