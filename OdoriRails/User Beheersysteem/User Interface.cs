using System;
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
        IDatabaseConnector databaseConnector = new MSSQLDatabaseContext();
        private List<User> Users = new List<User>();
        int index;

        public UserInterface()
        {
            InitializeComponent();
            listUsers.DataSource = databaseConnector.GetAllUsers();
            cbManaged.DataSource = databaseConnector.GetAllUsers();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            tabUsers.SelectTab(1);
            lbStatus.Text = UserStatus.Add.ToString();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            tabUsers.SelectTab(1);
            lbStatus.Text = UserStatus.Edit.ToString();
            index = listUsers.SelectedIndex;
            tbName.Text = Users[index].Name;
            tbUserName.Text = Users[index].Username;
            tbEmail.Text = Users[index].Email;
            cbRole.SelectedItem = Users[index].Role.ToString();
            cbManaged.SelectedItem = Users[index].ManagerUsername;
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            index = listUsers.SelectedIndex;
            databaseConnector.RemoveUser(Users[index]);
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
                // Of constructor zonder id of een manier om de nieuwe id op te vragen uit de database
                submitUser = new User(999, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, cbManaged.SelectedText);
                databaseConnector.AddUser(submitUser);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRole role;
            Enum.TryParse(cbSearchRole.Text, out role);

            switch (role)
            {
                case SearchRole.All:
                    listUsers.DataSource = databaseConnector.GetAllUsers();
                    break;
                case SearchRole.Administrator:
                    listUsers.DataSource = databaseConnector.GetAllUsersWithRole(Role.Administrator);
                    break;
                case SearchRole.Cleaner:
                    listUsers.DataSource = databaseConnector.GetAllUsersWithRole(Role.Cleaner);
                    break;
                case SearchRole.Driver:
                    listUsers.DataSource = databaseConnector.GetAllUsersWithRole(Role.Driver);
                    break;
                case SearchRole.Engineer:
                    listUsers.DataSource = databaseConnector.GetAllUsersWithRole(Role.Engineer);
                    break;
                case SearchRole.Logistic:
                    listUsers.DataSource = databaseConnector.GetAllUsersWithRole(Role.Logistic);
                    break;
            }
        }
    }
}

