namespace KlijetAplikacija
{
    partial class GlavnaFormaAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlavnaFormaAdmin));
            this.PictureLogo = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPozicijaAdmina = new System.Windows.Forms.TextBox();
            this.txtMejlAdmina = new System.Windows.Forms.TextBox();
            this.txtImePrezimeAdmina = new System.Windows.Forms.TextBox();
            this.gbMeni = new System.Windows.Forms.GroupBox();
            this.btnOtvoriRacun = new System.Windows.Forms.Button();
            this.btnIzmeniInformacije = new System.Windows.Forms.Button();
            this.btnNapraviTransakciju = new System.Windows.Forms.Button();
            this.btnOdobriKredit = new System.Windows.Forms.Button();
            this.bttnObrisiKorisnika = new System.Windows.Forms.Button();
            this.btnKreirajKorisnika = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbMeni.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureLogo
            // 
            this.PictureLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("PictureLogo.Image")));
            this.PictureLogo.Location = new System.Drawing.Point(12, 337);
            this.PictureLogo.Name = "PictureLogo";
            this.PictureLogo.Size = new System.Drawing.Size(155, 107);
            this.PictureLogo.TabIndex = 1;
            this.PictureLogo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPozicijaAdmina);
            this.groupBox1.Controls.Add(this.txtMejlAdmina);
            this.groupBox1.Controls.Add(this.txtImePrezimeAdmina);
            this.groupBox1.Location = new System.Drawing.Point(173, 337);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 107);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ulogovani";
            // 
            // txtPozicijaAdmina
            // 
            this.txtPozicijaAdmina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPozicijaAdmina.Enabled = false;
            this.txtPozicijaAdmina.Location = new System.Drawing.Point(20, 79);
            this.txtPozicijaAdmina.Name = "txtPozicijaAdmina";
            this.txtPozicijaAdmina.Size = new System.Drawing.Size(159, 13);
            this.txtPozicijaAdmina.TabIndex = 2;
            // 
            // txtMejlAdmina
            // 
            this.txtMejlAdmina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMejlAdmina.Enabled = false;
            this.txtMejlAdmina.Location = new System.Drawing.Point(20, 54);
            this.txtMejlAdmina.Name = "txtMejlAdmina";
            this.txtMejlAdmina.Size = new System.Drawing.Size(159, 13);
            this.txtMejlAdmina.TabIndex = 1;
            // 
            // txtImePrezimeAdmina
            // 
            this.txtImePrezimeAdmina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImePrezimeAdmina.Enabled = false;
            this.txtImePrezimeAdmina.Location = new System.Drawing.Point(20, 28);
            this.txtImePrezimeAdmina.Name = "txtImePrezimeAdmina";
            this.txtImePrezimeAdmina.Size = new System.Drawing.Size(159, 13);
            this.txtImePrezimeAdmina.TabIndex = 0;
            // 
            // gbMeni
            // 
            this.gbMeni.Controls.Add(this.btnOtvoriRacun);
            this.gbMeni.Controls.Add(this.btnIzmeniInformacije);
            this.gbMeni.Controls.Add(this.btnNapraviTransakciju);
            this.gbMeni.Controls.Add(this.btnOdobriKredit);
            this.gbMeni.Controls.Add(this.bttnObrisiKorisnika);
            this.gbMeni.Controls.Add(this.btnKreirajKorisnika);
            this.gbMeni.Location = new System.Drawing.Point(12, 12);
            this.gbMeni.Name = "gbMeni";
            this.gbMeni.Size = new System.Drawing.Size(664, 319);
            this.gbMeni.TabIndex = 3;
            this.gbMeni.TabStop = false;
            this.gbMeni.Text = "Meni";
            // 
            // btnOtvoriRacun
            // 
            this.btnOtvoriRacun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(163)))), ((int)(((byte)(73)))));
            this.btnOtvoriRacun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOtvoriRacun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOtvoriRacun.ForeColor = System.Drawing.Color.Black;
            this.btnOtvoriRacun.Location = new System.Drawing.Point(334, 20);
            this.btnOtvoriRacun.Name = "btnOtvoriRacun";
            this.btnOtvoriRacun.Size = new System.Drawing.Size(103, 91);
            this.btnOtvoriRacun.TabIndex = 6;
            this.btnOtvoriRacun.Text = "Otvori račun";
            this.btnOtvoriRacun.UseVisualStyleBackColor = false;
            this.btnOtvoriRacun.Click += new System.EventHandler(this.btnOtvoriRacun_Click);
            // 
            // btnIzmeniInformacije
            // 
            this.btnIzmeniInformacije.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(163)))), ((int)(((byte)(73)))));
            this.btnIzmeniInformacije.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIzmeniInformacije.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIzmeniInformacije.ForeColor = System.Drawing.Color.Black;
            this.btnIzmeniInformacije.Location = new System.Drawing.Point(225, 20);
            this.btnIzmeniInformacije.Name = "btnIzmeniInformacije";
            this.btnIzmeniInformacije.Size = new System.Drawing.Size(103, 91);
            this.btnIzmeniInformacije.TabIndex = 4;
            this.btnIzmeniInformacije.Text = "Izmeni informacije o korisniku";
            this.btnIzmeniInformacije.UseVisualStyleBackColor = false;
            this.btnIzmeniInformacije.Click += new System.EventHandler(this.btnIzmeniInformacije_Click);
            // 
            // btnNapraviTransakciju
            // 
            this.btnNapraviTransakciju.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(163)))), ((int)(((byte)(73)))));
            this.btnNapraviTransakciju.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNapraviTransakciju.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNapraviTransakciju.ForeColor = System.Drawing.Color.Black;
            this.btnNapraviTransakciju.Location = new System.Drawing.Point(552, 20);
            this.btnNapraviTransakciju.Name = "btnNapraviTransakciju";
            this.btnNapraviTransakciju.Size = new System.Drawing.Size(103, 91);
            this.btnNapraviTransakciju.TabIndex = 3;
            this.btnNapraviTransakciju.Text = "Napravi transakciju";
            this.btnNapraviTransakciju.UseVisualStyleBackColor = false;
            this.btnNapraviTransakciju.Click += new System.EventHandler(this.btnNapraviTransakciju_Click);
            // 
            // btnOdobriKredit
            // 
            this.btnOdobriKredit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(163)))), ((int)(((byte)(73)))));
            this.btnOdobriKredit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOdobriKredit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdobriKredit.ForeColor = System.Drawing.Color.Black;
            this.btnOdobriKredit.Location = new System.Drawing.Point(443, 20);
            this.btnOdobriKredit.Name = "btnOdobriKredit";
            this.btnOdobriKredit.Size = new System.Drawing.Size(103, 91);
            this.btnOdobriKredit.TabIndex = 2;
            this.btnOdobriKredit.Text = "Odobri kredit";
            this.btnOdobriKredit.UseVisualStyleBackColor = false;
            this.btnOdobriKredit.Click += new System.EventHandler(this.btnOdobriKredit_Click);
            // 
            // bttnObrisiKorisnika
            // 
            this.bttnObrisiKorisnika.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(163)))), ((int)(((byte)(73)))));
            this.bttnObrisiKorisnika.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bttnObrisiKorisnika.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bttnObrisiKorisnika.ForeColor = System.Drawing.Color.Black;
            this.bttnObrisiKorisnika.Location = new System.Drawing.Point(116, 20);
            this.bttnObrisiKorisnika.Name = "bttnObrisiKorisnika";
            this.bttnObrisiKorisnika.Size = new System.Drawing.Size(103, 91);
            this.bttnObrisiKorisnika.TabIndex = 1;
            this.bttnObrisiKorisnika.Text = "Obriši korisnika";
            this.bttnObrisiKorisnika.UseVisualStyleBackColor = false;
            this.bttnObrisiKorisnika.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnKreirajKorisnika
            // 
            this.btnKreirajKorisnika.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(163)))), ((int)(((byte)(73)))));
            this.btnKreirajKorisnika.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKreirajKorisnika.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKreirajKorisnika.ForeColor = System.Drawing.Color.Black;
            this.btnKreirajKorisnika.Location = new System.Drawing.Point(7, 20);
            this.btnKreirajKorisnika.Name = "btnKreirajKorisnika";
            this.btnKreirajKorisnika.Size = new System.Drawing.Size(103, 91);
            this.btnKreirajKorisnika.TabIndex = 0;
            this.btnKreirajKorisnika.Text = "Kreiraj korisnika";
            this.btnKreirajKorisnika.UseVisualStyleBackColor = false;
            this.btnKreirajKorisnika.Click += new System.EventHandler(this.btnKreirajKorisnika_Click);
            // 
            // GlavnaFormaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 456);
            this.Controls.Add(this.gbMeni);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PictureLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "GlavnaFormaAdmin";
            this.Text = "GlavnaFormaAdmin";
            this.Load += new System.EventHandler(this.GlavnaFormaAdmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbMeni.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPozicijaAdmina;
        private System.Windows.Forms.TextBox txtMejlAdmina;
        private System.Windows.Forms.TextBox txtImePrezimeAdmina;
        private System.Windows.Forms.GroupBox gbMeni;
        private System.Windows.Forms.Button btnKreirajKorisnika;
        private System.Windows.Forms.Button btnIzmeniInformacije;
        private System.Windows.Forms.Button btnNapraviTransakciju;
        private System.Windows.Forms.Button btnOdobriKredit;
        private System.Windows.Forms.Button bttnObrisiKorisnika;
        private System.Windows.Forms.Button btnOtvoriRacun;
    }
}