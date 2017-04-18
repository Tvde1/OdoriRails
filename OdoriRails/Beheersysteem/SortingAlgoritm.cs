using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails;
using Beheersysteem.ObjectClasses;

namespace Beheersysteem
{
    class SortingAlgoritm
    {
        private Tram tram;
        private List<Track> allTracks;
        private List<InUitRijSchema> schema;

        public SortingAlgoritm(Tram tram, List<Track> allTracks, List<InUitRijSchema> schema)
        {
            this.tram = tram;
            this.allTracks = allTracks;
            this.schema = schema;
        }

        public Sector GetSector()
        {
            if (tram.Status == TramStatus.Cleaning || tram.Status == TramStatus.Maintenance || tram.Status == TramStatus.CleaningMaintenance)
            {
                foreach (Track track in allTracks)
                {
                    if (track.TrackType == TrackType.Service)
                    {
                        foreach (Sector sector in track.Sectors)
                        {
                            if (sector.Status == SectorStatus.Open)
                            {
                                return sector;
                            }
                        }
                    }
                }
            }
            else
            {
                foreach (Track track in allTracks)
                {
                    if (track.Line == tram.Line && track.TrackType == TrackType.Normal)
                    {
                        foreach (Sector sector in track.Sectors)
                        {
                            if (sector.Status == SectorStatus.Open)
                            {
                                return sector;
                            }
                        }
                    }
                }

                foreach (Track track in allTracks)
                {
                    if (track.Line == tram.Line && track.TrackType == TrackType.Exit)
                    {
                        foreach (Sector sector in track.Sectors)
                        {
                            if (sector.Status == SectorStatus.Open)
                            {
                                return sector;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}