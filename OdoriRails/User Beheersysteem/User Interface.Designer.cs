﻿namespace User_Beheersysteem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserInterface));
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
            this.tabUsers = new System.Windows.Forms.TabControl();
            this.tabUserList = new System.Windows.Forms.TabPage();
            this.listViewUsers = new System.Windows.Forms.ListView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cbSearchRole = new System.Windows.Forms.ComboBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.tabManageUser = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lbTramId = new System.Windows.Forms.Label();
            this.tbTramId = new System.Windows.Forms.TextBox();
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
            this.lbEmail.Size = new System.Drawing.Size(114, 20);
            this.lbEmail.TabIndex = 5;
            this.lbEmail.Text = "Email Adress:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(17, 65);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(91, 20);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "Username:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(17, 25);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(58, 20);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(131, 60);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(535, 26);
            this.tbUserName.TabIndex = 1;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(131, 105);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(535, 26);
            this.tbEmail.TabIndex = 2;
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
            this.lbRole.Size = new System.Drawing.Size(48, 20);
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
            this.cbRole.TabIndex = 4;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(17, 156);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(88, 20);
            this.lbPassword.TabIndex = 8;
            this.lbPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(131, 151);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(535, 26);
            this.tbPassword.TabIndex = 3;
            // 
            // cbManaged
            // 
            this.cbManaged.FormattingEnabled = true;
            this.cbManaged.Location = new System.Drawing.Point(131, 273);
            this.cbManaged.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbManaged.Name = "cbManaged";
            this.cbManaged.Size = new System.Drawing.Size(535, 28);
            this.cbManaged.TabIndex = 5;
            // 
            // lbManaged
            // 
            this.lbManaged.AutoSize = true;
            this.lbManaged.Location = new System.Drawing.Point(17, 277);
            this.lbManaged.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbManaged.Name = "lbManaged";
            this.lbManaged.Size = new System.Drawing.Size(107, 20);
            this.lbManaged.TabIndex = 11;
            this.lbManaged.Text = "Managed By:";
            // 
            // tabUsers
            // 
            this.tabUsers.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabUsers.Controls.Add(this.tabUserList);
            this.tabUsers.Controls.Add(this.tabManageUser);
            this.tabUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.tabUsers.Location = new System.Drawing.Point(12, 12);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.SelectedIndex = 0;
            this.tabUsers.Size = new System.Drawing.Size(703, 585);
            this.tabUsers.TabIndex = 13;
            // 
            // tabUserList
            // 
            this.tabUserList.Controls.Add(this.listViewUsers);
            this.tabUserList.Controls.Add(this.btnSearch);
            this.tabUserList.Controls.Add(this.cbSearchRole);
            this.tabUserList.Controls.Add(this.btnDeleteUser);
            this.tabUserList.Controls.Add(this.btnEditUser);
            this.tabUserList.Controls.Add(this.btnAddUser);
            this.tabUserList.Location = new System.Drawing.Point(4, 29);
            this.tabUserList.Name = "tabUserList";
            this.tabUserList.Padding = new System.Windows.Forms.Padding(3);
            this.tabUserList.Size = new System.Drawing.Size(695, 552);
            this.tabUserList.TabIndex = 0;
            this.tabUserList.Text = "User List";
            this.tabUserList.UseVisualStyleBackColor = true;
            // 
            // listViewUsers
            // 
            this.listViewUsers.FullRowSelect = true;
            this.listViewUsers.Location = new System.Drawing.Point(7, 44);
            this.listViewUsers.MultiSelect = false;
            this.listViewUsers.Name = "listViewUsers";
            this.listViewUsers.Size = new System.Drawing.Size(680, 426);
            this.listViewUsers.TabIndex = 6;
            this.listViewUsers.UseCompatibleStateImageBehavior = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(464, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(223, 33);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cbSearchRole
            // 
            this.cbSearchRole.FormattingEnabled = true;
            this.cbSearchRole.Items.AddRange(new object[] {
            "Administrator",
            "Logistic",
            "Driver",
            "Cleaner",
            "HeadCleaner",
            "Engineer",
            "HeadEngineer",
            "All"});
            this.cbSearchRole.Location = new System.Drawing.Point(7, 10);
            this.cbSearchRole.Name = "cbSearchRole";
            this.cbSearchRole.Size = new System.Drawing.Size(451, 28);
            this.cbSearchRole.TabIndex = 4;
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
            this.tabManageUser.Controls.Add(this.label1);
            this.tabManageUser.Controls.Add(this.btnSubmit);
            this.tabManageUser.Controls.Add(this.lbName);
            this.tabManageUser.Controls.Add(this.lbEmail);
            this.tabManageUser.Controls.Add(this.lbTramId);
            this.tabManageUser.Controls.Add(this.lbManaged);
            this.tabManageUser.Controls.Add(this.tbEmail);
            this.tabManageUser.Controls.Add(this.lbRole);
            this.tabManageUser.Controls.Add(this.lbPassword);
            this.tabManageUser.Controls.Add(this.lbUserName);
            this.tabManageUser.Controls.Add(this.tbTramId);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "(Only counts for drivers)";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(21, 481);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(636, 54);
            this.btnSubmit.TabIndex = 6;
            this.btnSubmit.Text = "Submit User";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lbTramId
            // 
            this.lbTramId.AutoSize = true;
            this.lbTramId.Location = new System.Drawing.Point(17, 323);
            this.lbTramId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbTramId.Name = "lbTramId";
            this.lbTramId.Size = new System.Drawing.Size(71, 20);
            this.lbTramId.TabIndex = 11;
            this.lbTramId.Text = "Tram Id:";
            // 
            // tbTramId
            // 
            this.tbTramId.Location = new System.Drawing.Point(131, 320);
            this.tbTramId.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbTramId.Name = "tbTramId";
            this.tbTramId.Size = new System.Drawing.Size(120, 26);
            this.tbTramId.TabIndex = 3;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(724, 601);
            this.Controls.Add(this.tabUsers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "UserInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.TabControl tabUsers;
        private System.Windows.Forms.TabPage tabUserList;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.TabPage tabManageUser;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cbSearchRole;
        private System.Windows.Forms.ListView listViewUsers;
        private System.Windows.Forms.Label lbTramId;
        private System.Windows.Forms.TextBox tbTramId;
        private System.Windows.Forms.Label label1;
    }
}

