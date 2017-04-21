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
        private IServiceContext _serviceContext = new ServiceContext();
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
            if (dataGridView1.SelectedRows.Count != 0)
            {
                try

                {
                    var servicetoupdate = (Service)dataGridView1.CurrentRow.DataBoundItem;
                    var edsrvc = new EditService(ActiveUser, servicetoupdate);
                    edsrvc.Show();
                    
                }
                catch
                {
                    MessageBox.Show("Something went wrong with deleting the service");
                }

            }
            
        }

        private void MainService_Load(object sender, EventArgs e)
        {


            if(ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
            {
                dataGridView1.DataSource = _serviceContext.GetAllRepairsFromUser(ActiveUser);
            }
            if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
            {
                dataGridView1.DataSource = _serviceContext.GetAllCleansFromUser(ActiveUser);
            }

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
                    var servicetodelete = (Service)dataGridView1.CurrentRow.DataBoundItem;
                    _serviceContext.DeleteService(servicetodelete);
                }
                catch
                {
                 // it still deletes but theres an sql exception, must be fixed

                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (filtercbox.SelectedIndex == 1)
            {
                if (ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
                {
                    dataGridView1.DataSource = _serviceContext.GetAllRepairsWithoutUsers();
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView1.DataSource = _serviceContext.GetAllCleansWithoutUsers();
                }
                else
                {
                }
            }
            if (filtercbox.SelectedIndex == 0)
            {
                if (ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
                {
                    dataGridView1.DataSource = _serviceContext.GetAllRepairsFromUser(ActiveUser);
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView1.DataSource = _serviceContext.GetAllCleansFromUser(ActiveUser);
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (filtercbox.SelectedIndex == 1)
            {
                if (ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
                {
                    dataGridView1.DataSource = _serviceContext.GetAllRepairsWithoutUsers();
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView1.DataSource = _serviceContext.GetAllCleansWithoutUsers();
                }
                else
                {
                }
            }
            if (filtercbox.SelectedIndex == 0)
            {
                if (ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
                {
                    dataGridView1.DataSource = _serviceContext.GetAllRepairsFromUser(ActiveUser);
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView1.DataSource = _serviceContext.GetAllCleansFromUser(ActiveUser);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                try
                {
                    var servicetofinish = (Service) dataGridView1.CurrentRow.DataBoundItem;
                    servicetofinish.EndDate = DateTime.Now;
                    _serviceContext.EditService(servicetofinish);
                }
                catch
                {
                    // it still updates but theres an sql exception, must be fixed

                }
            }
        }
    }
}
