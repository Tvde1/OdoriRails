using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace In_Uitrit_Systeem
{
    public partial class UserInterface : Form
    {
        private Logic _logic;
        private Timer _DriverTramUpdater;
        private int _timerTickIn;
        private int _timerTickOut;

        public UserInterface(User driver)
        {
            InitializeComponent();
            _logic = new Logic(driver);

            _DriverTramUpdater = new Timer { Interval = 2500 };
            _DriverTramUpdater.Tick += DriverTramUpdater_Tick;

            _DriverTramUpdater.Start();
            DriverTramUpdater_Tick(null, EventArgs.Empty);
        }

        private void DriverTramUpdater_Tick(object sender, EventArgs e)
        {
            DisableFormButtons();
            if (_logic.Tram != null)
            {
                _logic.FetchTramUpdates();
                lblTramNumber.Text = _logic.Tram?.Number.ToString();
                DisableFormButtons();
                switch (_logic.Tram.Location)
                {
                    case TramLocation.In:
                        btnLeave.Enabled = true;
                        lblLocation.Text = _logic.GetAssingedTramLocation() ?? "Niet bekend";
                        break;
                    case TramLocation.ComingIn:
                        if (_timerTickIn == 10)
                        {
                            _timerTickIn = 0;
                            string error = string.Format("Tram {0} kan niet worden aangemeld.{1}Neem contact op met een logistiek medewerker of probeer het opnieuw.", 
                                                            _logic.Tram.Number.ToString(), Environment.NewLine);
                            MessageBox.Show(error, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _logic.Tram.EditTramLocation(TramLocation.Out);
                            _logic.UpdateTram();
                        }
                        _timerTickIn++;
                        break;
                    case TramLocation.Out:
                        cbCleaning.Enabled = true;
                        cbMaintenance.Enabled = true;
                        btnService.Enabled = true;
                        lblLocation.Text = "Onderweg";
                        break;
                    case TramLocation.GoingOut:
                        if (_timerTickOut == 10)
                        {
                            _timerTickOut = 0;
                            string error = string.Format("Tram {0} kan niet worden aangemeld voor vertrek.{1}Neem contact op met een logistiek medewerker of probeer het opnieuw.", 
                                                            _logic.Tram.Number.ToString(), Environment.NewLine);
                            MessageBox.Show(error, "Fout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            _logic.Tram.EditTramLocation(TramLocation.In);
                            _logic.UpdateTram();
                        }
                        _timerTickOut++;
                        break;
                }
            }
            else
            {
                _logic.LoadTram();
            }
        }

        public void DisableFormButtons()
        {
            btnLeave.Enabled = false;
            btnService.Enabled = false;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            string defect = rtbDetails.Text;
            if (cbCleaning.Checked && cbMaintenance.Checked)
            {
                _logic.Tram.EditTramStatus(TramStatus.CleaningMaintenance);
                _logic.AddRepair(defect);
                _logic.AddCleaning();
            }
            else if (cbCleaning.Checked)
            {
                _logic.Tram.EditTramStatus(TramStatus.Cleaning);
                _logic.AddCleaning();
            }
            else if (cbMaintenance.Checked)
            {
                _logic.Tram.EditTramStatus(TramStatus.Maintenance);
                _logic.AddRepair(defect);
            }

            lblLocation.Text = "Wordt opgehaald.";
            rtbDetails.Text = "";
            cbCleaning.Checked = false;
            cbMaintenance.Checked = false;

            _logic.Tram.EditTramLocation(TramLocation.ComingIn);
            _logic.UpdateTram();
            DisableFormButtons();
        }

        private void btnLeave_Click(object sender, EventArgs e)
        {
            lblLocation.Text = "Wordt opgehaald.";

            _logic.Tram.EditTramLocation(TramLocation.GoingOut);
            _logic.Tram.ResetTramDeparture();
            _logic.UpdateTram();
            DisableFormButtons();
        }

        private void cbMaintenance_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCleaning.Checked || cbMaintenance.Checked)
            {
                rtbDetails.Enabled = true;
            }
            else
            {
                rtbDetails.Enabled = false;
            }
        }

        private void cbCleaning_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCleaning.Checked || cbMaintenance.Checked)
            {
                rtbDetails.Enabled = true;
            }
            else
            {
                rtbDetails.Enabled = false;
            }
        }
    }
}
