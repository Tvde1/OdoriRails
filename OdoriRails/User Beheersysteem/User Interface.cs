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
        //IDatabaseConnector databaseConnector = new MySqlContect();
        private List<User> Users = new List<User>();

        public UserInterface()
        {
            InitializeComponent();
            //Get all users
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {

        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbSearchRole.Text == SearchRole.All.ToString())
            {
                //GetAllUsers
            }
            else
            {
                //databaseConnector.GetAllUsersWithRole();
            }

            SearchRole role;
            Enum.TryParse(cbSearchRole.Text, out role);

            switch (role)
            {
                case SearchRole.All:
                    //listUsers.DataSource = databaseConnector.GetAllUsers
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

