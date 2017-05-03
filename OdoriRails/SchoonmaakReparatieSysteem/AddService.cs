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
        private List<User> availableusers; 

        public AddService(User activeuser)
        {
            activeUser = activeuser;
            InitializeComponent();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            logic.AddServicetoDatabase(activeUser, this, dateTimePicker1.Value, DateTime.MaxValue, sortsrvc_cb, commenttb, users, tramnrtb);
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            usersListBox.Items.Add(usercbox.SelectedItem);
            users.Add(availableusers.ElementAt(usercbox.SelectedIndex));
        }

        private void AddService_Load(object sender, EventArgs e)
        {
            
            availableusers = logic.FillAnnexForms(activeUser, availableusers, sortsrvc_cb, commentlbl, usercbox);
            sortsrvc_cb.SelectedIndex = 0;
        }
    }
}
