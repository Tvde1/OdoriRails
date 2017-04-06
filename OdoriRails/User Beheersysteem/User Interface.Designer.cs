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
            this.tabUserBeheer = new System.Windows.Forms.TabControl();
            this.tabNewUser = new System.Windows.Forms.TabPage();
            this.lbEmail = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.lbName = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tabEditUser = new System.Windows.Forms.TabPage();
            this.lbRole = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.lbPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.cbManaged = new System.Windows.Forms.ComboBox();
            this.lbManaged = new System.Windows.Forms.Label();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.tabUserBeheer.SuspendLayout();
            this.tabNewUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabUserBeheer
            // 
            this.tabUserBeheer.Controls.Add(this.tabNewUser);
            this.tabUserBeheer.Controls.Add(this.tabEditUser);
            this.tabUserBeheer.Location = new System.Drawing.Point(0, 2);
            this.tabUserBeheer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabUserBeheer.Name = "tabUserBeheer";
            this.tabUserBeheer.SelectedIndex = 0;
            this.tabUserBeheer.Size = new System.Drawing.Size(764, 657);
            this.tabUserBeheer.TabIndex = 0;
            // 
            // tabNewUser
            // 
            this.tabNewUser.Controls.Add(this.btnAddUser);
            this.tabNewUser.Controls.Add(this.lbManaged);
            this.tabNewUser.Controls.Add(this.cbManaged);
            this.tabNewUser.Controls.Add(this.tbPassword);
            this.tabNewUser.Controls.Add(this.lbPassword);
            this.tabNewUser.Controls.Add(this.cbRole);
            this.tabNewUser.Controls.Add(this.lbRole);
            this.tabNewUser.Controls.Add(this.lbEmail);
            this.tabNewUser.Controls.Add(this.lbUserName);
            this.tabNewUser.Controls.Add(this.lbName);
            this.tabNewUser.Controls.Add(this.tbUserName);
            this.tabNewUser.Controls.Add(this.tbEmail);
            this.tabNewUser.Controls.Add(this.tbName);
            this.tabNewUser.Location = new System.Drawing.Point(4, 29);
            this.tabNewUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabNewUser.Name = "tabNewUser";
            this.tabNewUser.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabNewUser.Size = new System.Drawing.Size(756, 624);
            this.tabNewUser.TabIndex = 0;
            this.tabNewUser.Text = "New User";
            this.tabNewUser.UseVisualStyleBackColor = true;
            // 
            // lbEmail
            // 
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(12, 125);
            this.lbEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(106, 20);
            this.lbEmail.TabIndex = 5;
            this.lbEmail.Text = "Email Adress:";
            // 
            // lbUserName
            // 
            this.lbUserName.AutoSize = true;
            this.lbUserName.Location = new System.Drawing.Point(12, 80);
            this.lbUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(87, 20);
            this.lbUserName.TabIndex = 4;
            this.lbUserName.Text = "Username:";
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(12, 40);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(55, 20);
            this.lbName.TabIndex = 3;
            this.lbName.Text = "Name:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(126, 75);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(418, 26);
            this.tbUserName.TabIndex = 2;
            // 
            // tbEmail
            // 
            this.tbEmail.Location = new System.Drawing.Point(126, 120);
            this.tbEmail.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(418, 26);
            this.tbEmail.TabIndex = 1;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(126, 35);
            this.tbName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(418, 26);
            this.tbName.TabIndex = 0;
            // 
            // tabEditUser
            // 
            this.tabEditUser.Location = new System.Drawing.Point(4, 22);
            this.tabEditUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabEditUser.Name = "tabEditUser";
            this.tabEditUser.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabEditUser.Size = new System.Drawing.Size(756, 631);
            this.tabEditUser.TabIndex = 1;
            this.tabEditUser.Text = "Edit/Delete User";
            this.tabEditUser.UseVisualStyleBackColor = true;
            // 
            // lbRole
            // 
            this.lbRole.AutoSize = true;
            this.lbRole.Location = new System.Drawing.Point(12, 251);
            this.lbRole.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(46, 20);
            this.lbRole.TabIndex = 6;
            this.lbRole.Text = "Role:";
            // 
            // cbRole
            // 
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Location = new System.Drawing.Point(126, 246);
            this.cbRole.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(418, 28);
            this.cbRole.TabIndex = 7;
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(12, 171);
            this.lbPassword.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(82, 20);
            this.lbPassword.TabIndex = 8;
            this.lbPassword.Text = "Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(126, 166);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(418, 26);
            this.tbPassword.TabIndex = 9;
            // 
            // cbManaged
            // 
            this.cbManaged.FormattingEnabled = true;
            this.cbManaged.Location = new System.Drawing.Point(126, 288);
            this.cbManaged.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbManaged.Name = "cbManaged";
            this.cbManaged.Size = new System.Drawing.Size(418, 28);
            this.cbManaged.TabIndex = 10;
            // 
            // lbManaged
            // 
            this.lbManaged.AutoSize = true;
            this.lbManaged.Location = new System.Drawing.Point(12, 292);
            this.lbManaged.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbManaged.Name = "lbManaged";
            this.lbManaged.Size = new System.Drawing.Size(102, 20);
            this.lbManaged.TabIndex = 11;
            this.lbManaged.Text = "Managed By:";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(16, 329);
            this.btnAddUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(530, 85);
            this.btnAddUser.TabIndex = 12;
            this.btnAddUser.Text = "Add New User";
            this.btnAddUser.UseVisualStyleBackColor = true;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 468);
            this.Controls.Add(this.tabUserBeheer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "UserInterface";
            this.Text = "User Beheersysteem";
            this.tabUserBeheer.ResumeLayout(false);
            this.tabNewUser.ResumeLayout(false);
            this.tabNewUser.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabUserBeheer;
        private System.Windows.Forms.TabPage tabNewUser;
        private System.Windows.Forms.TabPage tabEditUser;
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
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Label lbManaged;
        private System.Windows.Forms.ComboBox cbManaged;
    }
}

