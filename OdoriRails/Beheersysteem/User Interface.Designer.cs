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
            this.btnMove = new System.Windows.Forms.Button();
            this.tbSelectedTram = new System.Windows.Forms.TextBox();
            this.lbSelectedTram = new System.Windows.Forms.Label();
            this.btnSetDisabled = new System.Windows.Forms.Button();
            this.gbSector = new System.Windows.Forms.GroupBox();
            this.tbSelectedTrack = new System.Windows.Forms.TextBox();
            this.lbSelectedTrack = new System.Windows.Forms.Label();
            this.tbSelectedSector = new System.Windows.Forms.TextBox();
            this.lbSelectedSector = new System.Windows.Forms.Label();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnLock = new System.Windows.Forms.Button();
            this.gbDisplay = new System.Windows.Forms.GroupBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbEditSectorAmount = new System.Windows.Forms.GroupBox();
            this.btnDeleteSector = new System.Windows.Forms.Button();
            this.btnAddSector = new System.Windows.Forms.Button();
            this.tbSectorTrack = new System.Windows.Forms.TextBox();
            this.lbTrack = new System.Windows.Forms.Label();
            this.gbNewTrack = new System.Windows.Forms.GroupBox();
            this.btnDeleteTrack = new System.Windows.Forms.Button();
            this.tbDefaultLineTrack = new System.Windows.Forms.TextBox();
            this.lbDefaultLineTrack = new System.Windows.Forms.Label();
            this.cbTrackType = new System.Windows.Forms.ComboBox();
            this.tbSectorAmount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbSectorAmount = new System.Windows.Forms.Label();
            this.btnAddTrack = new System.Windows.Forms.Button();
            this.tbTrackNumber = new System.Windows.Forms.TextBox();
            this.lbTrackNumber = new System.Windows.Forms.Label();
            this.gbNewTram = new System.Windows.Forms.GroupBox();
            this.btnDeleteTram = new System.Windows.Forms.Button();
            this.cbTramModel = new System.Windows.Forms.ComboBox();
            this.tbDefaultLine = new System.Windows.Forms.TextBox();
            this.lbTramModel = new System.Windows.Forms.Label();
            this.lbDefaultLineTram = new System.Windows.Forms.Label();
            this.btnAddTram = new System.Windows.Forms.Button();
            this.tbTramNumber = new System.Windows.Forms.TextBox();
            this.lbTramNumber = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cBoxShowEmptyTracks = new System.Windows.Forms.CheckBox();
            this.btnUpdateSettings = new System.Windows.Forms.Button();
            this.lbCutoffTracks = new System.Windows.Forms.Label();
            this.tbCutoffTracks = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.gbOther.SuspendLayout();
            this.gbTram.SuspendLayout();
            this.gbSector.SuspendLayout();
            this.gbDisplay.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbEditSectorAmount.SuspendLayout();
            this.gbNewTrack.SuspendLayout();
            this.gbNewTram.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOther
            // 
            this.gbOther.Controls.Add(this.btnRefresh);
            this.gbOther.Controls.Add(this.btnReset);
            this.gbOther.Controls.Add(this.btnChangeDisplayView);
            this.gbOther.Controls.Add(this.btnSimulation);
            this.gbOther.Location = new System.Drawing.Point(5, 397);
            this.gbOther.Margin = new System.Windows.Forms.Padding(5);
            this.gbOther.Name = "gbOther";
            this.gbOther.Padding = new System.Windows.Forms.Padding(5);
            this.gbOther.Size = new System.Drawing.Size(259, 184);
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
            this.gbTram.Controls.Add(this.btnMove);
            this.gbTram.Controls.Add(this.tbSelectedTram);
            this.gbTram.Controls.Add(this.lbSelectedTram);
            this.gbTram.Controls.Add(this.btnSetDisabled);
            this.gbTram.Location = new System.Drawing.Point(5, 190);
            this.gbTram.Margin = new System.Windows.Forms.Padding(5);
            this.gbTram.Name = "gbTram";
            this.gbTram.Padding = new System.Windows.Forms.Padding(5);
            this.gbTram.Size = new System.Drawing.Size(259, 197);
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
            this.gbSector.Controls.Add(this.tbSelectedTrack);
            this.gbSector.Controls.Add(this.lbSelectedTrack);
            this.gbSector.Controls.Add(this.tbSelectedSector);
            this.gbSector.Controls.Add(this.lbSelectedSector);
            this.gbSector.Controls.Add(this.btnOpen);
            this.gbSector.Controls.Add(this.btnLock);
            this.gbSector.Location = new System.Drawing.Point(5, 8);
            this.gbSector.Margin = new System.Windows.Forms.Padding(5);
            this.gbSector.Name = "gbSector";
            this.gbSector.Padding = new System.Windows.Forms.Padding(5);
            this.gbSector.Size = new System.Drawing.Size(259, 172);
            this.gbSector.TabIndex = 0;
            this.gbSector.TabStop = false;
            this.gbSector.Text = "Sector/Track";
            // 
            // tbSelectedTrack
            // 
            this.tbSelectedTrack.Location = new System.Drawing.Point(10, 47);
            this.tbSelectedTrack.Name = "tbSelectedTrack";
            this.tbSelectedTrack.Size = new System.Drawing.Size(239, 26);
            this.tbSelectedTrack.TabIndex = 5;
            // 
            // lbSelectedTrack
            // 
            this.lbSelectedTrack.AutoSize = true;
            this.lbSelectedTrack.Location = new System.Drawing.Point(11, 24);
            this.lbSelectedTrack.Name = "lbSelectedTrack";
            this.lbSelectedTrack.Size = new System.Drawing.Size(213, 20);
            this.lbSelectedTrack.TabIndex = 4;
            this.lbSelectedTrack.Text = "Current Selected Track(s): ";
            // 
            // tbSelectedSector
            // 
            this.tbSelectedSector.Location = new System.Drawing.Point(10, 99);
            this.tbSelectedSector.Name = "tbSelectedSector";
            this.tbSelectedSector.Size = new System.Drawing.Size(239, 26);
            this.tbSelectedSector.TabIndex = 1;
            // 
            // lbSelectedSector
            // 
            this.lbSelectedSector.AutoSize = true;
            this.lbSelectedSector.Location = new System.Drawing.Point(11, 76);
            this.lbSelectedSector.Name = "lbSelectedSector";
            this.lbSelectedSector.Size = new System.Drawing.Size(220, 20);
            this.lbSelectedSector.TabIndex = 0;
            this.lbSelectedSector.Text = "Current Selected Sector(s): ";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(11, 131);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(117, 33);
            this.btnOpen.TabIndex = 2;
            this.btnOpen.Text = "Unlock";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnLock
            // 
            this.btnLock.Location = new System.Drawing.Point(134, 131);
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
            this.tabMain.TabIndex = 0;
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
            this.tabPage2.Controls.Add(this.gbEditSectorAmount);
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
            // gbEditSectorAmount
            // 
            this.gbEditSectorAmount.Controls.Add(this.btnDeleteSector);
            this.gbEditSectorAmount.Controls.Add(this.btnAddSector);
            this.gbEditSectorAmount.Controls.Add(this.tbSectorTrack);
            this.gbEditSectorAmount.Controls.Add(this.lbTrack);
            this.gbEditSectorAmount.Location = new System.Drawing.Point(8, 444);
            this.gbEditSectorAmount.Margin = new System.Windows.Forms.Padding(5);
            this.gbEditSectorAmount.Name = "gbEditSectorAmount";
            this.gbEditSectorAmount.Padding = new System.Windows.Forms.Padding(5);
            this.gbEditSectorAmount.Size = new System.Drawing.Size(259, 137);
            this.gbEditSectorAmount.TabIndex = 2;
            this.gbEditSectorAmount.TabStop = false;
            this.gbEditSectorAmount.Text = "Edit Sector Amount";
            // 
            // btnDeleteSector
            // 
            this.btnDeleteSector.Location = new System.Drawing.Point(7, 89);
            this.btnDeleteSector.Name = "btnDeleteSector";
            this.btnDeleteSector.Size = new System.Drawing.Size(242, 33);
            this.btnDeleteSector.TabIndex = 2;
            this.btnDeleteSector.Text = "Delete Sector";
            this.btnDeleteSector.UseVisualStyleBackColor = true;
            this.btnDeleteSector.Click += new System.EventHandler(this.btnDeleteSector_Click);
            // 
            // btnAddSector
            // 
            this.btnAddSector.Location = new System.Drawing.Point(7, 50);
            this.btnAddSector.Name = "btnAddSector";
            this.btnAddSector.Size = new System.Drawing.Size(242, 33);
            this.btnAddSector.TabIndex = 1;
            this.btnAddSector.Text = "Add Sector";
            this.btnAddSector.UseVisualStyleBackColor = true;
            this.btnAddSector.Click += new System.EventHandler(this.btnAddSector_Click);
            // 
            // tbSectorTrack
            // 
            this.tbSectorTrack.Location = new System.Drawing.Point(131, 18);
            this.tbSectorTrack.Name = "tbSectorTrack";
            this.tbSectorTrack.Size = new System.Drawing.Size(118, 26);
            this.tbSectorTrack.TabIndex = 0;
            // 
            // lbTrack
            // 
            this.lbTrack.AutoSize = true;
            this.lbTrack.Location = new System.Drawing.Point(8, 21);
            this.lbTrack.Name = "lbTrack";
            this.lbTrack.Size = new System.Drawing.Size(56, 20);
            this.lbTrack.TabIndex = 3;
            this.lbTrack.Text = "Track:";
            // 
            // gbNewTrack
            // 
            this.gbNewTrack.Controls.Add(this.btnDeleteTrack);
            this.gbNewTrack.Controls.Add(this.tbDefaultLineTrack);
            this.gbNewTrack.Controls.Add(this.lbDefaultLineTrack);
            this.gbNewTrack.Controls.Add(this.cbTrackType);
            this.gbNewTrack.Controls.Add(this.tbSectorAmount);
            this.gbNewTrack.Controls.Add(this.label1);
            this.gbNewTrack.Controls.Add(this.lbSectorAmount);
            this.gbNewTrack.Controls.Add(this.btnAddTrack);
            this.gbNewTrack.Controls.Add(this.tbTrackNumber);
            this.gbNewTrack.Controls.Add(this.lbTrackNumber);
            this.gbNewTrack.Location = new System.Drawing.Point(8, 211);
            this.gbNewTrack.Margin = new System.Windows.Forms.Padding(5);
            this.gbNewTrack.Name = "gbNewTrack";
            this.gbNewTrack.Padding = new System.Windows.Forms.Padding(5);
            this.gbNewTrack.Size = new System.Drawing.Size(259, 223);
            this.gbNewTrack.TabIndex = 1;
            this.gbNewTrack.TabStop = false;
            this.gbNewTrack.Text = "New Track";
            // 
            // btnDeleteTrack
            // 
            this.btnDeleteTrack.Location = new System.Drawing.Point(12, 181);
            this.btnDeleteTrack.Name = "btnDeleteTrack";
            this.btnDeleteTrack.Size = new System.Drawing.Size(242, 33);
            this.btnDeleteTrack.TabIndex = 9;
            this.btnDeleteTrack.Text = "Delete Track";
            this.btnDeleteTrack.UseVisualStyleBackColor = true;
            this.btnDeleteTrack.Click += new System.EventHandler(this.btnDeleteTrack_Click);
            // 
            // tbDefaultLineTrack
            // 
            this.tbDefaultLineTrack.Location = new System.Drawing.Point(131, 110);
            this.tbDefaultLineTrack.Name = "tbDefaultLineTrack";
            this.tbDefaultLineTrack.Size = new System.Drawing.Size(118, 26);
            this.tbDefaultLineTrack.TabIndex = 3;
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
            // cbTrackType
            // 
            this.cbTrackType.FormattingEnabled = true;
            this.cbTrackType.Location = new System.Drawing.Point(131, 77);
            this.cbTrackType.Name = "cbTrackType";
            this.cbTrackType.Size = new System.Drawing.Size(118, 28);
            this.cbTrackType.TabIndex = 2;
            // 
            // tbSectorAmount
            // 
            this.tbSectorAmount.Location = new System.Drawing.Point(131, 47);
            this.tbSectorAmount.Name = "tbSectorAmount";
            this.tbSectorAmount.Size = new System.Drawing.Size(118, 26);
            this.tbSectorAmount.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Track Type:";
            // 
            // lbSectorAmount
            // 
            this.lbSectorAmount.AutoSize = true;
            this.lbSectorAmount.Location = new System.Drawing.Point(8, 50);
            this.lbSectorAmount.Name = "lbSectorAmount";
            this.lbSectorAmount.Size = new System.Drawing.Size(125, 20);
            this.lbSectorAmount.TabIndex = 6;
            this.lbSectorAmount.Text = "Sector Amount:";
            // 
            // btnAddTrack
            // 
            this.btnAddTrack.Location = new System.Drawing.Point(13, 142);
            this.btnAddTrack.Name = "btnAddTrack";
            this.btnAddTrack.Size = new System.Drawing.Size(242, 33);
            this.btnAddTrack.TabIndex = 4;
            this.btnAddTrack.Text = "Add New Track";
            this.btnAddTrack.UseVisualStyleBackColor = true;
            this.btnAddTrack.Click += new System.EventHandler(this.btnAddTrack_Click);
            // 
            // tbTrackNumber
            // 
            this.tbTrackNumber.Location = new System.Drawing.Point(131, 18);
            this.tbTrackNumber.Name = "tbTrackNumber";
            this.tbTrackNumber.Size = new System.Drawing.Size(118, 26);
            this.tbTrackNumber.TabIndex = 0;
            // 
            // lbTrackNumber
            // 
            this.lbTrackNumber.AutoSize = true;
            this.lbTrackNumber.Location = new System.Drawing.Point(8, 21);
            this.lbTrackNumber.Name = "lbTrackNumber";
            this.lbTrackNumber.Size = new System.Drawing.Size(120, 20);
            this.lbTrackNumber.TabIndex = 5;
            this.lbTrackNumber.Text = "Track Number:";
            // 
            // gbNewTram
            // 
            this.gbNewTram.Controls.Add(this.btnDeleteTram);
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
            this.gbNewTram.Size = new System.Drawing.Size(259, 193);
            this.gbNewTram.TabIndex = 0;
            this.gbNewTram.TabStop = false;
            this.gbNewTram.Text = "New Tram";
            // 
            // btnDeleteTram
            // 
            this.btnDeleteTram.Location = new System.Drawing.Point(7, 148);
            this.btnDeleteTram.Name = "btnDeleteTram";
            this.btnDeleteTram.Size = new System.Drawing.Size(242, 33);
            this.btnDeleteTram.TabIndex = 7;
            this.btnDeleteTram.Text = "Delete Tram";
            this.btnDeleteTram.UseVisualStyleBackColor = true;
            this.btnDeleteTram.Click += new System.EventHandler(this.btnDeleteTram_Click);
            // 
            // cbTramModel
            // 
            this.cbTramModel.FormattingEnabled = true;
            this.cbTramModel.Location = new System.Drawing.Point(74, 77);
            this.cbTramModel.Name = "cbTramModel";
            this.cbTramModel.Size = new System.Drawing.Size(175, 28);
            this.cbTramModel.TabIndex = 2;
            // 
            // tbDefaultLine
            // 
            this.tbDefaultLine.Location = new System.Drawing.Point(131, 47);
            this.tbDefaultLine.Name = "tbDefaultLine";
            this.tbDefaultLine.Size = new System.Drawing.Size(118, 26);
            this.tbDefaultLine.TabIndex = 1;
            // 
            // lbTramModel
            // 
            this.lbTramModel.AutoSize = true;
            this.lbTramModel.Location = new System.Drawing.Point(9, 80);
            this.lbTramModel.Name = "lbTramModel";
            this.lbTramModel.Size = new System.Drawing.Size(59, 20);
            this.lbTramModel.TabIndex = 6;
            this.lbTramModel.Text = "Model:";
            // 
            // lbDefaultLineTram
            // 
            this.lbDefaultLineTram.AutoSize = true;
            this.lbDefaultLineTram.Location = new System.Drawing.Point(8, 50);
            this.lbDefaultLineTram.Name = "lbDefaultLineTram";
            this.lbDefaultLineTram.Size = new System.Drawing.Size(105, 20);
            this.lbDefaultLineTram.TabIndex = 5;
            this.lbDefaultLineTram.Text = "Default Line:";
            // 
            // btnAddTram
            // 
            this.btnAddTram.Location = new System.Drawing.Point(8, 109);
            this.btnAddTram.Name = "btnAddTram";
            this.btnAddTram.Size = new System.Drawing.Size(242, 33);
            this.btnAddTram.TabIndex = 3;
            this.btnAddTram.Text = "Add New Tram";
            this.btnAddTram.UseVisualStyleBackColor = true;
            this.btnAddTram.Click += new System.EventHandler(this.btnAddTram_Click);
            // 
            // tbTramNumber
            // 
            this.tbTramNumber.Location = new System.Drawing.Point(131, 18);
            this.tbTramNumber.Name = "tbTramNumber";
            this.tbTramNumber.Size = new System.Drawing.Size(118, 26);
            this.tbTramNumber.TabIndex = 0;
            // 
            // lbTramNumber
            // 
            this.lbTramNumber.AutoSize = true;
            this.lbTramNumber.Location = new System.Drawing.Point(8, 21);
            this.lbTramNumber.Name = "lbTramNumber";
            this.lbTramNumber.Size = new System.Drawing.Size(117, 20);
            this.lbTramNumber.TabIndex = 4;
            this.lbTramNumber.Text = "Tram Number:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cBoxShowEmptyTracks);
            this.tabPage3.Controls.Add(this.btnUpdateSettings);
            this.tabPage3.Controls.Add(this.lbCutoffTracks);
            this.tabPage3.Controls.Add(this.tbCutoffTracks);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(284, 718);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Settings";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cBoxShowEmptyTracks
            // 
            this.cBoxShowEmptyTracks.AutoSize = true;
            this.cBoxShowEmptyTracks.Location = new System.Drawing.Point(6, 83);
            this.cBoxShowEmptyTracks.Name = "cBoxShowEmptyTracks";
            this.cBoxShowEmptyTracks.Size = new System.Drawing.Size(239, 24);
            this.cBoxShowEmptyTracks.TabIndex = 8;
            this.cBoxShowEmptyTracks.Text = "Show tracks without sectors";
            this.cBoxShowEmptyTracks.UseVisualStyleBackColor = true;
            // 
            // btnUpdateSettings
            // 
            this.btnUpdateSettings.Location = new System.Drawing.Point(6, 113);
            this.btnUpdateSettings.Name = "btnUpdateSettings";
            this.btnUpdateSettings.Size = new System.Drawing.Size(272, 28);
            this.btnUpdateSettings.TabIndex = 6;
            this.btnUpdateSettings.Text = "Update Settings";
            this.btnUpdateSettings.UseVisualStyleBackColor = true;
            this.btnUpdateSettings.Click += new System.EventHandler(this.btnUpdateSettings_Click);
            // 
            // lbCutoffTracks
            // 
            this.lbCutoffTracks.AutoSize = true;
            this.lbCutoffTracks.Location = new System.Drawing.Point(6, 12);
            this.lbCutoffTracks.Name = "lbCutoffTracks";
            this.lbCutoffTracks.Size = new System.Drawing.Size(203, 20);
            this.lbCutoffTracks.TabIndex = 5;
            this.lbCutoffTracks.Text = "Cutoff on following tracks:";
            // 
            // tbCutoffTracks
            // 
            this.tbCutoffTracks.Location = new System.Drawing.Point(6, 35);
            this.tbCutoffTracks.Name = "tbCutoffTracks";
            this.tbCutoffTracks.Size = new System.Drawing.Size(272, 26);
            this.tbCutoffTracks.TabIndex = 0;
            this.tbCutoffTracks.Text = "38, 64";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(14, 143);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(236, 33);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
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
            this.gbEditSectorAmount.ResumeLayout(false);
            this.gbEditSectorAmount.PerformLayout();
            this.gbNewTrack.ResumeLayout(false);
            this.gbNewTrack.PerformLayout();
            this.gbNewTram.ResumeLayout(false);
            this.gbNewTram.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.TextBox tbDefaultLineTrack;
        private System.Windows.Forms.Label lbDefaultLineTrack;
        private System.Windows.Forms.ComboBox cbTrackType;
        private System.Windows.Forms.TextBox tbSectorAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbSectorAmount;
        private System.Windows.Forms.Button btnAddTrack;
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
        private System.Windows.Forms.GroupBox gbEditSectorAmount;
        private System.Windows.Forms.Button btnDeleteSector;
        private System.Windows.Forms.Button btnAddSector;
        private System.Windows.Forms.TextBox tbSectorTrack;
        private System.Windows.Forms.Label lbTrack;
        private System.Windows.Forms.Button btnDeleteTrack;
        private System.Windows.Forms.Button btnDeleteTram;
        private System.Windows.Forms.Label lbCutoffTracks;
        private System.Windows.Forms.TextBox tbCutoffTracks;
        private System.Windows.Forms.Button btnUpdateSettings;
        private System.Windows.Forms.CheckBox cBoxShowEmptyTracks;
        private System.Windows.Forms.TextBox tbSelectedTrack;
        private System.Windows.Forms.Label lbSelectedTrack;
        private System.Windows.Forms.Button btnRefresh;
    }
}

