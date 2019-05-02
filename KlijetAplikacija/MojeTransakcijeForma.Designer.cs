namespace KlijetAplikacija
{
    partial class MojeTransakcijeForma
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
            this.dgvMojeTransakije = new System.Windows.Forms.DataGridView();
            this.lblFilteri = new System.Windows.Forms.Label();
            this.chbUplate = new System.Windows.Forms.CheckBox();
            this.chbIsplate = new System.Windows.Forms.CheckBox();
            this.chbUplateKredita = new System.Windows.Forms.CheckBox();
            this.chbIsplateKredita = new System.Windows.Forms.CheckBox();
            this.cbRacuni = new System.Windows.Forms.ComboBox();
            this.lblRacun = new System.Windows.Forms.Label();
            this.btnPrikazi = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMojeTransakije)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMojeTransakije
            // 
            this.dgvMojeTransakije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMojeTransakije.Location = new System.Drawing.Point(14, 12);
            this.dgvMojeTransakije.Name = "dgvMojeTransakije";
            this.dgvMojeTransakije.Size = new System.Drawing.Size(535, 432);
            this.dgvMojeTransakije.TabIndex = 3;
            // 
            // lblFilteri
            // 
            this.lblFilteri.AutoSize = true;
            this.lblFilteri.Location = new System.Drawing.Point(555, 12);
            this.lblFilteri.Name = "lblFilteri";
            this.lblFilteri.Size = new System.Drawing.Size(34, 13);
            this.lblFilteri.TabIndex = 4;
            this.lblFilteri.Text = "Filteri:";
            // 
            // chbUplate
            // 
            this.chbUplate.AllowDrop = true;
            this.chbUplate.AutoSize = true;
            this.chbUplate.Checked = true;
            this.chbUplate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbUplate.Location = new System.Drawing.Point(558, 34);
            this.chbUplate.Name = "chbUplate";
            this.chbUplate.Size = new System.Drawing.Size(57, 17);
            this.chbUplate.TabIndex = 5;
            this.chbUplate.Text = "Uplate";
            this.chbUplate.UseVisualStyleBackColor = true;
            // 
            // chbIsplate
            // 
            this.chbIsplate.AllowDrop = true;
            this.chbIsplate.AutoSize = true;
            this.chbIsplate.Checked = true;
            this.chbIsplate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbIsplate.Location = new System.Drawing.Point(558, 57);
            this.chbIsplate.Name = "chbIsplate";
            this.chbIsplate.Size = new System.Drawing.Size(57, 17);
            this.chbIsplate.TabIndex = 6;
            this.chbIsplate.Text = "Isplate";
            this.chbIsplate.UseVisualStyleBackColor = true;
            // 
            // chbUplateKredita
            // 
            this.chbUplateKredita.AllowDrop = true;
            this.chbUplateKredita.AutoSize = true;
            this.chbUplateKredita.Location = new System.Drawing.Point(558, 80);
            this.chbUplateKredita.Name = "chbUplateKredita";
            this.chbUplateKredita.Size = new System.Drawing.Size(92, 17);
            this.chbUplateKredita.TabIndex = 7;
            this.chbUplateKredita.Text = "Uplate kredita";
            this.chbUplateKredita.UseVisualStyleBackColor = true;
            this.chbUplateKredita.Visible = false;
            // 
            // chbIsplateKredita
            // 
            this.chbIsplateKredita.AllowDrop = true;
            this.chbIsplateKredita.AutoSize = true;
            this.chbIsplateKredita.Location = new System.Drawing.Point(558, 103);
            this.chbIsplateKredita.Name = "chbIsplateKredita";
            this.chbIsplateKredita.Size = new System.Drawing.Size(92, 17);
            this.chbIsplateKredita.TabIndex = 8;
            this.chbIsplateKredita.Text = "Isplate kredita";
            this.chbIsplateKredita.UseVisualStyleBackColor = true;
            this.chbIsplateKredita.Visible = false;
            // 
            // cbRacuni
            // 
            this.cbRacuni.FormattingEnabled = true;
            this.cbRacuni.Location = new System.Drawing.Point(558, 151);
            this.cbRacuni.Name = "cbRacuni";
            this.cbRacuni.Size = new System.Drawing.Size(121, 21);
            this.cbRacuni.TabIndex = 9;
            // 
            // lblRacun
            // 
            this.lblRacun.AutoSize = true;
            this.lblRacun.Location = new System.Drawing.Point(555, 135);
            this.lblRacun.Name = "lblRacun";
            this.lblRacun.Size = new System.Drawing.Size(44, 13);
            this.lblRacun.TabIndex = 10;
            this.lblRacun.Text = "Računi:";
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.Location = new System.Drawing.Point(558, 183);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(75, 23);
            this.btnPrikazi.TabIndex = 11;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = true;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // MojeTransakcijeForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 456);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.lblRacun);
            this.Controls.Add(this.cbRacuni);
            this.Controls.Add(this.chbIsplateKredita);
            this.Controls.Add(this.chbUplateKredita);
            this.Controls.Add(this.chbIsplate);
            this.Controls.Add(this.chbUplate);
            this.Controls.Add(this.lblFilteri);
            this.Controls.Add(this.dgvMojeTransakije);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MojeTransakcijeForma";
            this.Text = "MojeTransakcijeForma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MojeTransakcijeForma_FormClosed);
            this.Load += new System.EventHandler(this.MojeTransakcijeForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMojeTransakije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMojeTransakije;
        private System.Windows.Forms.Label lblFilteri;
        private System.Windows.Forms.CheckBox chbUplate;
        private System.Windows.Forms.CheckBox chbIsplate;
        private System.Windows.Forms.CheckBox chbUplateKredita;
        private System.Windows.Forms.CheckBox chbIsplateKredita;
        private System.Windows.Forms.ComboBox cbRacuni;
        private System.Windows.Forms.Label lblRacun;
        private System.Windows.Forms.Button btnPrikazi;
    }
}