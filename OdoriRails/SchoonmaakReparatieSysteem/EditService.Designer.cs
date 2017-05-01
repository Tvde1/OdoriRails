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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditService));
            this.btnEditService = new System.Windows.Forms.Button();
            this.commenttb = new System.Windows.Forms.RichTextBox();
            this.commentlbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sortsrvc_cb = new System.Windows.Forms.ComboBox();
            this.usersListBox = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.usercbox = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tramnrtb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnEditService
            // 
            this.btnEditService.Location = new System.Drawing.Point(123, 498);
            this.btnEditService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditService.Name = "btnEditService";
            this.btnEditService.Size = new System.Drawing.Size(192, 49);
            this.btnEditService.TabIndex = 25;
            this.btnEditService.Text = "Edit Service";
            this.btnEditService.UseVisualStyleBackColor = true;
            this.btnEditService.Click += new System.EventHandler(this.btnEditService_Click);
            // 
            // commenttb
            // 
            this.commenttb.Location = new System.Drawing.Point(192, 329);
            this.commenttb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.commenttb.Name = "commenttb";
            this.commenttb.Size = new System.Drawing.Size(239, 159);
            this.commenttb.TabIndex = 24;
            this.commenttb.Text = "";
            // 
            // commentlbl
            // 
            this.commentlbl.AutoSize = true;
            this.commentlbl.Location = new System.Drawing.Point(13, 332);
            this.commentlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.commentlbl.Name = "commentlbl";
            this.commentlbl.Size = new System.Drawing.Size(170, 20);
            this.commentlbl.TabIndex = 23;
            this.commentlbl.Text = "ChangeBasedOnRole";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 238);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 20;
            this.label3.Text = "Datum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 183);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Soort service:";
            // 
            // sortsrvc_cb
            // 
            this.sortsrvc_cb.FormattingEnabled = true;
            this.sortsrvc_cb.Location = new System.Drawing.Point(191, 180);
            this.sortsrvc_cb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sortsrvc_cb.Name = "sortsrvc_cb";
            this.sortsrvc_cb.Size = new System.Drawing.Size(240, 28);
            this.sortsrvc_cb.TabIndex = 18;
            // 
            // usersListBox
            // 
            this.usersListBox.FormattingEnabled = true;
            this.usersListBox.ItemHeight = 20;
            this.usersListBox.Location = new System.Drawing.Point(203, 14);
            this.usersListBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usersListBox.Name = "usersListBox";
            this.usersListBox.Size = new System.Drawing.Size(227, 144);
            this.usersListBox.TabIndex = 16;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(49, 76);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(112, 35);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // usercbox
            // 
            this.usercbox.FormattingEnabled = true;
            this.usercbox.Location = new System.Drawing.Point(13, 38);
            this.usercbox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.usercbox.Name = "usercbox";
            this.usercbox.Size = new System.Drawing.Size(182, 28);
            this.usercbox.TabIndex = 14;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(132, 233);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(298, 26);
            this.dateTimePicker1.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 28;
            this.label1.Text = "Tram nr:";
            // 
            // tramnrtb
            // 
            this.tramnrtb.Location = new System.Drawing.Point(301, 281);
            this.tramnrtb.Name = "tramnrtb";
            this.tramnrtb.Size = new System.Drawing.Size(129, 26);
            this.tramnrtb.TabIndex = 27;
            // 
            // EditService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(444, 561);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tramnrtb);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnEditService);
            this.Controls.Add(this.commenttb);
            this.Controls.Add(this.commentlbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sortsrvc_cb);
            this.Controls.Add(this.usersListBox);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.usercbox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "EditService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Service";
            this.Load += new System.EventHandler(this.EditService_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnEditService;
        private System.Windows.Forms.RichTextBox commenttb;
        private System.Windows.Forms.Label commentlbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox sortsrvc_cb;
        private System.Windows.Forms.ListBox usersListBox;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox usercbox;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tramnrtb;
    }
}