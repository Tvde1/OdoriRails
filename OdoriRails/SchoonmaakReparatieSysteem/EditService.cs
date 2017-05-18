using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace SchoonmaakReparatieSysteem
{
    public partial class EditService : Form
    {
        private User activeUser;
        private Service serviceToUpdate;
        private Logic logic = new Logic();
        private List<User> users = new List<User>();
        private List<User> availableUsers;

        public EditService(User activeUser, Service serviceToUpdate)
        {
            InitializeComponent();
            this.activeUser = activeUser;
            this.serviceToUpdate = serviceToUpdate;
            availableUsers = FillAnnexForms();
            if (serviceToUpdate.GetType().Name == "Repair")
            {
                var rep = (Repair)serviceToUpdate;
                sortsrvc_cb.Text = rep.Type.ToString();
                dateTimePicker1.MinDate = rep.StartDate;
                tbTramNr.Text = rep.TramId.ToString();
                rtbComment.Text = rep.Defect;
            }
            else if (serviceToUpdate.GetType().Name == "Cleaning")
            {
                var cln = (Cleaning)serviceToUpdate;
                sortsrvc_cb.Text = cln.Size.ToString();
                dateTimePicker1.MinDate = cln.StartDate;
                tbTramNr.Text = cln.TramId.ToString();
                rtbComment.Text = cln.Comments;
            }
        }

        public List<User> FillAnnexForms()
        {
            if (activeUser.Role == Role.HeadEngineer)
            {
                availableUsers = logic.GetAllUsersWithFunction(Role.Engineer);
                availableUsers.AddRange(logic.GetAllUsersWithFunction(Role.HeadEngineer));
                foreach (User user in availableUsers)
                {
                    usercbox.Items.Add(user.Name);
                }

                commentlbl.Text = "Omschrijving:";
                sortsrvc_cb.Items.Add(RepairType.Maintenance);
                sortsrvc_cb.Items.Add(RepairType.Repair);
                return availableUsers;
            }

            else if (activeUser.Role == Role.HeadCleaner)
            {
                availableUsers = logic.GetAllUsersWithFunction(Role.Cleaner);
                foreach (User user in availableUsers)
                {
                    usercbox.Items.Add(user.Name);
                }

                commentlbl.Text = "Opmerkingen:";
                sortsrvc_cb.Items.Add(CleaningSize.Big);
                sortsrvc_cb.Items.Add(CleaningSize.Small);
                return availableUsers;
            }
            else
            {
                return null;
            }
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (serviceToUpdate.GetType().Name == "Repair")
            {
                logic.UpdateRepairinDatabase(activeUser, this, dateTimePicker1.Value, null , sortsrvc_cb, rtbComment, users, tbTramNr, (Repair)serviceToUpdate);
            }
            else if (serviceToUpdate.GetType().Name == "Cleaning")
            {
                logic.UpdateCleaninginDatabase(activeUser, this, dateTimePicker1.Value, null, sortsrvc_cb, rtbComment, users, tbTramNr, (Cleaning)serviceToUpdate);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            usersListBox.Items.Add(usercbox.SelectedItem);
            users.Add(availableUsers.ElementAt(usercbox.SelectedIndex));
        }
    }
}
