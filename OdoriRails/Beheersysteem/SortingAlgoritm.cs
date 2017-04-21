using System.Collections.Generic;
using OdoriRails.BaseClasses;
using System;
using OdoriRails.DAL;
using System.Linq;
using System.Windows.Forms;
using OdoriRails.DAL.Repository;

namespace Beheersysteem
{
    class SortingAlgoritm
    {
        private List<Track> allTracks;
        private LogisticRepository repo;

        public SortingAlgoritm(List<Track> allTracks, LogisticRepository repo)
        {
            this.repo = repo;
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
                        foreach (Sector tempSector in track.Sectors)
                        {
                            BeheerSector sector;
                            sector = tempSector == null ? null : BeheerSector.ToBeheerSector(tempSector);
                            if (sector.Status == SectorStatus.Open)
                            {
                                sector.Occupy();
                                sector.SetOccupyingTram(tram);
                                repo.EditTram(tram);
                                repo.EditSector(sector);
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
                        for (int i = 0; i < track.Sectors.Count - 1; i++)
                        {
                            if (track.Sectors[0].OccupyingTram == null && track.Sectors[0].Status == SectorStatus.Open)
                            {
                                BeheerSector beheerSector;
                                beheerSector = track.Sectors[i] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[i]);
                                beheerSector.Occupy();
                                beheerSector.SetOccupyingTram(tram);
                                repo.EditTram(tram);
                                repo.EditSector(track.Sectors[i]);
                                return track.Sectors[i];
                            }
                            else if (track.Sectors[i].Status == SectorStatus.Occupied && track.Sectors[i].OccupyingTram.DepartureTime < tram.DepartureTime)
                            {
                                if (track.Sectors[i + 1].Status == SectorStatus.Open)
                                {
                                    BeheerSector beheerSector;
                                    beheerSector = track.Sectors[i + 1] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[i + 1]);
                                    beheerSector.Occupy();
                                    beheerSector.SetOccupyingTram(tram);
                                    repo.EditTram(tram);
                                    repo.EditSector(track.Sectors[i + 1]);
                                    return track.Sectors[i + 1];
                                }
                            }
                        }
                    }
                }

                //If not successful put tram on any other normal track (that doesn't have another line connected to it)
                foreach (Track track in allTracks)
                {
                    if (track.Type == TrackType.Normal)
                    {
                        for (int i = 0; i < track.Sectors.Count - 1; i++)
                        {
                            if (track.Sectors[0].OccupyingTram == null && track.Sectors[0].Status == SectorStatus.Open)
                            {
                                BeheerSector beheerSector;
                                beheerSector = track.Sectors[i] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[i]);
                                beheerSector.Occupy();
                                beheerSector.SetOccupyingTram(tram);
                                repo.EditTram(tram);
                                repo.EditSector(track.Sectors[i]);
                                return track.Sectors[i];
                            }
                            else if (track.Sectors[i].Status == SectorStatus.Occupied && track.Sectors[i].OccupyingTram.DepartureTime < tram.DepartureTime)
                            {
                                if (track.Sectors[i + 1].Status == SectorStatus.Open)
                                {
                                    BeheerSector beheerSector;
                                    beheerSector = track.Sectors[i + 1] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[i + 1]);
                                    beheerSector.Occupy();
                                    beheerSector.SetOccupyingTram(tram);
                                    repo.EditTram(tram);
                                    repo.EditSector(track.Sectors[i + 1]);
                                    return track.Sectors[i + 1];
                                }
                            }
                        }
                    }
                }

                //If not successful put on an exit line
                foreach (Track track in allTracks)
                {
                    if (track.Type == TrackType.Exit)
                    {
                        for (int i = 0; i < track.Sectors.Count - 1; i++)
                        {
                            if (track.Sectors[0].OccupyingTram == null && track.Sectors[0].Status == SectorStatus.Open)
                            {
                                BeheerSector beheerSector;
                                beheerSector = track.Sectors[i] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[i]);
                                beheerSector.Occupy();
                                beheerSector.SetOccupyingTram(tram);
                                repo.EditTram(tram);
                                repo.EditSector(track.Sectors[i]);
                                return track.Sectors[i];
                            }
                            else if (track.Sectors[i].Status == SectorStatus.Occupied && track.Sectors[i].OccupyingTram.DepartureTime < tram.DepartureTime)
                            {
                                if (track.Sectors[i + 1].Status == SectorStatus.Open)
                                {
                                    BeheerSector beheerSector;
                                    beheerSector = track.Sectors[i + 1] == null ? null : BeheerSector.ToBeheerSector(track.Sectors[i + 1]);
                                    beheerSector.Occupy();
                                    beheerSector.SetOccupyingTram(tram);
                                    repo.EditTram(tram);
                                    repo.EditSector(track.Sectors[i + 1]);
                                    return track.Sectors[i + 1];
                                }
                            }
                        }
                    }
                }
            }
            //If not successful let user place tram
            return null;
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