namespace KlijetAplikacija
{
    partial class MojiRacuniForma
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
            this.lblPretrazi = new System.Windows.Forms.Label();
            this.txtPretraga = new System.Windows.Forms.TextBox();
            this.dgvMojiRacuni = new System.Windows.Forms.DataGridView();
            this.lblInformacija = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMojiRacuni)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPretrazi
            // 
            this.lblPretrazi.AutoSize = true;
            this.lblPretrazi.Location = new System.Drawing.Point(12, 19);
            this.lblPretrazi.Name = "lblPretrazi";
            this.lblPretrazi.Size = new System.Drawing.Size(45, 13);
            this.lblPretrazi.TabIndex = 0;
            this.lblPretrazi.Text = "Pretraži:";
            // 
            // txtPretraga
            // 
            this.txtPretraga.Location = new System.Drawing.Point(63, 16);
            this.txtPretraga.Name = "txtPretraga";
            this.txtPretraga.Size = new System.Drawing.Size(278, 20);
            this.txtPretraga.TabIndex = 1;
            this.txtPretraga.TextChanged += new System.EventHandler(this.txtPretraga_TextChanged);
            // 
            // dgvMojiRacuni
            // 
            this.dgvMojiRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMojiRacuni.Location = new System.Drawing.Point(15, 53);
            this.dgvMojiRacuni.Name = "dgvMojiRacuni";
            this.dgvMojiRacuni.Size = new System.Drawing.Size(661, 391);
            this.dgvMojiRacuni.TabIndex = 2;
            // 
            // lblInformacija
            // 
            this.lblInformacija.AutoSize = true;
            this.lblInformacija.Location = new System.Drawing.Point(347, 19);
            this.lblInformacija.Name = "lblInformacija";
            this.lblInformacija.Size = new System.Drawing.Size(93, 13);
            this.lblInformacija.TabIndex = 3;
            this.lblInformacija.Text = "( po broju računa )";
            // 
            // MojiRacuniForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 456);
            this.Controls.Add(this.lblInformacija);
            this.Controls.Add(this.dgvMojiRacuni);
            this.Controls.Add(this.txtPretraga);
            this.Controls.Add(this.lblPretrazi);
            this.Name = "MojiRacuniForma";
            this.Text = "MojiRacuniForma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MojiRacuniForma_FormClosed);
            this.Load += new System.EventHandler(this.MojiRacuniForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMojiRacuni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPretrazi;
        private System.Windows.Forms.TextBox txtPretraga;
        private System.Windows.Forms.DataGridView dgvMojiRacuni;
        private System.Windows.Forms.Label lblInformacija;
    }
}