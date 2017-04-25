﻿using System;
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
            FormGraphics.DrawGraphics(e.Graphics, _logic.AllTracks);
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
