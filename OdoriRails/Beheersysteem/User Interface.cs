using System;
using System.Drawing;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using System.Reflection;
using System.Threading.Tasks;

namespace Beheersysteem
{
    public partial class UserInterface : Form
    {
        private Logic _logic;

        public UserInterface()
        {
            _logic = new Logic(this);
            InitializeComponent();
            panelMain.Invalidate();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelMain, new object[] { true });
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _logic.Unlock(tbSelectedSector.Text);
            panelMain.Invalidate();

        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            _logic.Lock(tbSelectedSector.Text);
            panelMain.Invalidate();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {

        }

        private void btnSetDisabled_Click(object sender, EventArgs e)
        {
            _logic.ToggleDisabled(tbSelectedTram.Text);
            panelMain.Invalidate();
        }

        private void btnSimulation_Click(object sender, EventArgs e)
        {
            Task Simulation = new Task(new Action(() => { _logic.Simulation(); } ));
            _logic.WipePreSimulation();
            Simulation.Start();
        }

        private void btnChangeDisplayView_Click(object sender, EventArgs e)
        {
            btnChangeDisplayView.Text = btnChangeDisplayView.Text == "Display Table" ? "Display Map" : "Display Table";
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            Console.WriteLine(".Redraw.");

            var pen = new Pen(Color.Black, 2);
            var stringFont = new Font("Arial", 11);
            var blackBrush = new SolidBrush(Color.Black);
            var redBrush = new SolidBrush(Color.Red);
            var yellowBrush = new SolidBrush(Color.Yellow);
            var goldBrush = new SolidBrush(Color.Gold);
            var grayBrush = new SolidBrush(Color.Gray);
            var graphics = e.Graphics;

            int baseX = 10;
            int baseY = 10;
            int baseYmax = 0;

            var x = baseX;
            var y = baseY;

            var tracks = _logic.AllTracks;

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
                else if (track.Number > 38 && track.Number < 64)
                {
                    y = baseY;
                }
                else if (track.Number == 64)
                {
                    baseY = baseYmax + 10;
                    y = baseY;
                    x = baseX;
                }
                else if (track.Number > 64)
                {
                    y = baseY;
                }
                else
                {
                    y = baseY;
                }
            }
        }

        private void UserInterface_Paint(object sender, PaintEventArgs e)
        {
            panelMain.Invalidate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _logic.WipePreSimulation();
            panelMain.Invalidate();
        }
    }
}
