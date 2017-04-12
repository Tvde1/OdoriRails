﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OdoriRails;

namespace User_Beheersysteem
{
    public partial class UserInterface : Form
    {
        IDatabaseConnector databaseConnector = new MySqlContext();
        private List<BeheerUser> UsersAll = new List<BeheerUser>();
        private List<BeheerUser> UsersSearch = new List<BeheerUser>();
        int index;

        public UserInterface()
        {
            InitializeComponent();
            GetUsersFromDatabase(SearchRole.All);
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            tabUsers.SelectTab(1);
            lbStatus.Text = UserStatus.Add.ToString();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem != null)
            {
                tabUsers.SelectTab(1);
                lbStatus.Text = UserStatus.Edit.ToString();
                index = listUsers.SelectedIndex;
                tbName.Text = UsersSearch[index].Name;
                tbUserName.Text = UsersSearch[index].Username;
                tbEmail.Text = UsersSearch[index].Email;
                cbRole.SelectedItem = UsersSearch[index].Role.ToString();
                cbManaged.SelectedItem = UsersSearch[index].ManagerUsername;
            }
            else
            {
                MessageBox.Show("Geen User Geselecteerd");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            index = listUsers.SelectedIndex;
            databaseConnector.RemoveUser(UsersSearch[index]);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            User submitUser;
            Role role;
            Enum.TryParse(cbRole.SelectedText, out role);

            if (lbStatus.Text == "Edit")
            {
                submitUser = new User(index, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, cbManaged.SelectedText);
                //Edit user ergens????????
            }
            else
            {
                submitUser = new User(999, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, cbManaged.SelectedText);
                databaseConnector.AddUser(submitUser);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRole role;
            Enum.TryParse(cbSearchRole.Text, out role);
            GetUsersFromDatabase(role);
        }

        private void GetUsersFromDatabase(SearchRole role)
        {
            UsersSearch.Clear();
            UsersAll.Clear();
            listUsers.Items.Clear();
            cbManaged.Items.Clear();

            List<User> TempUsersAll = databaseConnector.GetAllUsers(); ;
            List<User> TempUsersSearch = null;

            switch (role)
            {
                case SearchRole.All:
                    TempUsersSearch = databaseConnector.GetAllUsers();
                    break;
                case SearchRole.Administrator:
                    TempUsersSearch = databaseConnector.GetAllUsersWithRole(Role.Administrator);
                    break;
                case SearchRole.Cleaner:
                    TempUsersSearch = databaseConnector.GetAllUsersWithRole(Role.Cleaner);
                    break;
                case SearchRole.Driver:
                    TempUsersSearch = databaseConnector.GetAllUsersWithRole(Role.Driver);
                    break;
                case SearchRole.Engineer:
                    TempUsersSearch = databaseConnector.GetAllUsersWithRole(Role.Engineer);
                    break;
                case SearchRole.Logistic:
                    TempUsersSearch = databaseConnector.GetAllUsersWithRole(Role.Logistic);
                    break;
            }

            foreach (User TempUser in TempUsersSearch)
            {
                UsersSearch.Add(new BeheerUser(TempUser.Id, TempUser.Name, TempUser.Username, TempUser.Email, TempUser.Password, TempUser.Role, TempUser.ManagerUsername));
            }
            foreach (User TempUser in TempUsersAll)
            {
                UsersAll.Add(new BeheerUser(TempUser.Id, TempUser.Name, TempUser.Username, TempUser.Email, TempUser.Password, TempUser.Role, TempUser.ManagerUsername));
            }

            foreach (BeheerUser User in UsersSearch)
            {
                listUsers.Items.Add(User.ToString());
            }
            foreach (BeheerUser User in UsersAll)
            {
                cbManaged.Items.Add(User.ToString());
            }
        }

        private void tabUsers_TabIndexChanged(object sender, EventArgs e)
        {
            GetUsersFromDatabase(SearchRole.All);
        }
    }
}
