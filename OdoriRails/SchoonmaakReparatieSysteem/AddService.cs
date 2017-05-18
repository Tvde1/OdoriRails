using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OdoriRails.BaseClasses;
using System.Linq;

namespace SchoonmaakReparatieSysteem
{
    public partial class AddService : Form
    {
        private User activeUser;
        private Logic logic = new Logic();
        private List<User> users = new List<User>();
        private List<User> availableUsers; 

        public AddService(User activeUser)
        {
            InitializeComponent();
            this.activeUser = activeUser;
            availableUsers = FillAnnexForms();
            sortsrvc_cb.SelectedIndex = 0;
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            int tramNr = (int)nudTramNr.Value;
            if (logic.AddServicetoDatabase(activeUser, dateTimePicker1.Value, null, sortsrvc_cb, commenttb.Text, users, tramNr))
            {
                Close();
            }
            else
            {
                MessageBox.Show("Onjuist tram nummer.");
            }
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            usersListBox.Items.Add(cbUsers.SelectedItem);
            users.Add(availableUsers.ElementAt(cbUsers.SelectedIndex));
        }

        public List<User> FillAnnexForms()
        {
            if (activeUser.Role == Role.HeadEngineer)
            {
                availableUsers = logic.GetAllUsersWithFunction(Role.Engineer);
                availableUsers.AddRange(logic.GetAllUsersWithFunction(Role.HeadEngineer));
                foreach (User user in availableUsers)
                {
                    cbUsers.Items.Add(user.Name);
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
                    cbUsers.Items.Add(user.Name);
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
    }
}
