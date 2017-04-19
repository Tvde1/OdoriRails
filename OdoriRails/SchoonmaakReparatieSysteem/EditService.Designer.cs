namespace SchoonmaakReparatieSysteem
{
    partial class EditService
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
            this.button2 = new System.Windows.Forms.Button();
            this.commenttb = new System.Windows.Forms.RichTextBox();
            this.commentlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sortsrvc_cb = new System.Windows.Forms.ComboBox();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 563);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(192, 35);
            this.button2.TabIndex = 25;
            this.button2.Text = "Edit Service";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // commenttb
            // 
            this.commenttb.Location = new System.Drawing.Point(249, 363);
            this.commenttb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.commenttb.Name = "commenttb";
            this.commenttb.Size = new System.Drawing.Size(200, 146);
            this.commenttb.TabIndex = 24;
            this.commenttb.Text = "";
            // 
            // commentlbl
            // 
            this.commentlbl.AutoSize = true;
            this.commentlbl.Location = new System.Drawing.Point(56, 363);
            this.commentlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commentlbl.Name = "commentlbl";
            this.commentlbl.Size = new System.Drawing.Size(170, 20);
            this.commentlbl.TabIndex = 23;
            this.commentlbl.Text = "ChangeBasedOnRole";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 280);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 218);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Soort Service";
            // 
            // sortsrvc_cb
            // 
            this.sortsrvc_cb.FormattingEnabled = true;
            this.sortsrvc_cb.Location = new System.Drawing.Point(300, 214);
            this.sortsrvc_cb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sortsrvc_cb.Name = "sortsrvc_cb";
            this.sortsrvc_cb.Size = new System.Drawing.Size(150, 28);
            this.sortsrvc_cb.TabIndex = 18;
            // 
            // usersListBox
            // 
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.ItemHeight = 20;
            this.usersListBox.Location = new System.Drawing.Point(249, 54);
            this.usersListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(200, 124);
            this.usersListBox.TabIndex = 16;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(60, 111);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 15;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(60, 54);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 28);
            this.comboBox1.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(152, 280);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(298, 26);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // EditService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 626);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.commenttb);
            this.Controls.Add(this.commentlbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sortsrvc_cb);
            this.Controls.Add(this.usersListBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "EditService";
            this.Text = "Edit Service";
            this.Load += new System.EventHandler(this.EditService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox commenttb;
        private System.Windows.Forms.Label commentlbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sortsrvc_cb;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}