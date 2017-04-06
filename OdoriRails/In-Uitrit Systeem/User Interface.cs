using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beheersysteem
{
    public partial class FormUserInterface : Form
    {
        public FormUserInterface()
        {
            InitializeComponent();
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            if (cbCleaning.Checked)
            {

            }
            if (cbMaintenance.Checked)
            {

            }
            if (cbCleaning.Checked && cbMaintenance.Checked)
            {

            }
        }
    }
}
