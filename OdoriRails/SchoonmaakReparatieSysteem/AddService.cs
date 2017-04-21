using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;
using System.Linq;

namespace SchoonmaakReparatieSysteem
{
    public partial class AddService : Form
    {
        private User activeUser;
        private ISchoonmaakReparatieDatabaseAdapter dbconnector = new MssqlDatabaseContext();
        private List<User> users = new List<User>();
        private List<User> availableusers = new List<User>();
        public AddService(User activeuser)
        {
            activeUser = activeuser;
            InitializeComponent();
            

            if (activeUser.Role == Role.HeadEngineer)
            {
                availableusers = dbconnector.GetAllUsersWithRole(Role.Engineer);
                foreach (User user in availableusers)
                {
                    usercbox.Items.Add(user.Name);
                }

                commentlbl.Text = "Defect omschrijving";
                sortsrvc_cb.Items.Add(RepairType.Maintenance);
                sortsrvc_cb.Items.Add(RepairType.Repair);
            }
            if (activeUser.Role == Role.HeadCleaner)
            {
                availableusers = dbconnector.GetAllUsersWithRole(Role.Cleaner);
                foreach (User user in availableusers)
                {
                    usercbox.Items.Add(user.Name);
                }

                commentlbl.Text = "Opmerkingen";
                sortsrvc_cb.Items.Add(CleaningSize.Big);
                sortsrvc_cb.Items.Add(CleaningSize.Small);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<User> userList = new List<User>();
            string sType = Convert.ToString(sortsrvc_cb.SelectedItem);
            string comment = commenttb.Text;
            DateTime startdate = dateTimePicker1.Value;
            DateTime enddate = DateTime.MaxValue;
            try
            {
                if (activeUser.Role == Role.HeadCleaner)
                {
                    var cleaning = new Cleaning(startdate, enddate, (CleaningSize) sortsrvc_cb.SelectedIndex,
                        commenttb.Text, users, Convert.ToInt32(tramnrtb.Text));
                    dbconnector.AddCleaning(cleaning);
                }
                if (activeUser.Role == Role.HeadEngineer)
                {
                    var repair = new Repair(startdate, enddate, (RepairType) sortsrvc_cb.SelectedIndex,
                        commenttb.Text, "", users, Convert.ToInt32(tramnrtb.Text));
                    dbconnector.AddRepair(repair);
                }
            }

            catch
            {
                MessageBox.Show("Er ging iets mis. Roep Hugo.");
            }
            finally
            {
                this.Close();
            }
        
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            usersListBox.Items.Add(usercbox.SelectedItem);
            users.Add(availableusers.ElementAt(usercbox.SelectedIndex));
        }
    }
}
