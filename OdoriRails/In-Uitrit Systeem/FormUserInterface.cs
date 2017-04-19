using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public partial class FormUserInterface : Form
    {
        Logic Logic;
        Timer LineFetcher;

        public FormUserInterface(User driver)
        {
            InitializeComponent();
            Logic = new Logic(driver);
            LineFetcher = new Timer();
            LineFetcher.Interval = 10000;
            lblTramNumber.Text = Logic.Tram.Number.ToString();
        }

        private void LineFetcher_Tick()
        {
            if (Logic.Tram.Line.ToString() != lblStandplaats.Text)
            {
                lblStandplaats.Text = Logic.Tram.Line.ToString();
                LineFetcher.Stop();
            }
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            string defect = rtbDetails.Text;
            if (cbCleaning.Checked && cbMaintenance.Checked)
            {
                Logic.Tram.EditTramStatus(TramStatus.CleaningMaintenance);
                Logic.AddRepair(defect);
                Logic.AddCleaning();
            }
            else if (cbCleaning.Checked)
            {
                Logic.Tram.EditTramStatus(TramStatus.Cleaning);
                Logic.AddCleaning();
            }
            else if (cbMaintenance.Checked)
            {
                Logic.Tram.EditTramStatus(TramStatus.Maintenance);
                Logic.AddRepair(defect);
            }
            rtbDetails.Text = "";
            btnService.Enabled = false;
            Logic.Tram.EditTramLocation(TramLocation.ComingIn);
            lblStandplaats.Text = Logic.Tram.Line.ToString();
            LineFetcher.Start();
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
