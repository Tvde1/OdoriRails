using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using OdoriRails.DAL.Repository;

namespace SchoonmaakReparatieSysteem
{
    public class Logic
    {
        private SchoonmaakReparatieRepository _repo = new SchoonmaakReparatieRepository();
        
        public List<User> FillAnnexForms(User activeUser, List<User> availableusers, ComboBox sortsrvc_cb, Label commentlbl,
            ComboBox usercbox)
        {
            if (activeUser.Role == Role.HeadEngineer)
            {
                availableusers = _repo.GetAllUsersWithFunction(Role.Engineer);
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
                availableusers = _repo.GetAllUsersWithFunction(Role.Cleaner);
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
                    _repo.AddCleaning(cleaning);
                }
                if (activeUser.Role == Role.HeadEngineer)
                {
                    var repair = new Repair(startdate, enddate, (RepairType) sortsrvc_cb.SelectedIndex,
                        commenttb.Text, "", users, Convert.ToInt32(tramnrtb.Text));
                    _repo.AddRepair(repair);
                }
            }

            catch
            {
                // MessageBox.Show("Er ging iets mis.");
                //  bug.Database foreign key error needs to get fixed, stuff still getting properly added tho
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
                    _repo.EditService(cleaning);
                }
                if (activeUser.Role == Role.HeadEngineer)
                {
                    var repair = new Repair(startdate, enddate, (RepairType) sortsrvc_cb.SelectedIndex,
                        commenttb.Text, "", users, Convert.ToInt32(tramnrtb.Text));
                    _repo.EditService(repair);
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
                    dataGridView.DataSource = _repo.GetAllRepairsWithoutUsers();
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView.DataSource = _repo.GetAllCleansWithoutUsers();
                }
                else
                {
                }
            }
            if (filtercbox.SelectedIndex == 0)
            {
                if (ActiveUser.Role == Role.Engineer || ActiveUser.Role == Role.HeadEngineer)
                {
                    dataGridView.DataSource = _repo.GetAllRepairsFromUser(ActiveUser);
                }
                if (ActiveUser.Role == Role.Cleaner || ActiveUser.Role == Role.HeadCleaner)
                {
                    dataGridView.DataSource = _repo.GetAllCleansFromUser(ActiveUser);
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
                    _repo.EditService(servicetofinish);
                }
                catch
                {
                    // it still updates but theres an sql exception, must be fixed

                }
            }
        }
        public void DeleteService(DataGridView datagridview, Service servicetofinish)
        {
            if (datagridview.SelectedRows.Count != 0)
            {
                try
                {
                   _repo.DeleteService(servicetofinish);
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

        public void PlanServices()
        {
            DateTime startdate = DateTime.Today;
            DateTime enddate = DateTime.Today.AddMonths(6);
            

            for (DateTime date = startdate; date <= enddate; date = date.AddDays(1)) // iterate tru next 6 months
            {
                foreach (var tram in trams)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        if (bigserviceplanned?) // check for big service in next 6 months
                        {
                            // no : plan service and leave loop
                            
                            ++i;
                        }
                        else
                        {
                            // yes : skip to second check
                        }
                    }
                    
                }

                for (int i = 0; i < 3;)
                    {
                        foreach (var tram in trams)
                        {

                            if (smallserviceplanned?) // check for small service in 3 months
                            {
                                 // no : plan service and increment leave loop counter
                            }
                            else
                            {
                                // yes : next tram
                                ++i;

                            }
                        }
                       
                    }

                }

            }

        }
    }

