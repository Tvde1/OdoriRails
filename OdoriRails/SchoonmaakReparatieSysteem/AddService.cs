using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdoriRails;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace SchoonmaakReparatieSysteem
{
    public partial class AddService : Form
    {
        private User activeUser;
        private IDatabaseConnector dbconnector = new MySqlContext();
        private List<User> users = new List<User>();
        public AddService(User activeuser)
        {
            activeUser = activeuser;
            InitializeComponent(); 

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<User> userList = new List<User>();
            string  sType = Convert.ToString(sortsrvc_cb.SelectedItem);
            string comment = commenttb.Text;


            if (activeUser.Role == Role.HeadCleaner)
            {
                var cleaning = new Cleaning(dateTimePicker1.Value, DateTime.MinValue, (CleaningSize)sortsrvc_cb.SelectedIndex, commenttb.Text, users, Convert.ToInt32(tramnrtb.Text));
                dbconnector.AddCleaning(cleaning);
               
            }
            if (activeUser.Role == Role.HeadEngineer)
            {
                
                var repair = new Repair(dateTimePicker1.Value, DateTime.MinValue, (RepairType)sortsrvc_cb.SelectedIndex, commenttb.Text, "", users, Convert.ToInt32(tramnrtb.Text));
                dbconnector.AddRepair(repair);
               
            }
           
            
        }

        private void AddService_Load(object sender, EventArgs e)
        {
            if (activeUser.Role != Role.HeadCleaner && activeUser.Role != Role.HeadEngineer)
            {
                MessageBox.Show("No Privileges");
                this.Close();
            }
            if (activeUser.Role == Role.HeadEngineer)
            {
                foreach (var user in dbconnector.GetAllUsersWithRole(Role.Engineer))
                {
                    users.Add(user);
                }

                commentlbl.Text = "Defect omschrijving";
                sortsrvc_cb.Items.Add(RepairType.Maintenance);
                sortsrvc_cb.Items.Add(RepairType.Repair);
            }
            if (activeUser.Role == Role.HeadCleaner)
            {
                foreach (var user in dbconnector.GetAllUsersWithRole(Role.Cleaner))
                {
                    users.Add(user);
                }

                commentlbl.Text = "Opmerkingen";
                sortsrvc_cb.Items.Add(CleaningSize.Big);
                sortsrvc_cb.Items.Add(CleaningSize.Small);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var user = usercbox.SelectedItem;
            
        }
    }
}
