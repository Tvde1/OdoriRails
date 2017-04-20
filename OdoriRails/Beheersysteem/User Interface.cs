using System;
using System.Drawing;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace Beheersysteem
{
    public partial class UserInterface : Form
    {
        private Logic _logic = new Logic();

        public UserInterface()
        {
            InitializeComponent();
            panelMain.Invalidate();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            //Test
            _logic.GetSchema();
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnLock_Click(object sender, EventArgs e)
        {

        }

        private void btnMove_Click(object sender, EventArgs e)
        {

        }

        private void btnSetDisabled_Click(object sender, EventArgs e)
        {

        }

        private void btnSimulation_Click(object sender, EventArgs e)
        {
            _logic.Simulation();
        }

        private void btnChangeDisplayView_Click(object sender, EventArgs e)
        {
            btnChangeDisplayView.Text = btnChangeDisplayView.Text == "Display Table" ? "Display Map" : "Display Table";
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            var panel = panelMain;
            var pen = new Pen(Color.Black, 4);
            var stringFont = new Font("Arial", 16);
            var stringBrush = new SolidBrush(Color.Black);
            var graphics = panel.CreateGraphics();

            var baseX = 10;
            var baseYService = 10;
            var baseYGroep1 = 160;

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
                var rectTrack = new Rectangle(x, y, 40, 20);
                graphics.DrawRectangle(pen, rectTrack);
                graphics.DrawString(track.Number.ToString(), stringFont, stringBrush, rectTrack);
                y += 25;

                foreach (var sector in track.Sectors)
                {
                    var rect = new Rectangle(x, y, 40, 20);
                    graphics.DrawRectangle(pen, rect);
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
                    var rectF = new RectangleF(x + 2, y + 2, 35, 15);
                    graphics.FillRectangle(brush, rectF);
                    y += 25;
                }
                x += 50;

                if (track.Number == 33)
                {
                    y = baseYGroep1;
                    x = baseX;
                }
                else if (track.Number > 33)
                {
                    y = baseYGroep1;
                }
                else
                {
                    y = baseYService;
                }
            }
        }
    }
}
