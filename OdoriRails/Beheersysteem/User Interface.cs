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
            if (btnChangeDisplayView.Text == "Display Table")
            {
                btnChangeDisplayView.Text = "Display Map";
            }
            else
            {
                btnChangeDisplayView.Text = "Display Table";
            }
        }

        private void BeheerPanel_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.dr
        }



        private void DrawPanel()
        {
            var panel = panelMain;
            var pen = new Pen(Color.Black, 4);
            var graphics = panel.CreateGraphics();

            var x = 0;
            var y = 0;

            foreach (var track in _logic.AllTracks)
            {
                x += 50;
                y = 0;
                foreach (var sector in track.Sectors)
                {
                    y += 70;
                    var rect = new Rectangle(x, y, 40, 60);
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
                    var rectF = new RectangleF(x + 2, y + 2, 36, 56);
                    graphics.FillRectangle(brush, rectF);
                }
            }
        }
    }
}
