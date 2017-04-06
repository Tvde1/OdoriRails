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
    public partial class MainService : Form
    {
        private string username = "durr";
        private string role = "Technicus";
        public User activeUser;

        public string Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
            }
        }

        public MainService()
        {
            InitializeComponent();
            activeUser = new User(username, Role);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddService adsvc = new AddService(this.activeUser);
            adsvc.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditService edsrvc = new EditService(this.activeUser);
            edsrvc.Show();
        }
    }
}
