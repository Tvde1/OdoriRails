using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Beheersysteem.DAL.Repository;
using OdoriRails.BaseClasses;

namespace SchoonmaakReparatieSysteem
{
    public class Logic
    {
        private SchoonmaakReparatieRepository _repo = new SchoonmaakReparatieRepository();
        private LogisticRepository _repolog = new LogisticRepository();

        public List<User> FillAnnexForms(User activeUser, List<User> availableusers, ComboBox sortsrvc_cb, Label commentlbl, ComboBox usercbox)
        {
            if (activeUser.Role == Role.HeadEngineer)
            {
                availableusers = _repo.GetAllUsersWithFunction(Role.Engineer);
                availableusers.AddRange(_repo.GetAllUsersWithFunction(Role.HeadEngineer));
                foreach (User user in availableusers)
                {
                    usercbox.Items.Add(user.Name);
                }

                commentlbl.Text = "Omschrijving:";
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

                commentlbl.Text = "Opmerkingen:";
                sortsrvc_cb.Items.Add(CleaningSize.Big);
                sortsrvc_cb.Items.Add(CleaningSize.Small);
                return availableusers;
            }
            else
            {
                return null;
            }
        }

        public void AddServicetoDatabase(User activeUser, Form targetform, DateTime startdate, DateTime? enddate,
                                        ComboBox sortsrvc_cb, RichTextBox commenttb, List<User> users, TextBox tramnrtb)
        {
            try
            {
                if (activeUser.Role == Role.HeadCleaner)
                {
                    var cleaning = new Cleaning(startdate, enddate, (CleaningSize)sortsrvc_cb.SelectedIndex,
                        commenttb.Text, users, Convert.ToInt32(tramnrtb.Text));
                    _repo.AddCleaning(cleaning);
                }
                if (activeUser.Role == Role.HeadEngineer)
                {
                    var repair = new Repair(startdate, enddate, (RepairType)sortsrvc_cb.SelectedIndex,
                        commenttb.Text, "", users, Convert.ToInt32(tramnrtb.Text));
                    _repo.AddRepair(repair);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Er ging iets mis." + Environment.NewLine + "Error: " + e.Message);
            }
            finally
            {
                targetform.Close();
            }
        }

        public void UpdateCleaninginDatabase(User activeUser, Form targetform, DateTime startdate, DateTime? enddate,
                                            ComboBox sortsrvc_cb, RichTextBox commenttb, List<User> users, TextBox tramnrtb, Cleaning toupdatecleaning)
        {
            try
            {
                var cleaning = new Cleaning(startdate, enddate, (CleaningSize)sortsrvc_cb.SelectedIndex,
                    commenttb.Text, users, Convert.ToInt32(tramnrtb.Text));
                cleaning.SetId(toupdatecleaning.Id);
                _repo.EditService(cleaning);

            }
            catch (Exception e)
            {
                MessageBox.Show("Er ging iets mis." + Environment.NewLine + "Error: " + e.Message);
            }
            finally
            {
                targetform.Close();
            }
        }

        public void UpdateRepairinDatabase(User activeUser, Form targetform, DateTime startdate, DateTime? enddate,
                                            ComboBox sortsrvc_cb, RichTextBox commenttb, List<User> users, TextBox tramnrtb, Repair repairtoupdate)
        {
            try
            {
                var repair = new Repair(startdate, enddate, (RepairType)sortsrvc_cb.SelectedIndex,
                    repairtoupdate.Defect, commenttb.Text, users, Convert.ToInt32(tramnrtb.Text));
                repair.SetId(repairtoupdate.Id);
                _repo.EditService(repair);
            }
            catch (Exception e)
            {
                MessageBox.Show("Er ging iets mis." + Environment.NewLine + "Error: " + e.Message);
            }
            finally
            {
                targetform.Close();
            }
        }

        //REFRESH THE DATAGRIDVIEW
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
                    MarkAsDone mrk = new MarkAsDone(servicetofinish);
                    mrk.Show();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Er ging iets mis." + Environment.NewLine + "Error: " + e.Message);
                }
            }
        }

        public void AddSolution(Repair repair, string solution)
        {
            
            repair.EndDate = DateTime.Now;
            _repo.SetTramStatusToIdle(repair.TramId);
            _repo.EditService(repair);
            _repo.AddSolution(repair, solution);
        }

        public void DeleteService(DataGridView datagridview, Service servicetofinish)
        {
            if (datagridview.SelectedRows.Count != 0)
            {
                try
                {
                    _repo.DeleteService(servicetofinish);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Er ging iets mis." + Environment.NewLine + "Error: " + e.Message);
                }
            }
        }

        public void PlanServices(int daystoenddate)
        {
            DateTime startdate = DateTime.Today;
            DateTime enddate = DateTime.Today.AddDays(daystoenddate);

            List<Tram> trams;
            List<User> emptylistusers = new List<User>();
            trams = _repolog.GetAllTrams();

            for (var date = startdate; date <= enddate; date = date.AddDays(1)) // iterate through the next 15 days
            {
                foreach (var tram in trams)
                {
                    if (_repolog.HadBigMaintenance(tram) == false && tram.Number != 1) // check for big service in next 7 days
                    {
                        // no : plan service and leave loop
                        Repair rep = new Repair(date, DateTime.MinValue, RepairType.Maintenance, "Big Planned Maintenance", "", emptylistusers, tram.Number);
                        _repo.AddRepair(rep);
                        break;
                    }
                    else
                    {
                        // yes : skip to second check
                    }
                }

                for (int i = 0; i <= 3;) // checks three times for small services, 
                {
                    foreach (var tram in trams)
                    {
                        if (_repolog.HadSmallMaintenance(tram) == false && tram.Number != 1) // check for small service in 3 months
                        {
                            Repair rep = new Repair(date, DateTime.MinValue, RepairType.Maintenance, "Small Planned Maintenance", "", emptylistusers, tram.Number);
                            _repo.AddRepair(rep);
                            i++;
                            break;
                        }
                        else
                        {
                            // yes : next tram
                        }
                    }
                }

            }
        }

        public void PlanServicesTestData(int daystoenddate)
        {
            DateTime enddate = DateTime.Today;
            DateTime startdate = enddate.Subtract(TimeSpan.FromDays(daystoenddate));
           
            List<Tram> trams;
            List<User> emptylistusers = new List<User>();
            trams = _repolog.GetAllTrams();

            for (var date = startdate; date <= enddate; date = date.AddDays(1)) // iterate through the next 15 days
            {
                foreach (var tram in trams)
                {
                    if (_repolog.HadBigMaintenance(tram) == false && tram.Number != 1) // check for big service in next 7 days
                    {
                        // no : plan service and leave loop
                        Repair rep = new Repair(date, DateTime.MinValue, RepairType.Maintenance, "Big Planned Maintenance", "", emptylistusers, tram.Number);
                        _repo.AddRepair(rep);
                        break;
                    }
                    else
                    {
                        // yes : skip to second check
                    }
                }

                for (int i = 0; i <= 3;) // checks three times for small services, 
                {
                    foreach (var tram in trams)
                    {
                        if (_repolog.HadSmallMaintenance(tram) == false && tram.Number != 1) // check for small service in 3 months
                        {
                            Repair rep = new Repair(date, DateTime.MinValue, RepairType.Maintenance, "Small Planned Maintenance", "", emptylistusers, tram.Number);
                            _repo.AddRepair(rep);
                            i++;
                            break;
                        }
                        else
                        {
                            // yes : next tram
                        }
                    }
                }

            }
        }

        public void ZoekPerTramNummer(int tramnr, DataGridView dgv)
        {
            dgv.DataSource = _repo.GetAllRepairsFromTram(tramnr);
        }
    }
}

