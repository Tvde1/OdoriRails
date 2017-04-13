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
            InitializeListView();
            cbSearchRole.SelectedIndex = 7;
            cbRole.DataSource = Enum.GetValues(typeof(Role));
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
            if (listViewUsers.SelectedItems != null)
            {
                tabUsers.SelectTab(1);
                status = UserStatus.Edit.ToString();
                btnSubmit.Text = status + " User";
                index = listViewUsers.SelectedIndices[0];
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
            logic.DeleteUser(listViewUsers.SelectedIndices[0]);
            Search();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            tabUsers.SelectTab(0);
            int test = cbRole.SelectedIndex;
            User submitUser;
            Role role = (Role)test;

            if (status == "Edit")
            {
                string username = logic.UsersSearch[index].Name;
                int id = logic.GetIndex(username);
                if (cbManaged.SelectedText != "")
                {
                    submitUser = new User(id, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, cbManaged.SelectedText);
                }
                else
                {
                    submitUser = new User(id, tbName.Text, tbUserName.Text, tbEmail.Text, tbPassword.Text, role, null);
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
            logic.GetAllUsersFromDatabase();
            logic.GetSelectUsersFromDatabase(cbSearchRole.SelectedIndex);
            FillLists();
        }

        private void InitializeListView()
        {
            ColumnHeader Cname = new ColumnHeader();
            Cname.Text = "Name";
            ColumnHeader CuserName = new ColumnHeader();
            CuserName.Text = "Username";
            ColumnHeader Crole = new ColumnHeader();
            Crole.Text = "Role";
            listViewUsers.Columns.Add(Cname);
            listViewUsers.Columns.Add(CuserName);
            listViewUsers.Columns.Add(Crole);
            listViewUsers.View = View.Details;
        }


        private void FillLists()
        {
            listViewUsers.Items.Clear();
            cbManaged.Items.Clear();
            foreach (BeheerUser User in logic.UsersSearch)
            {
                ListViewItem item = new ListViewItem(new string[3] { User.Name, User.Username, User.Role.ToString() });
                listViewUsers.Items.Add(item);
            }
            foreach (BeheerUser User in logic.UsersAll)
            {
                cbManaged.Items.Add(User.Username);
            }
            foreach (ColumnHeader col in listViewUsers.Columns)
            {
                col.Width = -2;
            }
        }
    }
}

