using OdoriRails.BaseClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdoriRails.DAL
{
    public class TrackSectorContext : ITrackSectorContext
    {
        private const string ConnectionString = Database.ConnectionString;

        private const int RemiseNumber = 0;
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
    }
}
