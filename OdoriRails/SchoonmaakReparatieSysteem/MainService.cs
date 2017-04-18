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
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace SchoonmaakReparatieSysteem
{
    public partial class MainService : Form
    {
        private int username = 1; // testing purposes\
        private IDatabaseConnector dbconnector = new MySqlContext();

        private Role role = Role.HeadEngineer; // testing purposes

        public User ActiveUser;


        public MainService()
        {
            InitializeComponent();
            ActiveUser = new User(username, "Jimmy", "jimmy", "","", role, "");
            usernamelbl.Text = ActiveUser.Username;
            dataGridView1.DataSource = dbconnector.GetAllServicesFromUser(ActiveUser);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddService adsvc = new AddService(ActiveUser);
            adsvc.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var edsrvc = new EditService(ActiveUser);
            edsrvc.Show();
        }

        private void MainService_Load(object sender, EventArgs e)
        {

            dbconnector.GetAllServicesFromUser(ActiveUser);

            if (ActiveUser.Role == Role.HeadEngineer || ActiveUser.Role == Role.HeadCleaner)
            {
                
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                
                button1.Visible = false;
                button2.Visible = false;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                try
                {
                    var servicetodelete = (Service) dataGridView1.CurrentRow.DataBoundItem;
                    dbconnector.DeleteService(servicetodelete);
                }
                catch
                {
                    MessageBox.Show("Something went wrong with deleting the service");
                }
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (filtercbox.SelectedIndex == 1)
            {
                if (ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
                {
                    dataGridView1.DataSource = dbconnector.GetAllRepairsWithoutUsers();
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView1.DataSource = dbconnector.GetAllRepairsWithoutUsers();
                }
                else
                {
                }
            }
            if (filtercbox.SelectedIndex == 0)
            {
                dataGridView1.DataSource = dbconnector.GetAllServicesFromUser(ActiveUser);
            }
            
        }
    }
}
