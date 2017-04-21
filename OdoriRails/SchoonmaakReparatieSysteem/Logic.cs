using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL;

namespace SchoonmaakReparatieSysteem
{
    public class Logic
    {
        private IServiceContext _serviceContext = new ServiceContext();
        private IUserContext _userContext = new UserContext();

        public List<User> FillAnnexForms(User activeUser, List<User> availableusers, ComboBox sortsrvc_cb, Label commentlbl,
            ComboBox usercbox)
        {
            if (activeUser.Role == Role.HeadEngineer)
            {
                availableusers = _userContext.GetAllUsersWithFunction(Role.Engineer);
                foreach (User user in availableusers)
                {
                    usercbox.Items.Add(user.Name);
                }

                commentlbl.Text = "Defect omschrijving";
                sortsrvc_cb.Items.Add(RepairType.Maintenance);
                sortsrvc_cb.Items.Add(RepairType.Repair);
                return availableusers;
            }
            if (activeUser.Role == Role.HeadCleaner)
            {
                availableusers = _userContext.GetAllUsersWithFunction(Role.Cleaner);
                foreach (User user in availableusers)
                {
                    usercbox.Items.Add(user.Name);
                }

                commentlbl.Text = "Opmerkingen";
                sortsrvc_cb.Items.Add(CleaningSize.Big);
                sortsrvc_cb.Items.Add(CleaningSize.Small);
                return availableusers;
            }
            else
            {
                return null;
            }
        }

        public void AddServicetoDatabase(User activeUser, Form targetform, DateTime startdate, DateTime enddate,
            ComboBox sortsrvc_cb, RichTextBox commenttb,
            List<User> users, TextBox tramnrtb)
        {
            try
            {
                if (activeUser.Role == Role.HeadCleaner)
                {
                    var cleaning = new Cleaning(startdate, enddate, (CleaningSize) sortsrvc_cb.SelectedIndex,
                        commenttb.Text, users, Convert.ToInt32(tramnrtb.Text));
                    _serviceContext.AddCleaning(cleaning);
                }
                if (activeUser.Role == Role.HeadEngineer)
                {
                    var repair = new Repair(startdate, enddate, (RepairType) sortsrvc_cb.SelectedIndex,
                        commenttb.Text, "", users, Convert.ToInt32(tramnrtb.Text));
                    _serviceContext.AddRepair(repair);
                }
            }

            catch
            {
                MessageBox.Show("Er ging iets mis.");
            }
            finally
            {
                targetform.Close();
            }
        }

        public void UpdateServiceinDatabase(User activeUser, Form targetform, DateTime startdate, DateTime enddate,
            ComboBox sortsrvc_cb, RichTextBox commenttb,
            List<User> users, TextBox tramnrtb)
        {
            try
            {
                if (activeUser.Role == Role.HeadCleaner)
                {
                    var cleaning = new Cleaning(startdate, enddate, (CleaningSize) sortsrvc_cb.SelectedIndex,
                        commenttb.Text, users, Convert.ToInt32(tramnrtb.Text));
                    _serviceContext.EditService(cleaning);
                }
                if (activeUser.Role == Role.HeadEngineer)
                {
                    var repair = new Repair(startdate, enddate, (RepairType) sortsrvc_cb.SelectedIndex,
                        commenttb.Text, "", users, Convert.ToInt32(tramnrtb.Text));
                    _serviceContext.EditService(repair);
                }
            }

            catch
            {
                MessageBox.Show("Er ging iets mis.");
            }
            finally
            {
                targetform.Close();
            }
        }

        public void RefreshDatagridView(User ActiveUser, ComboBox filtercbox, DataGridView dataGridView)
        {

            if (filtercbox.SelectedIndex == 1)
            {
                if (ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
                {
                    dataGridView.DataSource = _serviceContext.GetAllRepairsWithoutUsers();
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView.DataSource = _serviceContext.GetAllCleansWithoutUsers();
                }
                else
                {
                }
            }
            if (filtercbox.SelectedIndex == 0)
            {
                if (ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
                {
                    dataGridView.DataSource = _serviceContext.GetAllRepairsFromUser(ActiveUser);
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView.DataSource = _serviceContext.GetAllCleansFromUser(ActiveUser);
                }
            }
        }

        public void FinishService(DataGridView datagridview, Service servicetofinish)
        {
            if (datagridview.SelectedRows.Count != 0)
            {
                try
                {
                    servicetofinish.EndDate = DateTime.Now;
                    _serviceContext.EditService(servicetofinish);
                }
                catch
                {
                    // it still updates but theres an sql exception, must be fixed

                }
            }
        }

        public void UpdateService(User ActiveUser, DataGridView datagridview, Service servicetofinish)
        {
            if (datagridview.SelectedRows.Count != 0)
            {
                try

                {
                    var servicetoupdate = (Service)datagridview.CurrentRow.DataBoundItem;
                    var edsrvc = new EditService(ActiveUser, servicetoupdate);
                    edsrvc.Show();

                }
                catch
                {
                    MessageBox.Show("Something went wrong with deleting the service");
                }

            }
        }
    }
}
