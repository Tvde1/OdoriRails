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
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {

        }

        private void btnLock_Click(object sender, EventArgs e)
        {

        }

        private void btnMove_Click(object sender, EventArgs e)
        {

        }

        private void btnSetDisabled_Click(object sender, EventArgs e)
        {

        }

        private void btnSimulation_Click(object sender, EventArgs e)
        {

        }

        private void btnChangeDisplayView_Click(object sender, EventArgs e)
        {
            if (btnChangeDisplayView.Text == "Display table")
            {
                btnChangeDisplayView.Text = "Display map";
            }
            else
            {
                btnChangeDisplayView.Text = "Display table";
            }
        }
    }
}
