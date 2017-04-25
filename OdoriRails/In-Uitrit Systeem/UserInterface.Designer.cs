namespace In_Uitrit_Systeem
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
            this.cbCleaning = new System.Windows.Forms.CheckBox();
            this.cbMaintenance = new System.Windows.Forms.CheckBox();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.gbTramNumber = new System.Windows.Forms.GroupBox();
            this.lblTramNumber = new System.Windows.Forms.Label();
            this.gbLocation = new System.Windows.Forms.GroupBox();
            this.lblLocation = new System.Windows.Forms.Label();
            this.rtbDetails = new System.Windows.Forms.RichTextBox();
            this.gbDetails = new System.Windows.Forms.GroupBox();
            this.btnService = new System.Windows.Forms.Button();
            this.btnLeave = new System.Windows.Forms.Button();
            this.gbService.SuspendLayout();
            this.gbTramNumber.SuspendLayout();
            this.gbLocation.SuspendLayout();
            this.gbDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbCleaning
            // 
            this.cbCleaning.AutoSize = true;
            this.cbCleaning.Location = new System.Drawing.Point(16, 38);
            this.cbCleaning.Name = "cbCleaning";
            this.cbCleaning.Size = new System.Drawing.Size(124, 24);
            this.cbCleaning.TabIndex = 0;
            this.cbCleaning.TabStop = false;
            this.cbCleaning.Text = "Schoonmaak";
            this.cbCleaning.UseVisualStyleBackColor = true;
            this.cbCleaning.CheckedChanged += new System.EventHandler(this.cbCleaning_CheckedChanged);
            // 
            // cbMaintenance
            // 
            this.cbMaintenance.AutoSize = true;
            this.cbMaintenance.Location = new System.Drawing.Point(16, 87);
            this.cbMaintenance.Name = "cbMaintenance";
            this.cbMaintenance.Size = new System.Drawing.Size(100, 24);
            this.cbMaintenance.TabIndex = 1;
            this.cbMaintenance.TabStop = false;
            this.cbMaintenance.Text = "Reparatie";
            this.cbMaintenance.UseVisualStyleBackColor = true;
            this.cbMaintenance.CheckedChanged += new System.EventHandler(this.cbMaintenance_CheckedChanged);
            // 
            // gbService
            // 
            this.gbService.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbService.Controls.Add(this.cbMaintenance);
            this.gbService.Controls.Add(this.cbCleaning);
            this.gbService.Location = new System.Drawing.Point(14, 12);
            this.gbService.Name = "gbService";
            this.gbService.Size = new System.Drawing.Size(159, 139);
            this.gbService.TabIndex = 3;
            this.gbService.TabStop = false;
            this.gbService.Text = "Service:";
            // 
            // gbTramNumber
            // 
            this.gbTramNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbTramNumber.Controls.Add(this.lblTramNumber);
            this.gbTramNumber.Location = new System.Drawing.Point(14, 174);
            this.gbTramNumber.Name = "gbTramNumber";
            this.gbTramNumber.Size = new System.Drawing.Size(256, 181);
            this.gbTramNumber.TabIndex = 2;
            this.gbTramNumber.TabStop = false;
            this.gbTramNumber.Text = "Tramnummer:";
            // 
            // lblTramNumber
            // 
            this.lblTramNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTramNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.lblTramNumber.Location = new System.Drawing.Point(6, 22);
            this.lblTramNumber.Name = "lblTramNumber";
            this.lblTramNumber.Size = new System.Drawing.Size(244, 156);
            this.lblTramNumber.TabIndex = 0;
            this.lblTramNumber.Text = "Geen tram";
            this.lblTramNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gbLocation
            // 
            this.gbLocation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbLocation.Controls.Add(this.lblLocation);
            this.gbLocation.Location = new System.Drawing.Point(276, 174);
            this.gbLocation.Name = "gbLocation";
            this.gbLocation.Size = new System.Drawing.Size(365, 181);
            this.gbLocation.TabIndex = 4;
            this.gbLocation.TabStop = false;
            this.gbLocation.Text = "Locatie:";
            // 
            // lblLocation
            // 
            this.lblLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F);
            this.lblLocation.Location = new System.Drawing.Point(6, 22);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(353, 156);
            this.lblLocation.TabIndex = 0;
            this.lblLocation.Text = "Niet bekend";
            this.lblLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rtbDetails
            // 
            this.rtbDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbDetails.Enabled = false;
            this.rtbDetails.Location = new System.Drawing.Point(6, 25);
            this.rtbDetails.Name = "rtbDetails";
            this.rtbDetails.Size = new System.Drawing.Size(268, 96);
            this.rtbDetails.TabIndex = 0;
            this.rtbDetails.Text = "";
            // 
            // gbDetails
            // 
            this.gbDetails.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbDetails.Controls.Add(this.rtbDetails);
            this.gbDetails.Location = new System.Drawing.Point(179, 12);
            this.gbDetails.Name = "gbDetails";
            this.gbDetails.Size = new System.Drawing.Size(281, 139);
            this.gbDetails.TabIndex = 6;
            this.gbDetails.TabStop = false;
            this.gbDetails.Text = "Details:";
            // 
            // btnService
            // 
            this.btnService.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnService.BackColor = System.Drawing.SystemColors.Window;
            this.btnService.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnService.Location = new System.Drawing.Point(466, 21);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(88, 130);
            this.btnService.TabIndex = 1;
            this.btnService.Text = "Meld tram aan bij remise";
            this.btnService.UseVisualStyleBackColor = false;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // btnLeave
            // 
            this.btnLeave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLeave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLeave.Location = new System.Drawing.Point(560, 21);
            this.btnLeave.Name = "btnLeave";
            this.btnLeave.Size = new System.Drawing.Size(88, 130);
            this.btnLeave.TabIndex = 7;
            this.btnLeave.Text = "Meld tram aan voor vertrek";
            this.btnLeave.UseVisualStyleBackColor = true;
            this.btnLeave.Click += new System.EventHandler(this.btnLeave_Click);
            // 
            // FormUserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(654, 367);
            this.Controls.Add(this.btnLeave);
            this.Controls.Add(this.btnService);
            this.Controls.Add(this.gbDetails);
            this.Controls.Add(this.gbLocation);
            this.Controls.Add(this.gbTramNumber);
            this.Controls.Add(this.gbService);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormUserInterface";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odori Tram Service";
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            this.gbTramNumber.ResumeLayout(false);
            this.gbLocation.ResumeLayout(false);
            this.gbDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox cbCleaning;
        private System.Windows.Forms.CheckBox cbMaintenance;
        private System.Windows.Forms.GroupBox gbService;
        private System.Windows.Forms.GroupBox gbTramNumber;
        private System.Windows.Forms.Label lblTramNumber;
        private System.Windows.Forms.GroupBox gbLocation;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.RichTextBox rtbDetails;
        private System.Windows.Forms.GroupBox gbDetails;
        private System.Windows.Forms.Button btnService;
        private System.Windows.Forms.Button btnLeave;
    }
}

