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
            Timer refreshTimer = new Timer();
            refreshTimer.Tick += new EventHandler(refreshTimer_Tick);
            refreshTimer.Interval = 150000;
            refreshTimer.Start();

            _activeUser = user;
            usernamelbl.Text = _activeUser.Username;
            cboxFilter.SelectedIndex = 0;
        }

        void refreshTimer_Tick(object sender, EventArgs e)
        {
            _logic.RefreshDatagridView(_activeUser, cboxFilter, dataGridView);
        }

        private void MainService_Load(object sender, EventArgs e)
        {
            if (_activeUser.Role == Role.HeadEngineer || _activeUser.Role == Role.HeadCleaner)
            {
                btnAddService.Visible = true;
                btnEditService.Visible = true;
            }
            else
            {
                btnAddService.Visible = false;
                btnEditService.Visible = false;
            }
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            AddService addService = new AddService(_activeUser);
            addService.ShowDialog();
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (dataGridView.CurrentRow.DataBoundItem != null && dataGridView.SelectedRows.Count != 0)
            {
                if (_activeUser.Role == Role.HeadEngineer)
                {
                    Repair rep = (Repair)dataGridView.CurrentRow.DataBoundItem;
                    var editService = new EditService(_activeUser, rep);
                    editService.ShowDialog();
                }
                else if (_activeUser.Role == Role.HeadCleaner)
                {
                    Cleaning clean = (Cleaning)dataGridView.CurrentRow.DataBoundItem;
                    var editService = new EditService(_activeUser, clean);
                    editService.ShowDialog();
                }
                _logic.RefreshDatagridView(_activeUser, cboxFilter, dataGridView);
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            if (_logic.DeleteService(dataGridView, (Service)dataGridView.CurrentRow.DataBoundItem))
            { 
                _logic.RefreshDatagridView(_activeUser, cboxFilter, dataGridView);
            }
            else
            {
                MessageBox.Show("Selecteer eerst een service.");
            }
        }

        private void cboxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            _logic.RefreshDatagridView(_activeUser, cboxFilter, dataGridView);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            if (_logic.FinishService(dataGridView, (Service)dataGridView.CurrentRow.DataBoundItem))
            {
                _logic.RefreshDatagridView(_activeUser, cboxFilter, dataGridView);
            }
            else
            {
                MessageBox.Show("Selecteer eerst een service.");
            }
        }

        private void btnPlanServices_Click(object sender, EventArgs e)
        {
            _logic.PlanServicesTestData(7);
            _logic.RefreshDatagridView(_activeUser, cboxFilter, dataGridView);
        }

        private void btnMakeTestData_Click(object sender, EventArgs e)
        {
            _logic.PlanServices(7);
            _logic.RefreshDatagridView(_activeUser, cboxFilter, dataGridView);
        }

        private void btnTramLogs_Click(object sender, EventArgs e)
        {
            TramHistoryFilter trm = new TramHistoryFilter();
            trm.ShowDialog();
        }
    }
}
