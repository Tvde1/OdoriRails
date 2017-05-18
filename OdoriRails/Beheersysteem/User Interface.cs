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

            cbTramModel.DataSource = Enum.GetValues(typeof(TramModel));
            cbTrackType.DataSource = Enum.GetValues(typeof(TrackType));

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, panelMain, new object[] { true });
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            _logic.Unlock(tbSelectedTrack.Text, tbSelectedSector.Text);
            panelMain.Invalidate();
        }

        private void btnLock_Click(object sender, EventArgs e)
        {
            _logic.Lock(tbSelectedTrack.Text, tbSelectedSector.Text);
            panelMain.Invalidate();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            if (tbMoveToTrack.Text == "58" || tbMoveToTrack.Text == "40")
            {
                DialogResult dialogResult = MessageBox.Show("Warning you are trying to move a tram to an exit track, are you sure?", "Move to ExitTrack", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    moveTram();
                }
            }
            else
            {
                moveTram();
            }
        }

        private void moveTram()
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to move this tram?", "Move Tram", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (_logic.MoveTram(tbSelectedTram.Text, tbMoveToTrack.Text, tbMoveToSector.Text) == false)
                {
                    MessageBox.Show("Failed to move the selected tram to the new location");
                }
            }
        }

        private void btnSetDisabled_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to set this tram as disabled?", "Set Tram as Disabled", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _logic.ToggleDisabled(tbSelectedTram.Text);
                panelMain.Invalidate();
            }
        }

        private void btnSimulation_Click(object sender, EventArgs e)
        {
            _logic.tramFetcher.Stop();
            Task Simulation = new Task(new Action(() => { _logic.Simulation(); }));
            _logic.WipePreSimulation();
            Simulation.Start();
            _logic.tramFetcher.Start();
        }

        private void btnChangeDisplayView_Click(object sender, EventArgs e)
        {
            btnChangeDisplayView.Text = btnChangeDisplayView.Text == "Display Table" ? "Display Map" : "Display Table";
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {
            int[] cutoffTracks = _logic.Parse(tbCutoffTracks.Text);
            if (cutoffTracks[0] != -1)
            {
                FormGraphics.DrawGraphics(e.Graphics, _logic.AllTracks, _logic.AllTrams, cutoffTracks, cBoxShowEmptyTracks.Checked);
            }
        }

        private void UserInterface_Paint(object sender, PaintEventArgs e)
        {
            panelMain.Invalidate();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to reset the remise?", "Reset Remise", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _logic.WipePreSimulation();
                panelMain.Invalidate();
            }
        }

        private void btnAddTram_Click(object sender, EventArgs e)
        {
            _logic.AddTram(tbTramNumber.Text, tbDefaultLine.Text, cbTramModel.SelectedItem.ToString());
        }

        private void btnAddTrack_Click(object sender, EventArgs e)
        {
            _logic.AddTrack(tbTrackNumber.Text, tbSectorAmount.Text, cbTrackType.SelectedItem.ToString(), tbDefaultLineTrack.Text);
        }

        private void btnAddSector_Click(object sender, EventArgs e)
        {
            if (!_logic.AddSector(tbSectorTrack.Text)) MessageBox.Show("Failed to add sector.");
        }

        private void btnDeleteSector_Click(object sender, EventArgs e)
        {
            if (!_logic.DeleteSector(tbSectorTrack.Text)) MessageBox.Show("Failed to delete sector, make sure sector is empty");
        }

        private void btnDeleteTrack_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this track?", "Delete Track", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                if (!_logic.DeleteTrack(tbTrackNumber.Text)) MessageBox.Show("Failed to delete track, make sure track is empty");
            }
        }

        private void btnDeleteTram_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this tram?", "Delete Tram", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                _logic.DeleteTram(tbTramNumber.Text);
            }
        }

        private void btnUpdateSettings_Click(object sender, EventArgs e)
        {
            panelMain.Invalidate();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _logic.FetchUpdates();
        }
    }
}
