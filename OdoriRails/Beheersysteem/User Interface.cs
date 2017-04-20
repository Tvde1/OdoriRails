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
            DrawPanel();
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
        

        private void DrawPanel()
        {
            var panel = panelMain;
            var pen = new Pen(Color.Black, 4);
            var graphics = panel.CreateGraphics();

            var x = 0;
            var y = 0;

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
                x += 5;
                y = 0;
                foreach (var sector in track.Sectors)
                {
                    graphics.DrawLine(pen, 100, 50, 20, 30);

                    y += 7;
                    var rect = new Rectangle(x, y, 4, 6);
                    graphics.DrawRectangle(pen, rect);
                    Brush brush = null;
                    switch (sector.Status)
                    {
                        case SectorStatus.Open:
                            brush = new Pen(Color.White).Brush;
                            break;
                        case SectorStatus.Locked:
                            brush = new Pen(Color.Red).Brush;
                            break;
                        case SectorStatus.Occupied:
                            brush = new Pen(Color.Yellow).Brush;
                            break;
                    }
                    var rectF = new RectangleF(x + 1, y + 1, 2, 4);
                    graphics.FillRectangle(brush, rectF);
                }
            }
        }
    }
}
