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
    public partial class AddService : Form
    {
        private User activeUser;

        public AddService()
        {
            
            InitializeComponent();
            if (activeUser.Role != Role.HeadCleaner || activeUser.Role == Role.HeadEngineer)
            {
                MessageBox.Show("No Privileges");
                this.Close();
            }
            if (activeUser.Role == Role.HeadEngineer)
            {
                commentlbl.Text = "Defect omschrijving";
                sortsrvc_cb.Items.Add(RepairType.Maintenance);
                sortsrvc_cb.Items.Add(RepairType.Repair);
            }
            if (activeUser.Role == Role.HeadCleaner)
            {
                commentlbl.Text = "Opmerkingen";
                sortsrvc_cb.Items.Add(CleaningSize.Big);
                sortsrvc_cb.Items.Add(CleaningSize.Small);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<User> userList = new List<User>();
            string  sType = Convert.ToString(sortsrvc_cb.SelectedItem);
            string comment = commenttb.Text;


            if (activeUser.Role == Role.HeadCleaner)
            {
                // TODO: POST CLEAN LOG CODE
            }
            if (activeUser.Role == Role.HeadEngineer)
            {
                // TODO: POST REPAIR LOG CODE
            }
            else { }
            
        }
    }
}
