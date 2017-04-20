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
    public partial class EditService : Form
    {
        private User activeUser;
        private Service service;
        private ISchoonmaakReparatieDatabaseAdapter dbconnector = new MssqlDatabaseContext();
        List<User> users = new List<User>();
        public EditService(User activeuser, Service svc)
        {
            activeUser = activeuser;
            service = svc;
            InitializeComponent();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            dbconnector.EditService(service);
   
        }

        private void EditService_Load(object sender, EventArgs e)
        {
            if (activeUser.Role != Role.HeadCleaner || activeUser.Role != Role.HeadEngineer)
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
    }
}
