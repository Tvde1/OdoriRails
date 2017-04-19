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
        InUitRitTram Tram;
        User Driver;
        Timer LineFetcher;

        public FormUserInterface(User driver)
        {
            InitializeComponent();
            Driver = driver;
            Logic = new Logic();
            Tram = (InUitRitTram)Logic._databaseConnector.GetTram(driver.Id);
            LineFetcher = new Timer();
            LineFetcher.Interval = 10000;
            lblTramNumber.Text = Tram.Number.ToString();
        }

        private void LineFetcher_Tick()
        {
            if (Tram.Line.ToString() != lblStandplaats.Text)
            {
                lblStandplaats.Text = Tram.Line.ToString();
                LineFetcher.Stop();
            }
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            string defect = rtbDetails.Text;
            if (cbCleaning.Checked && cbMaintenance.Checked)
            {
                Tram.EditTramStatus(TramStatus.CleaningMaintenance);
                Tram.AddRepair(defect);
                Tram.AddCleaning();
            }
            else if (cbCleaning.Checked)
            {
                Tram.EditTramStatus(TramStatus.Cleaning);
                Tram.AddCleaning();
            }
            else if (cbMaintenance.Checked)
            {
                Tram.EditTramStatus(TramStatus.Maintenance);
                Tram.AddRepair(defect);
            }
            rtbDetails.Text = "";
            btnService.Enabled = false;
            Tram.EditTramLocation(TramLocation.Entering);
            lblStandplaats.Text = Tram.Line.ToString();
            LineFetcher.Start();
        }

        private void cbMaintenance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCleaning.Checked || cbMaintenance.Checked)
            {
                rtbDetails.Enabled = true;
            }
        }
    }
}
