namespace SchoonmaakReparatieSysteem
{
    partial class MainService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainService));
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnEditService = new System.Windows.Forms.Button();
            this.btnDeleteService = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.cboxFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.usernamelbl = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnPlanServices = new System.Windows.Forms.Button();
            this.btnMakeTestData = new System.Windows.Forms.Button();
            this.btnTramLogs = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAddService
            // 
            this.btnAddService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddService.Location = new System.Drawing.Point(524, 719);
            this.btnAddService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(112, 35);
            this.btnAddService.TabIndex = 2;
            this.btnAddService.Text = "Add Service";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnEditService
            // 
            this.btnEditService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditService.Location = new System.Drawing.Point(646, 719);
            this.btnEditService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEditService.Name = "btnEditService";
            this.btnEditService.Size = new System.Drawing.Size(112, 35);
            this.btnEditService.TabIndex = 3;
            this.btnEditService.Text = "Edit Service";
            this.btnEditService.UseVisualStyleBackColor = true;
            this.btnEditService.Click += new System.EventHandler(this.btnEditService_Click);
            // 
            // btnDeleteService
            // 
            this.btnDeleteService.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteService.Location = new System.Drawing.Point(388, 719);
            this.btnDeleteService.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDeleteService.Name = "btnDeleteService";
            this.btnDeleteService.Size = new System.Drawing.Size(128, 35);
            this.btnDeleteService.TabIndex = 5;
            this.btnDeleteService.Text = "Delete Service";
            this.btnDeleteService.UseVisualStyleBackColor = true;
            this.btnDeleteService.Click += new System.EventHandler(this.btnDeleteService_Click);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDone.Location = new System.Drawing.Point(22, 719);
            this.btnDone.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(146, 35);
            this.btnDone.TabIndex = 6;
            this.btnDone.Text = "Mark as done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // cboxFilter
            // 
            this.cboxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboxFilter.DisplayMember = "0";
            this.cboxFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFilter.FormattingEnabled = true;
            this.cboxFilter.Items.AddRange(new object[] {
            "My Services",
            "Unassigned Services"});
            this.cboxFilter.Location = new System.Drawing.Point(578, 42);
            this.cboxFilter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboxFilter.Name = "cboxFilter";
            this.cboxFilter.Size = new System.Drawing.Size(180, 28);
            this.cboxFilter.TabIndex = 7;
            this.cboxFilter.ValueMember = "0";
            this.cboxFilter.SelectedIndexChanged += new System.EventHandler(this.cboxFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Filter op:";
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(18, 91);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(740, 607);
            this.dataGridView.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Active User:";
            // 
            // usernamelbl
            // 
            this.usernamelbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernamelbl.AutoSize = true;
            this.usernamelbl.Location = new System.Drawing.Point(124, 45);
            this.usernamelbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.usernamelbl.Name = "usernamelbl";
            this.usernamelbl.Size = new System.Drawing.Size(86, 20);
            this.usernamelbl.TabIndex = 11;
            this.usernamelbl.Text = "Username";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Location = new System.Drawing.Point(176, 719);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 35);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnPlanServices
            // 
            this.btnPlanServices.Location = new System.Drawing.Point(321, 51);
            this.btnPlanServices.Name = "btnPlanServices";
            this.btnPlanServices.Size = new System.Drawing.Size(136, 32);
            this.btnPlanServices.TabIndex = 13;
            this.btnPlanServices.Text = "Plan Services";
            this.btnPlanServices.UseVisualStyleBackColor = true;
            this.btnPlanServices.Click += new System.EventHandler(this.btnPlanServices_Click);
            // 
            // btnMakeTestData
            // 
            this.btnMakeTestData.Location = new System.Drawing.Point(321, 12);
            this.btnMakeTestData.Name = "btnMakeTestData";
            this.btnMakeTestData.Size = new System.Drawing.Size(136, 37);
            this.btnMakeTestData.TabIndex = 14;
            this.btnMakeTestData.Text = "Make TestData";
            this.btnMakeTestData.UseVisualStyleBackColor = true;
            this.btnMakeTestData.Click += new System.EventHandler(this.btnMakeTestData_Click);
            // 
            // btnTramLogs
            // 
            this.btnTramLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTramLogs.Location = new System.Drawing.Point(263, 719);
            this.btnTramLogs.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnTramLogs.Name = "btnTramLogs";
            this.btnTramLogs.Size = new System.Drawing.Size(117, 35);
            this.btnTramLogs.TabIndex = 15;
            this.btnTramLogs.Text = "Tram Logs";
            this.btnTramLogs.UseVisualStyleBackColor = true;
            this.btnTramLogs.Click += new System.EventHandler(this.btnTramLogs_Click);
            // 
            // MainService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(774, 768);
            this.Controls.Add(this.btnTramLogs);
            this.Controls.Add(this.btnMakeTestData);
            this.Controls.Add(this.btnPlanServices);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.usernamelbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxFilter);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnDeleteService);
            this.Controls.Add(this.btnEditService);
            this.Controls.Add(this.btnAddService);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(790, 807);
            this.Name = "MainService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odorirails Service Management";
            this.Load += new System.EventHandler(this.MainService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnEditService;
        private System.Windows.Forms.Button btnDeleteService;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.ComboBox cboxFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label usernamelbl;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnPlanServices;
        private System.Windows.Forms.Button btnMakeTestData;
        private System.Windows.Forms.Button btnTramLogs;
    }
}

