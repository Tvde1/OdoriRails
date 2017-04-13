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
        Logic logic = new Logic();
        int index;
        string status;

        public UserInterface()
        {
            InitializeComponent();
            cbSearchRole.SelectedIndex = 5;
            Search();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            tabUsers.SelectTab(1);
            status = UserStatus.Add.ToString();
            btnSubmit.Text = status + " User";
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem != null)
            {
                tabUsers.SelectTab(1);
                status = UserStatus.Edit.ToString();
                btnSubmit.Text = status + " User";
                index = listUsers.SelectedIndex;
                tbName.Text = logic.UsersSearch[index].Name;
                tbUserName.Text = logic.UsersSearch[index].Username;
                tbEmail.Text = logic.UsersSearch[index].Email;
                cbRole.SelectedItem = logic.UsersSearch[index].Role.ToString();
                cbManaged.SelectedItem = logic.UsersSearch[index].ManagerUsername;
            }
            else
            {
                MessageBox.Show("Geen User Geselecteerd");
            }
            Search();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            logic.DeleteUser(listUsers.SelectedIndex);
            Search();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            tabUsers.SelectTab(0);
            User submitUser;
            Role role;
            Enum.TryParse(cbRole.SelectedText, out role);

            if (status == "Edit")
            {
                if (cbManaged.SelectedText != "")
                {
                    submitUser = new User(index, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, cbManaged.SelectedText);
                }
                else
                {
                    submitUser = new User(index, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, null);
                }
                logic.UpdateUser(submitUser);
                
            }
            else
            {
                if (cbManaged.SelectedText != "")
                {
                    submitUser = new User(999, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, cbManaged.SelectedText);
                }
                else
                {
                    submitUser = new User(999, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, null);
                }
                logic.AddUser(submitUser);
            }
            Search();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            SearchRole role;
            Enum.TryParse(cbSearchRole.Text, out role);
            logic.GetAllUsersFromDatabase();
            logic.GetSelectUsersFromDatabase(role);
            FillLists();
        }

        private void FillLists()
        {
            listUsers.Items.Clear();
            cbManaged.Items.Clear();
            foreach (BeheerUser User in logic.UsersSearch)
            {
                listUsers.Items.Add(User.ToString(false));
            }
            foreach (BeheerUser User in logic.UsersAll)
            {
                cbManaged.Items.Add(User.ToString(true));
            }
        }
    }
}

