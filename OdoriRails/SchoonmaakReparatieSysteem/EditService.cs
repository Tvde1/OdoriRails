using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdoriRails;

namespace SchoonmaakReparatieSysteem
{
    public partial class EditService : Form
    {
        private OdoriRails.User activeUser;
        public EditService(User activeuser)
        {
            activeUser = activeuser;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (activeUser.Role == OdoriRails.Role.HeadCleaner)
            {
                // TODO: POST CLEAN LOG CODE
            }
            if (activeUser.Role == OdoriRails.Role.HeadEngineer)
            {
                // TODO: POST REPAIR LOG CODE
            }
            // TODO: UPDATE QUERY HERE 
        }
    }
}
