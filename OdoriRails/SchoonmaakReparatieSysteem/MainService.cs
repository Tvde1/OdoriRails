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
    public partial class MainService : Form
    {
        private int username = 1; // testing purposes
        private OdoriRails.Role role = OdoriRails.Role.HeadEngineer; // testing purposes

        public OdoriRails.User activeUser;


        public MainService()
        {
            InitializeComponent();
            activeUser = new OdoriRails.User(username, "Jimmy", "jimmy", "","", OdoriRails.Role.HeadEngineer, "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddService adsvc = new AddService(activeUser);
            adsvc.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditService edsrvc = new EditService(activeUser);
            edsrvc.Show();
        }

        private void MainService_Load(object sender, EventArgs e)
        {
            // TODO: SELECT ALL FROM SERVICE, DIFFERS DEPENDING ON USER ROLE
            if (activeUser.Role == OdoriRails.Role.Engineer)
            {
                //TODO: LOAD ALL SERVICES FOR LOGGED IN USER
            }
            if (activeUser.Role == OdoriRails.Role.Cleaner)
            {
                //TODO: LOAD ALL SERVICES FOR LOGGED IN USER
            }


            if (activeUser.Role == OdoriRails.Role.HeadEngineer || activeUser.Role == OdoriRails.Role.HeadCleaner)
            {
                //TODO: LOAD ALL SERVICES FOR THE DAY-
                button1.Visible = true;
                button2.Visible = true;
            }
            else
            {
                //TODO: LOAD ALL SERVICES FOR THE DAY
                button1.Visible = false;
                button2.Visible = false;
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.SelectedRows[0];
        }
    }
}
