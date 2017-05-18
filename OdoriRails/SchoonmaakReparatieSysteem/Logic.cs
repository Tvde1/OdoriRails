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

        public bool AddServicetoDatabase(User activeUser, DateTime startdate, DateTime? enddate,
                                        ComboBox sortsrvc_cb, string comment, List<User> users, int tramNr)
        {
            if (activeUser.Role == Role.HeadCleaner && _repo.DoesTramExist(tramNr))
            {
                var cleaning = new Cleaning(startdate, enddate, (CleaningSize)sortsrvc_cb.SelectedIndex,
                    comment, users, tramNr);
                _repo.AddCleaning(cleaning);
                return true;
            }
            else if (activeUser.Role == Role.HeadEngineer && _repo.DoesTramExist(tramNr))
            {
                var repair = new Repair(startdate, enddate, (RepairType)sortsrvc_cb.SelectedIndex,
                    comment, "", users, tramNr);
                _repo.AddRepair(repair);
                return true;
            }
            return false;
        }

        public void UpdateCleaninginDatabase(User activeUser, Form targetform, DateTime startdate, DateTime? enddate,
                                            ComboBox sortsrvc_cb, RichTextBox commenttb, List<User> users, TextBox tramnrtb, Cleaning toupdatecleaning)
        {
            var cleaning = new Cleaning(startdate, enddate, (CleaningSize)sortsrvc_cb.SelectedIndex,
                commenttb.Text, users, Convert.ToInt32(tramnrtb.Text));
            cleaning.SetId(toupdatecleaning.Id);
            _repo.EditService(cleaning);

            targetform.Close();
        }

        public void UpdateRepairinDatabase(User activeUser, Form targetform, DateTime startdate, DateTime? enddate,
                                            ComboBox sortsrvc_cb, RichTextBox commenttb, List<User> users, TextBox tramnrtb, Repair repairtoupdate)
        {
            var repair = new Repair(startdate, enddate, (RepairType)sortsrvc_cb.SelectedIndex,
                commenttb.Text, "", users, Convert.ToInt32(tramnrtb.Text));
            repair.SetId(repairtoupdate.Id);
            _repo.EditService(repair);

            targetform.Close();
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

        public bool FinishService(DataGridView datagridview, Service servicetofinish)
        {
            if (datagridview.SelectedRows.Count != 0)
            {
                MarkAsDone mrk = new MarkAsDone(servicetofinish);
                mrk.ShowDialog();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddSolution(Repair repair, string solution)
        {
            repair.EndDate = DateTime.Now;
            _repo.SetTramStatusToIdle(repair.TramId);
            _repo.EditService(repair);
            _repo.AddSolution(repair, solution);
        }

        public bool DeleteService(DataGridView datagridview, Service servicetofinish)
        {
            if (datagridview.SelectedRows.Count != 0)
            {
                _repo.DeleteService(servicetofinish);
                return true;
            }
            else
            {
                return false;
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
                        Repair rep = new Repair(date, null, RepairType.Maintenance, "Big Planned Maintenance", "", emptylistusers, tram.Number);
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
                            Repair rep = new Repair(date, null, RepairType.Maintenance, "Small Planned Maintenance", "", emptylistusers, tram.Number);
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
                        Repair rep = new Repair(date, null, RepairType.Maintenance, "Big Planned Maintenance", "", emptylistusers, tram.Number);
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
                            Repair rep = new Repair(date, null, RepairType.Maintenance, "Small Planned Maintenance", "", emptylistusers, tram.Number);
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

        public List<User> GetAllUsersWithFunction(Role role)
        {
            return _repo.GetAllUsersWithFunction(role);
        }
    }
}