using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace In_Uitrit_Systeem
{
    public partial class FormUserInterface : Form
    {
        InUitRitTram Tram;

        public FormUserInterface()
        {
            InitializeComponent();
            lblTramNumber.Text = Tram.Number.ToString();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            string details = rtbDetails.Text; 
            if (cbCleaning.Checked && cbMaintenance.Checked)
            {
                //Tram.EditTramStatus(OdoriRails.TramStatus.CleaningMaintenance)
            }
            else if (cbCleaning.Checked)
            {
                Tram.EditTramStatus(OdoriRails.TramStatus.Cleaning);
            }
            else if (cbMaintenance.Checked)
            {
                Tram.EditTramStatus(OdoriRails.TramStatus.Maintenance); 
            }
            rtbDetails.Text = "";
            btnService.Enabled = false;
            lblStandplaats.Text = Tram.Line.ToString();
        }
    }
}
