using System.Collections.Generic;
using OdoriRails.BaseClasses;
using Beheersysteem.ObjectClasses;

namespace Beheersysteem
{
    class SortingAlgoritm
    {
        public SortingAlgoritm()
        {

        }

        public Sector GetSector(Tram tram, List<Track> allTracks, List<InUitRijSchema> schema)
        {
            if (tram.Status == TramStatus.Cleaning || tram.Status == TramStatus.Maintenance || tram.Status == TramStatus.CleaningMaintenance)
            {
                foreach (Track track in allTracks)
                {
                    if (track.Type == TrackType.Service)
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
                    if (track.Line == tram.Line && track.Type == TrackType.Normal)
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
                    if (track.Line == tram.Line && track.Type == TrackType.Exit)
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
            return GetSector(tram, allTracks);
        }

        //Algoritme versie waar de eerste lege plek gebruikt wordt (backup als het andere niet blijkt te werken)
        public Sector GetSector(Tram tram, List<Track> allTracks)
        {
            foreach (Track track in allTracks)
            {
                if (track.Type == TrackType.Normal)
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
                if (track.Type == TrackType.Exit)
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
            return null;
        }
    }
}