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
            this.tabBeheerSysteem = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabBeheerSysteem.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabBeheerSysteem
            // 
            this.tabBeheerSysteem.Controls.Add(this.tabPage1);
            this.tabBeheerSysteem.Controls.Add(this.tabPage2);
            this.tabBeheerSysteem.Location = new System.Drawing.Point(12, 12);
            this.tabBeheerSysteem.Name = "tabBeheerSysteem";
            this.tabBeheerSysteem.SelectedIndex = 0;
            this.tabBeheerSysteem.Size = new System.Drawing.Size(646, 566);
            this.tabBeheerSysteem.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(638, 540);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Loge";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(638, 540);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "User Beheer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // UserInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 590);
            this.Controls.Add(this.tabBeheerSysteem);
            this.Name = "UserInterface";
            this.Text = "User Interface";
            this.tabBeheerSysteem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabBeheerSysteem;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}

