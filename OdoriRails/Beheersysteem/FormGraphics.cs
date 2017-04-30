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
        public static void DrawGraphics(Graphics graphics, List<BeheerTrack> tracks, List<BeheerTram> _trams)
        {
            List<BeheerTram> trams = new List<BeheerTram>(_trams);

            var pen = new Pen(Color.Black, 2);
            var stringFont = new Font("Arial", 11);
            var blackBrush = new SolidBrush(Color.Black);
            var redBrush = new SolidBrush(Color.Red);
            var yellowBrush = new SolidBrush(Color.Yellow);
            var goldBrush = new SolidBrush(Color.Gold);
            var grayBrush = new SolidBrush(Color.Gray);

            int baseX = 70;
            int baseY = 10;
            int baseYmax = 0;

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
                            brush = new Pen(Color.Yellow).Brush;
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
                                tramBrush = new Pen(Color.Black).Brush;
                                break;
                            case TramStatus.Cleaning:
                                tramBrush = new Pen(Color.Blue).Brush;
                                break;
                            case TramStatus.CleaningMaintenance:
                                tramBrush = new Pen(Color.Blue).Brush;
                                break;
                            case TramStatus.Maintenance:
                                tramBrush = new Pen(Color.Blue).Brush;
                                break;
                            case TramStatus.Defect:
                                tramBrush = new Pen(Color.Red).Brush;
                                break;
                        }
                        graphics.DrawString(sector.OccupyingTram.Number.ToString(), stringFont, tramBrush, rect);

                        trams.RemoveAll(tram => tram.Number == sector.OccupyingTram.Number);
                    }
                    y += 25;

                    if (baseYmax < y)
                    {
                        baseYmax = y;
                    }
                }
                x += 50;

                if (track.Number == 38)
                {
                    baseY = baseYmax + 10;
                    y = baseY;
                    x = baseX;
                }
                else if (track.Number == 64)
                {
                    baseY = baseYmax + 10;
                    y = baseY;
                    x = baseX;
                }
                else
                {
                    y = baseY;
                }
            }

            //Print all non assigned trams 
            x = 10;
            y = 10;
            foreach (Tram tram in trams.Where(tram => tram.Location != TramLocation.Out || tram.Location != TramLocation.GoingOut))
            {
                var rect = new Rectangle(x, y, 40, 20);
                Brush brush = new Pen(Color.LightGray).Brush; ;
                graphics.FillRectangle(brush, rect);
                graphics.DrawRectangle(pen, rect);
                Brush tramBrush = null;
                switch (tram.Status)
                {
                    case TramStatus.Idle:
                        tramBrush = new Pen(Color.Black).Brush;
                        break;
                    case TramStatus.Cleaning:
                        tramBrush = new Pen(Color.Blue).Brush;
                        break;
                    case TramStatus.CleaningMaintenance:
                        tramBrush = new Pen(Color.Blue).Brush;
                        break;
                    case TramStatus.Maintenance:
                        tramBrush = new Pen(Color.Blue).Brush;
                        break;
                    case TramStatus.Defect:
                        tramBrush = new Pen(Color.Red).Brush;
                        break;
                }
                graphics.DrawString(tram.Number.ToString(), stringFont, tramBrush, rect);
                y += 25;
            }
            
        }
    }
}

