namespace User_Beheersysteem
{
    partial class UserInterface
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbRole = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbManaged = new System.Windows.Forms.ComboBox();
            this.lbManaged = new System.Windows.Forms.Label();
            this.listUsers = new System.Windows.Forms.ListBox();
            this.tabUsers = new System.Windows.Forms.TabControl();
            this.tabUserList = new System.Windows.Forms.TabPage();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.tabManageUser = new System.Windows.Forms.TabPage();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbStatus = new System.Windows.Forms.Label();
            this.tabUsers.SuspendLayout();
            this.tabUserList.SuspendLayout();
            this.tabManageUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(17, 110);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(106, 20);
            this.lbEmail.TabIndex = 5;
            this.lbEmail.Text = "Email Adress:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(17, 65);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(87, 20);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "Username:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(17, 25);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(55, 20);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(131, 60);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(535, 26);
            this.tbUserName.TabIndex = 2;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(131, 105);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(535, 26);
            this.tbEmail.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(131, 20);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(535, 26);
            this.tbName.TabIndex = 0;
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Location = new System.Drawing.Point(17, 236);
            this.lbRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(46, 20);
            this.lbRole.TabIndex = 6;
            this.lbRole.Text = "Role:";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(131, 231);
            this.cbRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(535, 28);
            this.cbRole.TabIndex = 7;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(17, 156);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(82, 20);
            this.lbPassword.TabIndex = 8;
            this.lbPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(131, 151);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(535, 26);
            this.tbPassword.TabIndex = 9;
            // 
            // cbManaged
            // 
            this.cbManaged.FormattingEnabled = true;
            this.cbManaged.Location = new System.Drawing.Point(131, 273);
            this.cbManaged.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbManaged.Name = "cbManaged";
            this.cbManaged.Size = new System.Drawing.Size(535, 28);
            this.cbManaged.TabIndex = 10;
            // 
            // lbManaged
            // 
            this.lbManaged.AutoSize = true;
            this.lbManaged.Location = new System.Drawing.Point(17, 277);
            this.lbManaged.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbManaged.Name = "lbManaged";
            this.lbManaged.Size = new System.Drawing.Size(102, 20);
            this.lbManaged.TabIndex = 11;
            this.lbManaged.Text = "Managed By:";
            // 
            // listUsers
            // 
            this.listUsers.FormattingEnabled = true;
            this.listUsers.ItemHeight = 20;
            this.listUsers.Location = new System.Drawing.Point(6, 6);
            this.listUsers.Name = "listUsers";
            this.listUsers.Size = new System.Drawing.Size(681, 464);
            this.listUsers.TabIndex = 0;
            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.tabUserList);
            this.tabUsers.Controls.Add(this.tabManageUser);
            this.tabUsers.Location = new System.Drawing.Point(12, 12);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.SelectedIndex = 0;
            this.tabUsers.Size = new System.Drawing.Size(703, 585);
            this.tabUsers.TabIndex = 13;
            // 
            // tabUserList
            // 
            this.tabUserList.Controls.Add(this.btnDeleteUser);
            this.tabUserList.Controls.Add(this.btnEditUser);
            this.tabUserList.Controls.Add(this.btnAddUser);
            this.tabUserList.Controls.Add(this.listUsers);
            this.tabUserList.Location = new System.Drawing.Point(4, 29);
            this.tabUserList.Name = "tabUserList";
            this.tabUserList.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserList.Size = new System.Drawing.Size(695, 552);
            this.tabUserList.TabIndex = 0;
            this.tabUserList.Text = "User List";
            this.tabUserList.UseVisualStyleBackColor = true;
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.Location = new System.Drawing.Point(464, 476);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(223, 69);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Delete selected user";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.Location = new System.Drawing.Point(235, 476);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(223, 69);
            this.btnEditUser.TabIndex = 2;
            this.btnEditUser.Text = "Edit selected user";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(6, 476);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(223, 69);
            this.btnAddUser.TabIndex = 1;
            this.btnAddUser.Text = "Add new user";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // tabManageUser
            // 
            this.tabManageUser.Controls.Add(this.lbStatus);
            this.tabManageUser.Controls.Add(this.btnSubmit);
            this.tabManageUser.Controls.Add(this.lbName);
            this.tabManageUser.Controls.Add(this.lbEmail);
            this.tabManageUser.Controls.Add(this.lbManaged);
            this.tabManageUser.Controls.Add(this.tbEmail);
            this.tabManageUser.Controls.Add(this.lbRole);
            this.tabManageUser.Controls.Add(this.lbPassword);
            this.tabManageUser.Controls.Add(this.lbUserName);
            this.tabManageUser.Controls.Add(this.tbPassword);
            this.tabManageUser.Controls.Add(this.cbManaged);
            this.tabManageUser.Controls.Add(this.tbUserName);
            this.tabManageUser.Controls.Add(this.cbRole);
            this.tabManageUser.Controls.Add(this.tbName);
            this.tabManageUser.Location = new System.Drawing.Point(4, 29);
            this.tabManageUser.Name = "tabManageUser";
            this.tabManageUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabManageUser.Size = new System.Drawing.Size(695, 552);
            this.tabManageUser.TabIndex = 1;
            this.tabManageUser.Text = "Manage User";
            this.tabManageUser.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(360, 318);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(297, 54);
            this.btnSubmit.TabIndex = 12;
            this.btnSubmit.Text = "Submit User";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(21, 335);
            this.lbStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(275, 20);
            this.lbStatus.TabIndex = 13;
            this.lbStatus.Text = "Currently: [Insert Status] + IdNummer ";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 601);
            this.Controls.Add(this.tabUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserInterface";
            this.Text = "User Beheersysteem";
            this.tabUsers.ResumeLayout(false);
            this.tabUserList.ResumeLayout(false);
            this.tabManageUser.ResumeLayout(false);
            this.tabManageUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label lbRole;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label lbManaged;
        private System.Windows.Forms.ComboBox cbManaged;
        private System.Windows.Forms.ListBox listUsers;
        private System.Windows.Forms.TabControl tabUsers;
        private System.Windows.Forms.TabPage tabUserList;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TabPage tabManageUser;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lbStatus;
    }
}

