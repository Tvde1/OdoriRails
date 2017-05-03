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

namespace SchoonmaakReparatieSysteem
{
    public partial class MarkAsDone : Form
    {
        private Logic _logic;
        private Service servicetofinish;
        private string solution;
        
        public MarkAsDone(Service service)
        {
            _logic = new Logic();
            servicetofinish = service;
            InitializeComponent();
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            solution = solutiontb.Text;
            _logic.AddSolution((Repair)servicetofinish, solution);
            
            Close();
        }
    }
}
