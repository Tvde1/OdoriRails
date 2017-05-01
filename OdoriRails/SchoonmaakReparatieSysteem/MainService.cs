using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace SchoonmaakReparatieSysteem
{
    public partial class MainService : Form
    {
        private Logic _logic = new Logic();
        private readonly User _activeUser;

        public MainService(User user)
        {
            InitializeComponent();

            _logic.PlanServices();

            _activeUser = user;
            usernamelbl.Text = _activeUser.Username;
            filtercbox.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddService adsvc = new AddService(_activeUser);
            adsvc.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            { 
                _logic.UpdateService(_activeUser, dataGridView1, (Service)dataGridView1.CurrentRow.DataBoundItem);
            }
            catch
            {
                MessageBox.Show("select a service first my dude");
            }
        }

        private void MainService_Load(object sender, EventArgs e)
        {
            _logic.RefreshDatagridView(_activeUser, filtercbox, dataGridView1);

            if (_activeUser.Role == Role.HeadEngineer || _activeUser.Role == Role.HeadCleaner)
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
                _logic.DeleteService(dataGridView1, (Service)dataGridView1.CurrentRow.DataBoundItem);
                _logic.RefreshDatagridView(_activeUser, filtercbox, dataGridView1);
            }
            catch
            {
                MessageBox.Show("Select a service first my dude");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logic.RefreshDatagridView(_activeUser, filtercbox, dataGridView1);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            _logic.RefreshDatagridView(_activeUser, filtercbox, dataGridView1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _logic.FinishService(dataGridView1, (Service)dataGridView1.CurrentRow.DataBoundItem);
        }
    }
}
