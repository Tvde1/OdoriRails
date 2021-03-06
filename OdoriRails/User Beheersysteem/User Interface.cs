﻿using System;
using System.Windows.Forms;
using OdoriRails.BaseClasses;

namespace User_Beheersysteem
{
    public partial class UserInterface : Form
    {
        readonly Logic _logic = new Logic();
        private int _index;
        private string _status;

        public UserInterface(User user)
        {
            InitializeComponent();
            InitializeListView();
            cbSearchRole.SelectedIndex = 7;
            cbRole.DataSource = Enum.GetValues(typeof(Role));
            Search();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            tabUsers.SelectTab(1);
            _status = UserStatus.Add.ToString();
            btnSubmit.Text = _status + " User";
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            try
            {
                _index = listViewUsers.SelectedIndices[0];
                var editUser = _logic.UsersSearch[_index];

                tabUsers.SelectTab(1);
                _status = UserStatus.Edit.ToString();
                btnSubmit.Text = _status + " User";
                tbName.Text = editUser.Name;
                tbUserName.Text = editUser.Username;
                tbEmail.Text = editUser.Email;
                cbRole.SelectedItem = editUser.Role.ToString();
                cbManaged.SelectedItem = editUser.ManagerUsername;
                tbTramId.Text = editUser.TramId?.ToString() ?? "";
            }
            catch
            {
                tabUsers.SelectTab(0);
                MessageBox.Show("Geen User Geselecteerd");
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (listViewUsers.SelectedIndices.Count != 0)
            {
                _logic.DeleteUser(listViewUsers.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Geen User Geselecteerd");
            }
            Search();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var role = (Role)cbRole.SelectedIndex;

            if (_status == "Edit")
            {
                var username = _logic.UsersSearch[_index].Username;
                var id = _logic.GetIndex(username);
                if (!_logic.EditUser(username, id, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, cbManaged.SelectedText == "" ? null : cbManaged.Text, tbTramId.Text)) return;
            }
            else
            {
                if (!_logic.AddUser(tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, cbManaged.Text, tbTramId.Text)) return;
            }
            tabUsers.SelectTab(0);
            Search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            _logic.GetAllUsersFromDatabase();
            _logic.GetSelectUsersFromDatabase(cbSearchRole.SelectedIndex);
            FillLists();
        }

        private void InitializeListView()
        {
            ColumnHeader cname = new ColumnHeader { Text = "Name" };
            ColumnHeader cuserName = new ColumnHeader { Text = "Username" };
            ColumnHeader crole = new ColumnHeader { Text = "Role" };
            ColumnHeader cmanager = new ColumnHeader { Text = "Manager" };
            listViewUsers.Columns.Add(cname);
            listViewUsers.Columns.Add(cuserName);
            listViewUsers.Columns.Add(crole);
            listViewUsers.Columns.Add(cmanager);
            listViewUsers.View = View.Details;
        }


        private void FillLists()
        {
            listViewUsers.Items.Clear();
            cbManaged.Items.Clear();
            foreach (var user in _logic.UsersSearch)
            {
                ListViewItem item = new ListViewItem(new[] { user.Name, user.Username, user.Role.ToString(), user.ManagerUsername });
                listViewUsers.Items.Add(item);
            }
            _logic.UsersAll.ForEach(x => cbManaged.Items.Add(x.Username));

            foreach (ColumnHeader col in listViewUsers.Columns)
            {
                col.Width = -2;
            }
        }
    }
}

