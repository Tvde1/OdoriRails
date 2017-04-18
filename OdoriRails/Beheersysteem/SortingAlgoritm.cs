using System.Collections.Generic;
using OdoriRails.BaseClasses;
using System;
using System.Linq;

namespace Beheersysteem
{
    class SortingAlgoritm
    {
        private List<Track> allTracks;

        public SortingAlgoritm(List<Track> allTracks)
        {
            this.allTracks = allTracks;
        }

        public Sector GetSector(Tram tram, DateTime? exitTime)
        {
            //With a service needed, put on the first free slot
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
            //Else uses normal algorithem
            else
            {
                //Put tram on track thats connected to the line the tram is on
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

                //If not successful put tram on any other normal track (that doesn't have another line connected to it)
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

                //If not successful put on an exit line
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
            //If not successful let user place tram
            return GetSector(tram);
        }

        //Algoritme versie waar de eerste lege plek gebruikt wordt (backup als het andere niet blijkt te werken)
        public Sector GetSector(Tram tram)
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