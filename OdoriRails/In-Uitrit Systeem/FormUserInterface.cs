using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public partial class FormUserInterface : Form
    {
        private Logic _logic;
        private Timer _AssignedTramLocationFetcher;
        private int _timerTick;

        public FormUserInterface(User driver)
        {
            InitializeComponent();
            _logic = new Logic(driver);
            _AssignedTramLocationFetcher = new Timer { Interval = 5000 };
            _AssignedTramLocationFetcher.Tick += AssignedTramLocationFetcher_Tick;
            lblTramNumber.Text = _logic.Tram?.Number.ToString() ?? "Geen Tram";
        }

        private void AssignedTramLocationFetcher_Tick(object sender, EventArgs e)
        {
            _logic.FetchTramUpdates();
            if (_logic.Tram.Location == TramLocation.In)
            {
                lblStandplaats.Text = _logic.GetAssingedTramLocation();
                btnLeave.Enabled = true;
                btnService.Enabled = true;
                _AssignedTramLocationFetcher.Stop();
            }
            if (_timerTick == 5)
            {
                _timerTick = 0;
                string error = string.Format("Tram {0} kan niet worden aangemeld. Neem contact op met een logistiek medewerker.", _logic.Tram.Number.ToString());
                MessageBox.Show(error, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _AssignedTramLocationFetcher.Stop();
            }
            _timerTick++;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            if (_logic.Tram == null)
            {
                MessageBox.Show("U bestuurt nu geen tram.");
                return;
            }

            if (_logic.Tram.Location == TramLocation.In || _logic.Tram.Location == TramLocation.ComingIn)
            {
                string error = string.Format("Tram {0} is al aangemeld. Neem contact op met een logistiek medewerker.", _logic.Tram.Number.ToString());
                MessageBox.Show(error, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string defect = rtbDetails.Text;
            if (cbCleaning.Checked && cbMaintenance.Checked)
            {
                _logic.Tram.EditTramStatus(TramStatus.CleaningMaintenance);
                _logic.AddRepair(defect);
                _logic.AddCleaning();
            }
            else if (cbCleaning.Checked)
            {
                _logic.Tram.EditTramStatus(TramStatus.Cleaning);
                _logic.AddCleaning();
            }
            else if (cbMaintenance.Checked)
            {
                _logic.Tram.EditTramStatus(TramStatus.Maintenance);
                _logic.AddRepair(defect);
            }

            lblStandplaats.Text = "Wordt opgehaald.";
            rtbDetails.Text = "";
            rtbDetails.Enabled = false;
            cbCleaning.Checked = false;
            cbMaintenance.Checked = false;
            btnLeave.Enabled = false;
            btnService.Enabled = false;

            _logic.Tram.EditTramLocation(TramLocation.ComingIn);
            _logic.UpdateTram();
            _AssignedTramLocationFetcher.Start();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            if (_logic.Tram == null)
            {
                MessageBox.Show("U bestuurt nu geen tram.");
                return;
            }

            if (_logic.Tram.Location == TramLocation.Out || _logic.Tram.Location == TramLocation.ComingIn)
            {
                string error = string.Format("Tram {0} is nog niet aangemeld bij de remise. Meld deze tram eerst aan bij de remise.", _logic.Tram.Number.ToString());
                MessageBox.Show(error, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lblStandplaats.Text = "Niet bekend";

            _logic.Tram.EditTramLocation(TramLocation.Out);
            _logic.UpdateTram();
            _logic.Tram.ResetTramDeparture();
        }

        private void cbMaintenance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCleaning.Checked || cbMaintenance.Checked)
            {
                rtbDetails.Enabled = true;
            }
            else
            {
                rtbDetails.Enabled = false;
            }
        }

        private void cbCleaning_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCleaning.Checked || cbMaintenance.Checked)
            {
                rtbDetails.Enabled = true;
            }
            else
            {
                rtbDetails.Enabled = false;
            }
        }
    }
}
