using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoonmaakReparatieSysteem
{
    public partial class TramHistoryFilter : Form
    {
        private Logic _logic;
        public TramHistoryFilter()
        {
            _logic = new Logic();
            InitializeComponent();
        }

        private void zoekbtn_Click(object sender, EventArgs e)
        {
            _logic.ZoekPerTramNummer(Convert.ToInt32(numericUpDown1.Value), dataGridView1);
        }
    }
}
