using System;
using System.Drawing;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using System.Reflection;

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

            //typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelMain, new object[] { true });
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
            _logic.Simulation();
            panelMain.Invalidate();
        }

        private void btnChangeDisplayView_Click(object sender, EventArgs e)
        {
            btnChangeDisplayView.Text = btnChangeDisplayView.Text == "Display Table" ? "Display Map" : "Display Table";
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            var panel = panelMain;
            var pen = new Pen(Color.Black, 2);
            var stringFont = new Font("Arial", 11);
            var blackBrush = new SolidBrush(Color.Black);
            var redBrush = new SolidBrush(Color.Red);
            var yellowBrush = new SolidBrush(Color.Yellow);
            var goldBrush = new SolidBrush(Color.Gold);
            var grayBrush = new SolidBrush(Color.Gray);
            var graphics = panel.CreateGraphics();

            var baseX = 10;
            var baseYService = 10;
            var baseYGroup1 = 200;
            var baseYGroup2 = 500;

            var x = baseX;
            var y = baseYService;

            var tracks = _logic.AllTracks;
            var testString = "";

            foreach (var track in tracks)
            {
                string newTestString = "";
                foreach (var sector in track.Sectors)
                {
                    newTestString += "[] ";
                }
                testString += newTestString + "\r\n";
            }

            //MessageBox.Show(testString);

            foreach (var track in tracks)
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


                foreach (var sector in track.Sectors)
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
                }
                x += 50;

                if (track.Number == 38)
                {
                    y = baseYGroup1;
                    x = baseX;
                }
                else if (track.Number > 38 && track.Number < 64)
                {
                    y = baseYGroup1;
                }
                else if (track.Number == 64)
                {
                    y = baseYGroup2;
                    x = baseX;
                }
                else if (track.Number > 64)
                {
                    y = baseYGroup2;
                }
                else
                {
                    y = baseYService;
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
        }
    }
}
