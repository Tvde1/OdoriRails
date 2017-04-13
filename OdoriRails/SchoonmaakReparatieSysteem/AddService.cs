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
        private OdoriRails.User activeUser;

        public AddService(OdoriRails.User activeuser)
        {
            activeUser = activeuser;
            InitializeComponent();
            if (activeUser.Role != OdoriRails.Role.HeadCleaner || activeUser.Role == Role.HeadEngineer)
            {
                MessageBox.Show("No Privileges");
                this.Close();
            }
            if (activeUser.Role == OdoriRails.Role.HeadEngineer)
            {
                commentlbl.Text = "Defect omschrijving";
                sortsrvc_cb.Items.Add(OdoriRails.RepairType.Maintenance);
                sortsrvc_cb.Items.Add(OdoriRails.RepairType.Repair);
            }
            if (activeUser.Role == OdoriRails.Role.HeadCleaner)
            {
                commentlbl.Text = "Opmerkingen";
                sortsrvc_cb.Items.Add(OdoriRails.CleaningSize.Big);
                sortsrvc_cb.Items.Add(OdoriRails.CleaningSize.Small);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<OdoriRails.User> userList = new List<User>();
            string  sType = Convert.ToString(sortsrvc_cb.SelectedItem);
            string comment = commenttb.Text;


            if (activeUser.Role == OdoriRails.Role.HeadCleaner)
            {
                
                // TODO: POST CLEAN LOG CODE: INSERT A CLEANING SERVICE INTO DATABASE
            }
            if (activeUser.Role == OdoriRails.Role.HeadEngineer)
            {
                // TODO: POST REPAIR LOG CODE: INSERT A REPAIR SERVICE INTO DATABASE
            }
            else { }
            
        }

        private void AddService_Load(object sender, EventArgs e)
        {
           
        }
    }
}
