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

        //private ISchoonmaakReparatieDatabaseAdapter dbconnector = new MssqlDatabaseContext();
     
        private Logic logic = new Logic();
        public User ActiveUser;
        private List<Repair> replist;
        private List<Cleaning> cleanlist;

        public MainService(User user)
        {
            InitializeComponent();
            ActiveUser = user;
            usernamelbl.Text = ActiveUser.Username;
            filtercbox.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddService adsvc = new AddService(ActiveUser);
            adsvc.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                logic.UpdateService(ActiveUser, dataGridView1, (Service) dataGridView1.CurrentRow.DataBoundItem);

            }
            catch
            {
                MessageBox.Show("select a service first my dude");
            } 
        }

        private void MainService_Load(object sender, EventArgs e)
        {
            logic.RefreshDatagridView(ActiveUser, filtercbox, dataGridView1);

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
            try
            {
                logic.FinishService(dataGridView1, (Service) dataGridView1.CurrentRow.DataBoundItem);
            }
            catch
            {
                MessageBox.Show("Select a service first my dude");
            }
      }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            logic.RefreshDatagridView(ActiveUser, filtercbox, dataGridView1);
    
        }

        private void button3_Click(object sender, EventArgs e)
        {
            logic.RefreshDatagridView(ActiveUser, filtercbox, dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            logic.FinishService(dataGridView1, (Service)dataGridView1.CurrentRow.DataBoundItem); 
        }
    }
}
