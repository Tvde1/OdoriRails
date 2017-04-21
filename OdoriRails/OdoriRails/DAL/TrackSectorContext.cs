using OdoriRails.BaseClasses;
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
            var query = new SqlCommand("UPDATE Track SET (Line,Type,RemiseFk) VALUES (@line,@type,@remise) WHERE TrackPk = @id");
            query.Parameters.AddWithValue("@line", track.Number);
            query.Parameters.AddWithValue("@type", (int)track.Type);
            query.Parameters.AddWithValue("@remise", RemiseNumber); //TODO: Deze actueel maken.
            Database.GetData(query);
        }

        public void EditSector(Sector sector)
        {
            var query = new SqlCommand("UPDATE Sector SET (Status,Track,Tram,Remise) VALUES (@stat,@track,@tram,@remis) WHERE SectorPk = @id");
            query.Parameters.AddWithValue("@stat", (int)sector.Status);
            query.Parameters.AddWithValue("@track", sector.TrackNumber);
            query.Parameters.AddWithValue("@tram", sector.OccupyingTram.Number);
            query.Parameters.AddWithValue("@remis", RemiseNumber); //TODO: Deze acueel maken.
            Database.GetData(query);
        }
    }
}
