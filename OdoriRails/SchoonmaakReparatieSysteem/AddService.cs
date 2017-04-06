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
    public partial class AddService : Form
    {
        User activeUser;
        public AddService(User activeuser)
        {
            activeUser = activeuser;
            InitializeComponent();
            if (!activeUser.IsAdmin)
            {
                MessageBox.Show("No Priviledges, get the fuck out");
                this.Close();
            }
            if (activeUser.Role == "Technicus")
            {
                commentlbl.Text = "Defect omschrijving";
            }
            if (activeUser.Role == "Schoonmaak")
            {
                commentlbl.Text = "Opmerkingen";
            }
            sortsrvc_cb.Items.Add(ServiceType.SMALL);
            sortsrvc_cb.Items.Add(ServiceType.LARGE);
            sortsrvc_cb.Items.Add(ServiceType.CUSTOM);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<User> userList = new List<User>();
            string  sType = Convert.ToString(sortsrvc_cb.SelectedItem);
            string comment = commenttb.Text;
            

            if (activeUser.Role == "Schoonmaak")
            {
                Cleaning cleaningLog = new Cleaning(Convert.ToInt32(datetb1.Text), Convert.ToInt32(datetb2.Text), Convert.ToInt32(datetb3.Text), comment, sType);    //TODO add repairlog
            }
            if(activeUser.Role == "Technicus")
            {
                Repair repair = new Repair(Convert.ToInt32(datetb1.Text), Convert.ToInt32(datetb2.Text), Convert.ToInt32(datetb3.Text), comment ,"", sType);   //TODO add schoonmaaklog
            }
            else { }
            
        }
    }
}
