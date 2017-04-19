namespace SchoonmaakReparatieSysteem
{
    partial class AddService
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
            this.usercbox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.sortsrvc_cb = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.commentlbl = new System.Windows.Forms.Label();
            this.commenttb = new System.Windows.Forms.RichTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.tramnrtb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // usercbox
            // 
            this.usercbox.FormattingEnabled = true;
            this.usercbox.Location = new System.Drawing.Point(15, 29);
            this.usercbox.Name = "usercbox";
            this.usercbox.Size = new System.Drawing.Size(118, 21);
            this.usercbox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // usersListBox
            // 
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.Location = new System.Drawing.Point(141, 12);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(135, 82);
            this.usersListBox.TabIndex = 2;
            // 
            // sortsrvc_cb
            // 
            this.sortsrvc_cb.FormattingEnabled = true;
            this.sortsrvc_cb.Location = new System.Drawing.Point(175, 111);
            this.sortsrvc_cb.Name = "sortsrvc_cb";
            this.sortsrvc_cb.Size = new System.Drawing.Size(101, 21);
            this.sortsrvc_cb.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Soort Service";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date";
            // 
            // commentlbl
            // 
            this.commentlbl.AutoSize = true;
            this.commentlbl.Location = new System.Drawing.Point(23, 256);
            this.commentlbl.Name = "commentlbl";
            this.commentlbl.Size = new System.Drawing.Size(110, 13);
            this.commentlbl.TabIndex = 11;
            this.commentlbl.Text = "ChangeBasedOnRole";
            // 
            // commenttb
            // 
            this.commenttb.Location = new System.Drawing.Point(152, 256);
            this.commenttb.Name = "commenttb";
            this.commenttb.Size = new System.Drawing.Size(135, 58);
            this.commenttb.TabIndex = 12;
            this.commenttb.Text = "";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(80, 332);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Add Service";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(76, 152);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 14;
            // 
            // tramnrtb
            // 
            this.tramnrtb.Location = new System.Drawing.Point(176, 206);
            this.tramnrtb.Name = "tramnrtb";
            this.tramnrtb.Size = new System.Drawing.Size(100, 20);
            this.tramnrtb.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "TRAM NR";
            // 
            // AddService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(297, 367);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tramnrtb);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.commenttb);
            this.Controls.Add(this.commentlbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sortsrvc_cb);
            this.Controls.Add(this.usersListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.usercbox);
            this.Name = "AddService";
            this.Text = "Add Service";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox usercbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.ComboBox sortsrvc_cb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label commentlbl;
        private System.Windows.Forms.RichTextBox commenttb;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox tramnrtb;
        private System.Windows.Forms.Label label1;
    }
}