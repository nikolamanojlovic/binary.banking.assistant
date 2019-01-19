namespace ServerAplikacija
{
    partial class ServerForma
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.btnPokreni = new System.Windows.Forms.Button();
            this.btnZaustavi = new System.Windows.Forms.Button();
            this.dgvAktivni = new System.Windows.Forms.DataGridView();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblAktivni = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivni)).BeginInit();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 27);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(37, 13);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Satus:";
            // 
            // txtStatus
            // 
            this.txtStatus.Enabled = false;
            this.txtStatus.Location = new System.Drawing.Point(56, 24);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(214, 20);
            this.txtStatus.TabIndex = 1;
            // 
            // btnPokreni
            // 
            this.btnPokreni.Location = new System.Drawing.Point(15, 60);
            this.btnPokreni.Name = "btnPokreni";
            this.btnPokreni.Size = new System.Drawing.Size(75, 23);
            this.btnPokreni.TabIndex = 2;
            this.btnPokreni.Text = "Pokreni";
            this.btnPokreni.UseVisualStyleBackColor = true;
            this.btnPokreni.Click += new System.EventHandler(this.btnPokreni_Click);
            // 
            // btnZaustavi
            // 
            this.btnZaustavi.Location = new System.Drawing.Point(195, 60);
            this.btnZaustavi.Name = "btnZaustavi";
            this.btnZaustavi.Size = new System.Drawing.Size(75, 23);
            this.btnZaustavi.TabIndex = 3;
            this.btnZaustavi.Text = "Zaustavi";
            this.btnZaustavi.UseVisualStyleBackColor = true;
            this.btnZaustavi.Click += new System.EventHandler(this.btnZaustavi_Click);
            // 
            // dgvAktivni
            // 
            this.dgvAktivni.Location = new System.Drawing.Point(0, 0);
            this.dgvAktivni.Name = "dgvAktivni";
            this.dgvAktivni.Size = new System.Drawing.Size(240, 150);
            this.dgvAktivni.TabIndex = 0;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(100, 20);
            this.txtLog.TabIndex = 0;
            // 
            // lblAktivni
            // 
            this.lblAktivni.Location = new System.Drawing.Point(0, 0);
            this.lblAktivni.Name = "lblAktivni";
            this.lblAktivni.Size = new System.Drawing.Size(100, 23);
            this.lblAktivni.TabIndex = 0;
            // 
            // ServerForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 100);
            this.Controls.Add(this.btnZaustavi);
            this.Controls.Add(this.btnPokreni);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.lblStatus);
            this.Name = "ServerForma";
            this.Text = "BBA - Server";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Button btnPokreni;
        private System.Windows.Forms.Button btnZaustavi;
        private System.Windows.Forms.DataGridView dgvAktivni;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblAktivni;
    }
}

