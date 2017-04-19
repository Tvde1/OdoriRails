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
                List<Track> potentialTracks = new List<Track>();
                //Put tram on track thats connected to the line the tram is on
                foreach (Track track in allTracks)
                {
                    if (track.Line == tram.Line && track.Type == TrackType.Normal)
                    {
                        potentialTracks.Add(track);
                    }
                }

                Sector tempSector = GetPotentialSector(potentialTracks);
                if (tempSector != null)
                {
                    return tempSector;
                }

                potentialTracks.Clear();//Wipe list to start a new

                //If not successful put tram on any other normal track (that doesn't have another line connected to it)
                foreach (Track track in allTracks)
                {
                    if (track.Type == TrackType.Normal)
                    {
                        potentialTracks.Add(track);
                    }
                }

                tempSector = GetPotentialSector(potentialTracks);
                if (tempSector != null)
                {
                    return tempSector;
                }

                //If not successful put on an exit line
                foreach (Track track in allTracks)
                {
                    if (track.Type == TrackType.Exit)
                    {
                        potentialTracks.Add(track);
                    }
                }

                tempSector = GetPotentialSector(potentialTracks);
                if (tempSector != null)
                {
                    return tempSector;
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

        private Sector GetPotentialSector(List<Track> potentialTracks)
        {
            foreach (Track track in potentialTracks)
            {
                for (int i = 0; i < track.Sectors.Count - 1; i++)
                {
                    if (track.Sectors[i].Status == SectorStatus.Occupied && track.Sectors[i].OccupyingTram.DepartureTime < tram.DepartureTime)
                    {
                        if (track.Sectors[i + 1].Status == SectorStatus.Open)
                        {
                            return track.Sectors[i + 1];
                        }
                    }
                }
            }
            return null;
        }
    }

}