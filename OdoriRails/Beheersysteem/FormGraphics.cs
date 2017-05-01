using Beheersysteem.ObjectClasses;
using OdoriRails.BaseClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beheersysteem
{
    static class FormGraphics
    {
        public static void DrawGraphics(Graphics graphics, List<BeheerTrack> _tracks, List<BeheerTram> _trams, string _cutoffTracks, bool showEmptyTracks)
        {
            List<BeheerTram> trams = new List<BeheerTram>(_trams);
            List<BeheerTrack> tracks;
            if (showEmptyTracks == false)
            {
                tracks = new List<BeheerTrack>(_tracks.Where(track => track.Sectors.Count != 0));
            }
            else
            {
                tracks = new List<BeheerTrack>(_tracks);
            }

            int[] cutoffTracks = Array.ConvertAll(_cutoffTracks.Split(','), int.Parse);

            var pen = new Pen(Color.Black, 2);
            var stringFont = new Font("Arial", 11);
            var blackBrush = new SolidBrush(Color.Black);
            var redBrush = new SolidBrush(Color.Red);
            var yellowBrush = new SolidBrush(Color.Yellow);
            var goldBrush = new SolidBrush(Color.Gold);
            var grayBrush = new SolidBrush(Color.Gray);
            var lightGrayBrush = new SolidBrush(Color.LightGray);
            var blueBrush = new SolidBrush(Color.Blue);

            int baseX = 120;
            int baseY = 10;
            int baseYmax = 0;
            int sectorMax = 0;

            var x = baseX;
            var y = baseY;

            foreach (BeheerTrack track in tracks)
            {
                var rectTrackNumber = new Rectangle(x, y, 40, 20);
                graphics.FillRectangle(grayBrush, rectTrackNumber);
                graphics.DrawString(track.Number.ToString(), stringFont, blackBrush, rectTrackNumber);
                y += 25;

                if (track.Type == TrackType.Normal)
                {
                    var rectTrackLine = new Rectangle(x, y, 40, 20);
                    if (track.Line != 0)
                    {
                        graphics.FillRectangle(yellowBrush, rectTrackLine);
                        graphics.DrawString(track.Line.ToString(), stringFont, blackBrush, rectTrackLine);
                    }
                    else
                    {
                        graphics.FillRectangle(goldBrush, rectTrackLine);
                    }
                }
                else if (track.Type == TrackType.Service)
                {
                    var rectTrackLine = new Rectangle(x, y, 40, 20);
                    graphics.FillRectangle(redBrush, rectTrackLine);

                }
                else if (track.Type == TrackType.Exit)
                {
                    var rectTrackLine = new Rectangle(x, y, 40, 20);
                    graphics.FillRectangle(blackBrush, rectTrackLine);
                }

                y += 25;

                foreach (Sector sector in track.Sectors)
                {
                    var rect = new Rectangle(x, y, 40, 20);
                    Brush brush = null;
                    switch (sector.Status)
                    {
                        case SectorStatus.Open:
                            brush = new Pen(Color.Green).Brush;
                            break;
                        case SectorStatus.Locked:
                            brush = new Pen(Color.Tomato).Brush;
                            break;
                        case SectorStatus.Occupied:
                            brush = yellowBrush;
                            break;
                    }
                    graphics.FillRectangle(brush, rect);
                    graphics.DrawRectangle(pen, rect);
                    Brush tramBrush = null;
                    if (sector.OccupyingTram != null)
                    {
                        switch (sector.OccupyingTram.Status)
                        {
                            case TramStatus.Idle:
                                tramBrush = blackBrush;
                                break;
                            case TramStatus.Cleaning:
                                tramBrush = blueBrush;
                                break;
                            case TramStatus.CleaningMaintenance:
                                tramBrush = blueBrush;
                                break;
                            case TramStatus.Maintenance:
                                tramBrush = blueBrush;
                                break;
                            case TramStatus.Defect:
                                tramBrush = redBrush;
                                break;
                        }
                        graphics.DrawString(sector.OccupyingTram.Number.ToString(), stringFont, tramBrush, rect);

                        trams.RemoveAll(tram => tram.Number == sector.OccupyingTram.Number);
                    }
                    y += 25;

                    if (baseYmax < y)
                    {
                        baseYmax = y;
                        sectorMax += 1;
                    }
                }

                if (cutoffTracks.Contains(track.Number))
                {
                    y = baseY;
                    x = baseX - 20;
                    for (int i = -2; i < sectorMax; i++)
                    {
                        var rect = new Rectangle(x, y, 10, 20);
                        if (i >= 0)
                        {
                            graphics.DrawString(i.ToString(), stringFont, redBrush, rect);
                        }
                        y += 25;
                    }

                    baseY = baseYmax + 10;
                    y = baseY;
                    x = baseX;
                    sectorMax = 0;
                }
                else
                {
                    x += 50;
                    y = baseY;
                }
            }

            y = baseY;
            x = baseX - 20;
            for (int i = -2; i < sectorMax; i++)
            {
                var rect = new Rectangle(x, y, 10, 20);
                if (i >= 0)
                {
                    graphics.DrawString(i.ToString(), stringFont, redBrush, rect);
                }
                y += 25;
            }

            //Print all non assigned trams 
            x = 10;
            y = 10;

            foreach (Tram tram in trams.Where(tram => tram.Location != TramLocation.Out || tram.Location != TramLocation.GoingOut))
            {
                var rect = new Rectangle(x, y, 40, 20);
                graphics.FillRectangle(lightGrayBrush, rect);
                graphics.DrawRectangle(pen, rect);
                Brush tramBrush = null;
                switch (tram.Status)
                {
                    case TramStatus.Idle:
                        tramBrush = blackBrush;
                        break;
                    case TramStatus.Cleaning:
                        tramBrush = blueBrush;
                        break;
                    case TramStatus.CleaningMaintenance:
                        tramBrush = blueBrush;
                        break;
                    case TramStatus.Maintenance:
                        tramBrush = blueBrush;
                        break;
                    case TramStatus.Defect:
                        tramBrush = redBrush;
                        break;
                }
                graphics.DrawString(tram.Number.ToString(), stringFont, tramBrush, rect);
                y += 25;
            }
            
        }
    }
}

