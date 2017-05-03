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
        private List<User> availableUsers = new List<User>();

        public EditService(User activeUser, Service serviceToUpdate)
        {
            InitializeComponent();
            this.activeUser = activeUser;
            this.serviceToUpdate = serviceToUpdate;
            if (serviceToUpdate.GetType().Name == "Repair")
            {
                var rep = (Repair)serviceToUpdate;
                sortsrvc_cb.Text = rep.Type.ToString();
                dateTimePicker1.MinDate = rep.StartDate;
                tbTramNr.Text = rep.TramId.ToString();
                rtbComment.Text = rep.Defect;
            }
            if (serviceToUpdate.GetType().Name == "Cleaning")
            {
                var cln = (Cleaning)serviceToUpdate;
                sortsrvc_cb.Text = cln.Size.ToString();
                dateTimePicker1.MinDate = cln.StartDate;
                tbTramNr.Text = cln.TramId.ToString();
                rtbComment.Text = cln.Comments;
            }
        }

        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (serviceToUpdate.GetType().Name == "Repair")
            {
                logic.UpdateRepairinDatabase(activeUser, this, dateTimePicker1.Value, DateTime.MaxValue, sortsrvc_cb, rtbComment, users, tbTramNr, (Repair)serviceToUpdate);
            }
            if (serviceToUpdate.GetType().Name == "Cleaning")
            {
                logic.UpdateCleaninginDatabase(activeUser, this, dateTimePicker1.Value, DateTime.MaxValue, sortsrvc_cb, rtbComment, users, tbTramNr, (Cleaning)serviceToUpdate);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            usersListBox.Items.Add(usercbox.SelectedItem);
            users.Add(availableUsers.ElementAt(usercbox.SelectedIndex));
        }

        private void EditService_Load(object sender, EventArgs e)
        {
            sortsrvc_cb.SelectedIndex = 0;
            availableUsers = logic.FillAnnexForms(activeUser, availableUsers, sortsrvc_cb, commentlbl, usercbox);
        }
    }
}
