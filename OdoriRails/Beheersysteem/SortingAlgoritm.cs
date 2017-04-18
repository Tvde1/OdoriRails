﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdoriRails.BaseClasses;
using Beheersysteem.ObjectClasses;

namespace Beheersysteem
{
    class SortingAlgoritm
    {
        //private Tram tram;
        //private List<Track> allTracks;
        //private List<InUitRijSchema> schema;

        public SortingAlgoritm()
        {
            //this.tram = tram;
            //this.allTracks = allTracks;
            //this.schema = schema;
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
            return null;
        }
    }
}