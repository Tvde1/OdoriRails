﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdoriRails;

namespace In_Uitrit_Systeem
{
    public partial class FormUserInterface : Form
    {
        IDatabaseConnector _databaseConnector = new MySqlContext();
        Logic Logic;
        InUitRitTram Tram;
        User Driver;

        public FormUserInterface(User driver)
        {
            InitializeComponent();
            Driver = driver;
            Tram = (InUitRitTram)_databaseConnector.GetTram(0);
            Logic = new Logic();
            lblTramNumber.Text = Tram.Number.ToString();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            string details = rtbDetails.Text; 
            if (cbCleaning.Checked && cbMaintenance.Checked)
            {
                //Tram.EditTramStatus(OdoriRails.TramStatus.CleaningMaintenance)
                Tram.AddRepair(details);
                Tram.AddCleaning(details);
            }
            else if (cbCleaning.Checked)
            {
                Tram.EditTramStatus(OdoriRails.TramStatus.Cleaning);
                Tram.AddCleaning(details);
            }
            else if (cbMaintenance.Checked)
            {
                Tram.EditTramStatus(OdoriRails.TramStatus.Maintenance);
                Tram.AddRepair(details);
            }
            rtbDetails.Text = "";
            btnService.Enabled = false;
            lblStandplaats.Text = Tram.Line.ToString();
        }
    }
}
