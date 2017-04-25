﻿namespace Beheersysteem
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
            this.gbOther = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnChangeDisplayView = new System.Windows.Forms.Button();
            this.btnSimulation = new System.Windows.Forms.Button();
            this.gbTram = new System.Windows.Forms.GroupBox();
            this.tbMoveToSector = new System.Windows.Forms.TextBox();
            this.tbMoveToTrack = new System.Windows.Forms.TextBox();
            this.lbMoveToSector = new System.Windows.Forms.Label();
            this.lbMoveToTrack = new System.Windows.Forms.Label();
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.gbNewTram = new System.Windows.Forms.GroupBox();
            this.tbDefaultLine = new System.Windows.Forms.TextBox();
            this.lbTramModel = new System.Windows.Forms.Label();
            this.lbDefaultLineTram = new System.Windows.Forms.Label();
            this.btnAddTram = new System.Windows.Forms.Button();
            this.tbTramNumber = new System.Windows.Forms.TextBox();
            this.lbTramNumber = new System.Windows.Forms.Label();
            this.cbTramModel = new System.Windows.Forms.ComboBox();
            this.gbNewTrack = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSectorAmount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tbTrackNumber = new System.Windows.Forms.TextBox();
            this.lbTrackNumber = new System.Windows.Forms.Label();
            this.lbDefaultLineTrack = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.gbOther.SuspendLayout();
            this.gbTram.SuspendLayout();
            this.gbSector.SuspendLayout();
            this.gbDisplay.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbNewTram.SuspendLayout();
            this.gbNewTrack.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOther
            // 
            this.gbOther.Controls.Add(this.btnReset);
            this.gbOther.Controls.Add(this.btnChangeDisplayView);
            this.gbOther.Controls.Add(this.btnSimulation);
            this.gbOther.Location = new System.Drawing.Point(5, 397);
            this.gbOther.Margin = new System.Windows.Forms.Padding(5);
            this.gbOther.Name = "gbOther";
            this.gbOther.Padding = new System.Windows.Forms.Padding(5);
            this.gbOther.Size = new System.Drawing.Size(259, 148);
            this.gbOther.TabIndex = 2;
            this.gbOther.TabStop = false;
            this.gbOther.Text = "Other";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 105);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(236, 33);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset Remise";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnChangeDisplayView
            // 
            this.btnChangeDisplayView.Location = new System.Drawing.Point(12, 66);
            this.btnChangeDisplayView.Name = "btnChangeDisplayView";
            this.btnChangeDisplayView.Size = new System.Drawing.Size(236, 33);
            this.btnChangeDisplayView.TabIndex = 1;
            this.btnChangeDisplayView.Text = "Display table";
            this.btnChangeDisplayView.UseVisualStyleBackColor = true;
            this.btnChangeDisplayView.Click += new System.EventHandler(this.btnChangeDisplayView_Click);
            // 
            // btnSimulation
            // 
            this.btnSimulation.Location = new System.Drawing.Point(12, 27);
            this.btnSimulation.Name = "btnSimulation";
            this.btnSimulation.Size = new System.Drawing.Size(236, 33);
            this.btnSimulation.TabIndex = 0;
            this.btnSimulation.Text = "Start Simulation";
            this.btnSimulation.UseVisualStyleBackColor = true;
            this.btnSimulation.Click += new System.EventHandler(this.btnSimulation_Click);
            // 
            // gbTram
            // 
            this.gbTram.Controls.Add(this.tbMoveToSector);
            this.gbTram.Controls.Add(this.tbMoveToTrack);
            this.gbTram.Controls.Add(this.lbMoveToSector);
            this.gbTram.Controls.Add(this.lbMoveToTrack);
            this.gbTram.Controls.Add(this.btnAddService);
            this.gbTram.Controls.Add(this.btnMove);
            this.gbTram.Controls.Add(this.tbSelectedTram);
            this.gbTram.Controls.Add(this.lbSelectedTram);
            this.gbTram.Controls.Add(this.btnSetDisabled);
            this.gbTram.Location = new System.Drawing.Point(5, 144);
            this.gbTram.Margin = new System.Windows.Forms.Padding(5);
            this.gbTram.Name = "gbTram";
            this.gbTram.Padding = new System.Windows.Forms.Padding(5);
            this.gbTram.Size = new System.Drawing.Size(259, 243);
            this.gbTram.TabIndex = 1;
            this.gbTram.TabStop = false;
            this.gbTram.Text = "Tram";
            // 
            // tbMoveToSector
            // 
            this.tbMoveToSector.Location = new System.Drawing.Point(152, 77);
            this.tbMoveToSector.Name = "tbMoveToSector";
            this.tbMoveToSector.Size = new System.Drawing.Size(97, 26);
            this.tbMoveToSector.TabIndex = 3;
            // 
            // tbMoveToTrack
            // 
            this.tbMoveToTrack.Location = new System.Drawing.Point(152, 47);
            this.tbMoveToTrack.Name = "tbMoveToTrack";
            this.tbMoveToTrack.Size = new System.Drawing.Size(97, 26);
            this.tbMoveToTrack.TabIndex = 2;
            // 
            // lbMoveToSector
            // 
            this.lbMoveToSector.AutoSize = true;
            this.lbMoveToSector.Location = new System.Drawing.Point(9, 80);
            this.lbMoveToSector.Name = "lbMoveToSector";
            this.lbMoveToSector.Size = new System.Drawing.Size(127, 20);
            this.lbMoveToSector.TabIndex = 5;
            this.lbMoveToSector.Text = "Move to Sector:";
            // 
            // lbMoveToTrack
            // 
            this.lbMoveToTrack.AutoSize = true;
            this.lbMoveToTrack.Location = new System.Drawing.Point(8, 50);
            this.lbMoveToTrack.Name = "lbMoveToTrack";
            this.lbMoveToTrack.Size = new System.Drawing.Size(120, 20);
            this.lbMoveToTrack.TabIndex = 4;
            this.lbMoveToTrack.Text = "Move to Track:";
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(7, 198);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(242, 33);
            this.btnAddService.TabIndex = 7;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(7, 109);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(242, 33);
            this.btnMove.TabIndex = 6;
            this.btnMove.Text = "Manual Move";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // tbSelectedTram
            // 
            this.tbSelectedTram.Location = new System.Drawing.Point(152, 18);
            this.tbSelectedTram.Name = "tbSelectedTram";
            this.tbSelectedTram.Size = new System.Drawing.Size(97, 26);
            this.tbSelectedTram.TabIndex = 1;
            // 
            // lbSelectedTram
            // 
            this.lbSelectedTram.AutoSize = true;
            this.lbSelectedTram.Location = new System.Drawing.Point(10, 21);
            this.lbSelectedTram.Name = "lbSelectedTram";
            this.lbSelectedTram.Size = new System.Drawing.Size(53, 20);
            this.lbSelectedTram.TabIndex = 0;
            this.lbSelectedTram.Text = "Tram:";
            // 
            // btnSetDisabled
            // 
            this.btnSetDisabled.Location = new System.Drawing.Point(8, 148);
            this.btnSetDisabled.Name = "btnSetDisabled";
            this.btnSetDisabled.Size = new System.Drawing.Size(243, 33);
            this.btnSetDisabled.TabIndex = 8;
            this.btnSetDisabled.Text = "Toggle Disabled";
            this.btnSetDisabled.UseVisualStyleBackColor = true;
            this.btnSetDisabled.Click += new System.EventHandler(this.btnSetDisabled_Click);
            // 
            // gbSector
            // 
            this.gbSector.Controls.Add(this.tbSelectedSector);
            this.gbSector.Controls.Add(this.lbSelectedSector);
            this.gbSector.Controls.Add(this.btnOpen);
            this.gbSector.Controls.Add(this.btnLock);
            this.gbSector.Location = new System.Drawing.Point(5, 8);
            this.gbSector.Margin = new System.Windows.Forms.Padding(5);
            this.gbSector.Name = "gbSector";
            this.gbSector.Padding = new System.Windows.Forms.Padding(5);
            this.gbSector.Size = new System.Drawing.Size(259, 126);
            this.gbSector.TabIndex = 0;
            this.gbSector.TabStop = false;
            this.gbSector.Text = "Sector/Track";
            // 
            // tbSelectedSector
            // 
            this.tbSelectedSector.Location = new System.Drawing.Point(12, 47);
            this.tbSelectedSector.Name = "tbSelectedSector";
            this.tbSelectedSector.Size = new System.Drawing.Size(239, 26);
            this.tbSelectedSector.TabIndex = 1;
            // 
            // lbSelectedSector
            // 
            this.lbSelectedSector.AutoSize = true;
            this.lbSelectedSector.Location = new System.Drawing.Point(9, 24);
            this.lbSelectedSector.Name = "lbSelectedSector";
            this.lbSelectedSector.Size = new System.Drawing.Size(220, 20);
            this.lbSelectedSector.TabIndex = 0;
            this.lbSelectedSector.Text = "Current Selected Sector(s): ";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(12, 79);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(117, 33);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Unlock";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(135, 79);
            this.btnLock.Name = "btnLock";
            this.btnLock.Size = new System.Drawing.Size(115, 33);
            this.btnLock.TabIndex = 3;
            this.btnLock.Text = "Lock";
            this.btnLock.UseVisualStyleBackColor = true;
            this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
            // 
            // gbDisplay
            // 
            this.gbDisplay.Controls.Add(this.panelMain);
            this.gbDisplay.Location = new System.Drawing.Point(313, 20);
            this.gbDisplay.Margin = new System.Windows.Forms.Padding(5);
            this.gbDisplay.Name = "gbDisplay";
            this.gbDisplay.Padding = new System.Windows.Forms.Padding(5);
            this.gbDisplay.Size = new System.Drawing.Size(1114, 759);
            this.gbDisplay.TabIndex = 1;
            this.gbDisplay.TabStop = false;
            this.gbDisplay.Text = "Display";
            // 
            // panelMain
            // 
            this.panelMain.Location = new System.Drawing.Point(8, 27);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1098, 724);
            this.panelMain.TabIndex = 0;
            this.panelMain.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMain_Paint);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Location = new System.Drawing.Point(13, 20);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(292, 751);
            this.tabMain.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbOther);
            this.tabPage1.Controls.Add(this.gbSector);
            this.tabPage1.Controls.Add(this.gbTram);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(284, 718);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbNewTrack);
            this.tabPage2.Controls.Add(this.gbNewTram);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(284, 718);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add/Delete";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(284, 718);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // gbNewTram
            // 
            this.gbNewTram.Controls.Add(this.cbTramModel);
            this.gbNewTram.Controls.Add(this.tbDefaultLine);
            this.gbNewTram.Controls.Add(this.lbTramModel);
            this.gbNewTram.Controls.Add(this.lbDefaultLineTram);
            this.gbNewTram.Controls.Add(this.btnAddTram);
            this.gbNewTram.Controls.Add(this.tbTramNumber);
            this.gbNewTram.Controls.Add(this.lbTramNumber);
            this.gbNewTram.Location = new System.Drawing.Point(8, 8);
            this.gbNewTram.Margin = new System.Windows.Forms.Padding(5);
            this.gbNewTram.Name = "gbNewTram";
            this.gbNewTram.Padding = new System.Windows.Forms.Padding(5);
            this.gbNewTram.Size = new System.Drawing.Size(259, 154);
            this.gbNewTram.TabIndex = 2;
            this.gbNewTram.TabStop = false;
            this.gbNewTram.Text = "New Tram";
            // 
            // tbDefaultLine
            // 
            this.tbDefaultLine.Location = new System.Drawing.Point(131, 47);
            this.tbDefaultLine.Name = "tbDefaultLine";
            this.tbDefaultLine.Size = new System.Drawing.Size(118, 26);
            this.tbDefaultLine.TabIndex = 2;
            // 
            // lbTramModel
            // 
            this.lbTramModel.AutoSize = true;
            this.lbTramModel.Location = new System.Drawing.Point(9, 80);
            this.lbTramModel.Name = "lbTramModel";
            this.lbTramModel.Size = new System.Drawing.Size(59, 20);
            this.lbTramModel.TabIndex = 5;
            this.lbTramModel.Text = "Model:";
            // 
            // lbDefaultLineTram
            // 
            this.lbDefaultLineTram.AutoSize = true;
            this.lbDefaultLineTram.Location = new System.Drawing.Point(8, 50);
            this.lbDefaultLineTram.Name = "lbDefaultLineTram";
            this.lbDefaultLineTram.Size = new System.Drawing.Size(105, 20);
            this.lbDefaultLineTram.TabIndex = 4;
            this.lbDefaultLineTram.Text = "Default Line:";
            // 
            // btnAddTram
            // 
            this.btnAddTram.Location = new System.Drawing.Point(8, 109);
            this.btnAddTram.Name = "btnAddTram";
            this.btnAddTram.Size = new System.Drawing.Size(242, 33);
            this.btnAddTram.TabIndex = 7;
            this.btnAddTram.Text = "Add New Tram";
            this.btnAddTram.UseVisualStyleBackColor = true;
            // 
            // tbTramNumber
            // 
            this.tbTramNumber.Location = new System.Drawing.Point(131, 18);
            this.tbTramNumber.Name = "tbTramNumber";
            this.tbTramNumber.Size = new System.Drawing.Size(118, 26);
            this.tbTramNumber.TabIndex = 1;
            // 
            // lbTramNumber
            // 
            this.lbTramNumber.AutoSize = true;
            this.lbTramNumber.Location = new System.Drawing.Point(8, 21);
            this.lbTramNumber.Name = "lbTramNumber";
            this.lbTramNumber.Size = new System.Drawing.Size(117, 20);
            this.lbTramNumber.TabIndex = 0;
            this.lbTramNumber.Text = "Tram Number:";
            // 
            // cbTramModel
            // 
            this.cbTramModel.FormattingEnabled = true;
            this.cbTramModel.Location = new System.Drawing.Point(131, 77);
            this.cbTramModel.Name = "cbTramModel";
            this.cbTramModel.Size = new System.Drawing.Size(121, 28);
            this.cbTramModel.TabIndex = 3;
            // 
            // gbNewTrack
            // 
            this.gbNewTrack.Controls.Add(this.textBox3);
            this.gbNewTrack.Controls.Add(this.lbDefaultLineTrack);
            this.gbNewTrack.Controls.Add(this.comboBox1);
            this.gbNewTrack.Controls.Add(this.textBox1);
            this.gbNewTrack.Controls.Add(this.label1);
            this.gbNewTrack.Controls.Add(this.lbSectorAmount);
            this.gbNewTrack.Controls.Add(this.button1);
            this.gbNewTrack.Controls.Add(this.tbTrackNumber);
            this.gbNewTrack.Controls.Add(this.lbTrackNumber);
            this.gbNewTrack.Location = new System.Drawing.Point(8, 172);
            this.gbNewTrack.Margin = new System.Windows.Forms.Padding(5);
            this.gbNewTrack.Name = "gbNewTrack";
            this.gbNewTrack.Padding = new System.Windows.Forms.Padding(5);
            this.gbNewTrack.Size = new System.Drawing.Size(259, 183);
            this.gbNewTrack.TabIndex = 8;
            this.gbNewTrack.TabStop = false;
            this.gbNewTrack.Text = "New Track";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(131, 77);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(118, 28);
            this.comboBox1.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(131, 47);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 26);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Track Type:";
            // 
            // lbSectorAmount
            // 
            this.lbSectorAmount.AutoSize = true;
            this.lbSectorAmount.Location = new System.Drawing.Point(8, 50);
            this.lbSectorAmount.Name = "lbSectorAmount";
            this.lbSectorAmount.Size = new System.Drawing.Size(125, 20);
            this.lbSectorAmount.TabIndex = 4;
            this.lbSectorAmount.Text = "Sector Amount:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 142);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(242, 33);
            this.button1.TabIndex = 7;
            this.button1.Text = "Add New Tram";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tbTrackNumber
            // 
            this.tbTrackNumber.Location = new System.Drawing.Point(131, 18);
            this.tbTrackNumber.Name = "tbTrackNumber";
            this.tbTrackNumber.Size = new System.Drawing.Size(118, 26);
            this.tbTrackNumber.TabIndex = 1;
            // 
            // lbTrackNumber
            // 
            this.lbTrackNumber.AutoSize = true;
            this.lbTrackNumber.Location = new System.Drawing.Point(8, 21);
            this.lbTrackNumber.Name = "lbTrackNumber";
            this.lbTrackNumber.Size = new System.Drawing.Size(120, 20);
            this.lbTrackNumber.TabIndex = 0;
            this.lbTrackNumber.Text = "Track Number:";
            // 
            // lbDefaultLineTrack
            // 
            this.lbDefaultLineTrack.AutoSize = true;
            this.lbDefaultLineTrack.Location = new System.Drawing.Point(9, 114);
            this.lbDefaultLineTrack.Name = "lbDefaultLineTrack";
            this.lbDefaultLineTrack.Size = new System.Drawing.Size(105, 20);
            this.lbDefaultLineTrack.TabIndex = 8;
            this.lbDefaultLineTrack.Text = "Default Line:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(131, 110);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(118, 26);
            this.textBox3.TabIndex = 9;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1441, 793);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.gbDisplay);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "UserInterface";
            this.Text = "Odori Logistics";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UserInterface_Paint);
            this.gbOther.ResumeLayout(false);
            this.gbTram.ResumeLayout(false);
            this.gbTram.PerformLayout();
            this.gbSector.ResumeLayout(false);
            this.gbSector.PerformLayout();
            this.gbDisplay.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gbNewTram.ResumeLayout(false);
            this.gbNewTram.PerformLayout();
            this.gbNewTrack.ResumeLayout(false);
            this.gbNewTrack.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
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
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.TextBox tbMoveToSector;
        private System.Windows.Forms.TextBox tbMoveToTrack;
        private System.Windows.Forms.Label lbMoveToSector;
        private System.Windows.Forms.Label lbMoveToTrack;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox gbNewTrack;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbDefaultLineTrack;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSectorAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbTrackNumber;
        private System.Windows.Forms.Label lbTrackNumber;
        private System.Windows.Forms.GroupBox gbNewTram;
        private System.Windows.Forms.ComboBox cbTramModel;
        private System.Windows.Forms.TextBox tbDefaultLine;
        private System.Windows.Forms.Label lbTramModel;
        private System.Windows.Forms.Label lbDefaultLineTram;
        private System.Windows.Forms.Button btnAddTram;
        private System.Windows.Forms.TextBox tbTramNumber;
        private System.Windows.Forms.Label lbTramNumber;
    }
}

