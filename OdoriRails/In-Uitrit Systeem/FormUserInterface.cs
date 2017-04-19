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

        public FormUserInterface(User driver)
        {
            InitializeComponent();
            Driver = driver;
            Logic = new Logic();
            Tram = (InUitRitTram)Logic._databaseConnector.GetTram(driver.Id);
            lblTramNumber.Text = Tram.Number.ToString();
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
            lblStandplaats.Text = Tram.Line.ToString();
        }

        private void cbMaintenance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCleaning.Checked)
            {
                rtbDetails.Enabled = true;
            }
        }
    }
}
