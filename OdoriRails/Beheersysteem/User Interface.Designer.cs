namespace Beheersysteem
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
            this.gbControl = new System.Windows.Forms.GroupBox();
            this.gbOther = new System.Windows.Forms.GroupBox();
            this.btnChangeDisplayView = new System.Windows.Forms.Button();
            this.btnSimulation = new System.Windows.Forms.Button();
            this.gbTram = new System.Windows.Forms.GroupBox();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.tbSelectedTram = new System.Windows.Forms.TextBox();
            this.lbSelectedTram = new System.Windows.Forms.Label();
            this.btnSetDisabled = new System.Windows.Forms.Button();
            this.gbSector = new System.Windows.Forms.GroupBox();
            this.tbSelectedSector = new System.Windows.Forms.TextBox();
            this.lbSelectedSector = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.gbDisplay = new System.Windows.Forms.GroupBox();
            this.gbControl.SuspendLayout();
            this.gbOther.SuspendLayout();
            this.gbTram.SuspendLayout();
            this.gbSector.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbControl
            // 
            this.gbControl.Controls.Add(this.gbOther);
            this.gbControl.Controls.Add(this.gbTram);
            this.gbControl.Controls.Add(this.gbSector);
            this.gbControl.Location = new System.Drawing.Point(22, 20);
            this.gbControl.Margin = new System.Windows.Forms.Padding(5);
            this.gbControl.Name = "gbControl";
            this.gbControl.Padding = new System.Windows.Forms.Padding(5);
            this.gbControl.Size = new System.Drawing.Size(281, 574);
            this.gbControl.TabIndex = 0;
            this.gbControl.TabStop = false;
            this.gbControl.Text = "Controls";
            // 
            // gbOther
            // 
            this.gbOther.Controls.Add(this.btnChangeDisplayView);
            this.gbOther.Controls.Add(this.btnSimulation);
            this.gbOther.Location = new System.Drawing.Point(12, 330);
            this.gbOther.Margin = new System.Windows.Forms.Padding(5);
            this.gbOther.Name = "gbOther";
            this.gbOther.Padding = new System.Windows.Forms.Padding(5);
            this.gbOther.Size = new System.Drawing.Size(259, 234);
            this.gbOther.TabIndex = 3;
            this.gbOther.TabStop = false;
            this.gbOther.Text = "Other";
            // 
            // btnChangeDisplayView
            // 
            this.btnChangeDisplayView.Location = new System.Drawing.Point(12, 66);
            this.btnChangeDisplayView.Name = "btnChangeDisplayView";
            this.btnChangeDisplayView.Size = new System.Drawing.Size(236, 33);
            this.btnChangeDisplayView.TabIndex = 2;
            this.btnChangeDisplayView.Text = "Display table";
            this.btnChangeDisplayView.UseVisualStyleBackColor = true;
            this.btnChangeDisplayView.Click += new System.EventHandler(this.btnChangeDisplayView_Click);
            // 
            // btnSimulation
            // 
            this.btnSimulation.Location = new System.Drawing.Point(12, 27);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(236, 33);
            this.btnSimulation.TabIndex = 1;
            this.btnSimulation.Text = "Start Simulation";
            this.btnSimulation.UseVisualStyleBackColor = true;
            this.btnSimulation.Click += new System.EventHandler(this.btnSimulation_Click);
            // 
            // gbTram
            // 
            this.gbTram.Controls.Add(this.btnAddService);
            this.gbTram.Controls.Add(this.btnMove);
            this.gbTram.Controls.Add(this.tbSelectedTram);
            this.gbTram.Controls.Add(this.lbSelectedTram);
            this.gbTram.Controls.Add(this.btnSetDisabled);
            this.gbTram.Location = new System.Drawing.Point(10, 165);
            this.gbTram.Margin = new System.Windows.Forms.Padding(5);
            this.gbTram.Name = "gbTram";
            this.gbTram.Padding = new System.Windows.Forms.Padding(5);
            this.gbTram.Size = new System.Drawing.Size(259, 155);
            this.gbTram.TabIndex = 2;
            this.gbTram.TabStop = false;
            this.gbTram.Text = "Tram";
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(136, 79);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(115, 33);
            this.btnAddService.TabIndex = 5;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(8, 79);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(122, 33);
            this.btnMove.TabIndex = 1;
            this.btnMove.Text = "Manual Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // tbSelectedTram
            // 
            this.tbSelectedTram.Location = new System.Drawing.Point(8, 47);
            this.tbSelectedTram.Name = "tbSelectedTram";
            this.tbSelectedTram.Size = new System.Drawing.Size(243, 26);
            this.tbSelectedTram.TabIndex = 4;
            // 
            // lbSelectedTram
            // 
            this.lbSelectedTram.AutoSize = true;
            this.lbSelectedTram.Location = new System.Drawing.Point(9, 24);
            this.lbSelectedTram.Name = "lbSelectedTram";
            this.lbSelectedTram.Size = new System.Drawing.Size(184, 20);
            this.lbSelectedTram.TabIndex = 4;
            this.lbSelectedTram.Text = "Current Selected Tram:";
            // 
            // btnSetDisabled
            // 
            this.btnSetDisabled.Location = new System.Drawing.Point(8, 115);
            this.btnSetDisabled.Name = "btnSetDisabled";
            this.btnSetDisabled.Size = new System.Drawing.Size(243, 33);
            this.btnSetDisabled.TabIndex = 0;
            this.btnSetDisabled.Text = "Toggle Diabled";
            this.btnSetDisabled.UseVisualStyleBackColor = true;
            this.btnSetDisabled.Click += new System.EventHandler(this.btnSetDisabled_Click);
            // 
            // gbSector
            // 
            this.gbSector.Controls.Add(this.tbSelectedSector);
            this.gbSector.Controls.Add(this.lbSelectedSector);
            this.gbSector.Controls.Add(this.btnOpen);
            this.gbSector.Controls.Add(this.btnLock);
            this.gbSector.Location = new System.Drawing.Point(10, 29);
            this.gbSector.Margin = new System.Windows.Forms.Padding(5);
            this.gbSector.Name = "gbSector";
            this.gbSector.Padding = new System.Windows.Forms.Padding(5);
            this.gbSector.Size = new System.Drawing.Size(259, 126);
            this.gbSector.TabIndex = 1;
            this.gbSector.TabStop = false;
            this.gbSector.Text = "Sector/Track";
            // 
            // tbSelectedSector
            // 
            this.tbSelectedSector.Location = new System.Drawing.Point(12, 47);
            this.tbSelectedSector.Name = "tbSelectedSector";
            this.tbSelectedSector.Size = new System.Drawing.Size(239, 26);
            this.tbSelectedSector.TabIndex = 3;
            // 
            // lbSelectedSector
            // 
            this.lbSelectedSector.AutoSize = true;
            this.lbSelectedSector.Location = new System.Drawing.Point(9, 24);
            this.lbSelectedSector.Name = "lbSelectedSector";
            this.lbSelectedSector.Size = new System.Drawing.Size(220, 20);
            this.lbSelectedSector.TabIndex = 2;
            this.lbSelectedSector.Text = "Current Selected Sector(s): ";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 79);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(117, 33);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Unlock";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(135, 79);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(115, 33);
            this.btnLock.TabIndex = 0;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // gbDisplay
            // 
            this.gbDisplay.Location = new System.Drawing.Point(313, 20);
            this.gbDisplay.Margin = new System.Windows.Forms.Padding(5);
            this.gbDisplay.Name = "gbDisplay";
            this.gbDisplay.Padding = new System.Windows.Forms.Padding(5);
            this.gbDisplay.Size = new System.Drawing.Size(773, 574);
            this.gbDisplay.TabIndex = 1;
            this.gbDisplay.TabStop = false;
            this.gbDisplay.Text = "Display";
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 605);
            this.Controls.Add(this.gbDisplay);
            this.Controls.Add(this.gbControl);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UserInterface";
            this.Text = "User Interface";
            this.gbControl.ResumeLayout(false);
            this.gbOther.ResumeLayout(false);
            this.gbTram.ResumeLayout(false);
            this.gbTram.PerformLayout();
            this.gbSector.ResumeLayout(false);
            this.gbSector.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbControl;
        private System.Windows.Forms.GroupBox gbTram;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnSetDisabled;
        private System.Windows.Forms.GroupBox gbSector;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnLock;
        private System.Windows.Forms.GroupBox gbDisplay;
        private System.Windows.Forms.GroupBox gbOther;
        private System.Windows.Forms.Button btnSimulation;
        private System.Windows.Forms.TextBox tbSelectedTram;
        private System.Windows.Forms.Label lbSelectedTram;
        private System.Windows.Forms.TextBox tbSelectedSector;
        private System.Windows.Forms.Label lbSelectedSector;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnChangeDisplayView;
    }
}

