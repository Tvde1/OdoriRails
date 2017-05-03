namespace SchoonmaakReparatieSysteem
{
    partial class Markasdone
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
            this.solutiontb = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.klaarbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // solutiontb
            // 
            this.solutiontb.Location = new System.Drawing.Point(12, 56);
            this.solutiontb.Name = "solutiontb";
            this.solutiontb.Size = new System.Drawing.Size(295, 134);
            this.solutiontb.TabIndex = 0;
            this.solutiontb.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(270, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vul hier wat er gedaan werd om het defect te repareren:";
            // 
            // klaarbtn
            // 
            this.klaarbtn.BackColor = System.Drawing.Color.Red;
            this.klaarbtn.Location = new System.Drawing.Point(111, 211);
            this.klaarbtn.Name = "klaarbtn";
            this.klaarbtn.Size = new System.Drawing.Size(94, 38);
            this.klaarbtn.TabIndex = 2;
            this.klaarbtn.Text = "Klaar";
            this.klaarbtn.UseVisualStyleBackColor = false;
            this.klaarbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Markasdone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 261);
            this.Controls.Add(this.klaarbtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solutiontb);
            this.Name = "Markasdone";
            this.Text = "Markasdone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox solutiontb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button klaarbtn;
    }
}