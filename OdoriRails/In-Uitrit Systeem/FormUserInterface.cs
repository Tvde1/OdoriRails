using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public partial class FormUserInterface : Form
    {
        private Logic _logic;
        private Timer _lineFetcher;

        public FormUserInterface(User driver)
        {
            InitializeComponent();
            _logic = new Logic(driver);
            _lineFetcher = new Timer {Interval = 10000};
            _lineFetcher.Tick += LineFetcher_Tick;
            lblTramNumber.Text = _logic.Tram.Number.ToString();
        }

        private void LineFetcher_Tick(object sender, EventArgs e)
        {
            if (_logic.Tram.Line.ToString() != lblStandplaats.Text)
            {
                lblStandplaats.Text = _logic.Tram.Line.ToString();
                _lineFetcher.Stop();
            }
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            if (_logic.Tram.Location == TramLocation.In)
            {

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
            rtbDetails.Text = "";
            btnService.Enabled = false;
            _logic.Tram.EditTramLocation(TramLocation.ComingIn);
            lblStandplaats.Text = _logic.Tram.Line.ToString();
            _lineFetcher.Start();
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
