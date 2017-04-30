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
        private Logic logic = new Logic();
        private List<User> users = new List<User>();
        private List<User> availableusers = new List<User>();
        public EditService(User activeuser, Service service)
        {
            activeUser = activeuser;
            InitializeComponent();
            



        }

        private void button2_Click(object sender, EventArgs e)
        {
            logic.UpdateServiceinDatabase(activeUser, this, dateTimePicker1.Value, DateTime.MaxValue, sortsrvc_cb, commenttb, users, tramnrtb);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usersListBox.Items.Add(usercbox.SelectedItem);
            users.Add(availableusers.ElementAt(usercbox.SelectedIndex));
        }

        private void EditService_Load(object sender, EventArgs e)
        {
           availableusers = logic.FillAnnexForms(activeUser, availableusers, sortsrvc_cb, commentlbl, usercbox);
        }
    }
}
