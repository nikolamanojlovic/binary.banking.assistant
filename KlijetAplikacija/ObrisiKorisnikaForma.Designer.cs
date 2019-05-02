namespace KlijetAplikacija
{
    partial class ObrisiKorisnikaForma
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
            this.btnObrisi = new System.Windows.Forms.Button();
            this.lblGrad = new System.Windows.Forms.Label();
            this.txtGrad = new System.Windows.Forms.TextBox();
            this.lblBrKuce = new System.Windows.Forms.Label();
            this.txtBrojKuce = new System.Windows.Forms.TextBox();
            this.lblUlica = new System.Windows.Forms.Label();
            this.txtUlica = new System.Windows.Forms.TextBox();
            this.lblSifra = new System.Windows.Forms.Label();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.txtTelefon = new System.Windows.Forms.TextBox();
            this.lblMejl = new System.Windows.Forms.Label();
            this.txtMejl = new System.Windows.Forms.TextBox();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.txtIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtJmbg = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.cbKorisnici = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnObrisi
            // 
            this.btnObrisi.Location = new System.Drawing.Point(101, 358);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(75, 23);
            this.btnObrisi.TabIndex = 40;
            this.btnObrisi.Text = "Obriši korisnika";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // lblGrad
            // 
            this.lblGrad.AutoSize = true;
            this.lblGrad.Location = new System.Drawing.Point(98, 309);
            this.lblGrad.Name = "lblGrad";
            this.lblGrad.Size = new System.Drawing.Size(33, 13);
            this.lblGrad.TabIndex = 39;
            this.lblGrad.Text = "Grad:";
            // 
            // txtGrad
            // 
            this.txtGrad.Location = new System.Drawing.Point(142, 306);
            this.txtGrad.Name = "txtGrad";
            this.txtGrad.ReadOnly = true;
            this.txtGrad.Size = new System.Drawing.Size(192, 20);
            this.txtGrad.TabIndex = 38;
            // 
            // lblBrKuce
            // 
            this.lblBrKuce.AutoSize = true;
            this.lblBrKuce.Location = new System.Drawing.Point(343, 283);
            this.lblBrKuce.Name = "lblBrKuce";
            this.lblBrKuce.Size = new System.Drawing.Size(55, 13);
            this.lblBrKuce.TabIndex = 37;
            this.lblBrKuce.Text = "Broj kuće:";
            // 
            // txtBrojKuce
            // 
            this.txtBrojKuce.Location = new System.Drawing.Point(401, 280);
            this.txtBrojKuce.Name = "txtBrojKuce";
            this.txtBrojKuce.ReadOnly = true;
            this.txtBrojKuce.Size = new System.Drawing.Size(192, 20);
            this.txtBrojKuce.TabIndex = 36;
            // 
            // lblUlica
            // 
            this.lblUlica.AutoSize = true;
            this.lblUlica.Location = new System.Drawing.Point(98, 283);
            this.lblUlica.Name = "lblUlica";
            this.lblUlica.Size = new System.Drawing.Size(34, 13);
            this.lblUlica.TabIndex = 35;
            this.lblUlica.Text = "Ulica:";
            // 
            // txtUlica
            // 
            this.txtUlica.Location = new System.Drawing.Point(142, 280);
            this.txtUlica.Name = "txtUlica";
            this.txtUlica.ReadOnly = true;
            this.txtUlica.Size = new System.Drawing.Size(192, 20);
            this.txtUlica.TabIndex = 34;
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Location = new System.Drawing.Point(98, 226);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(31, 13);
            this.lblSifra.TabIndex = 33;
            this.lblSifra.Text = "Šifra:";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(142, 223);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.ReadOnly = true;
            this.txtSifra.Size = new System.Drawing.Size(192, 20);
            this.txtSifra.TabIndex = 32;
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(343, 200);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(46, 13);
            this.lblTelefon.TabIndex = 31;
            this.lblTelefon.Text = "Telefon:";
            // 
            // txtTelefon
            // 
            this.txtTelefon.Location = new System.Drawing.Point(401, 197);
            this.txtTelefon.Name = "txtTelefon";
            this.txtTelefon.ReadOnly = true;
            this.txtTelefon.Size = new System.Drawing.Size(192, 20);
            this.txtTelefon.TabIndex = 30;
            // 
            // lblMejl
            // 
            this.lblMejl.AutoSize = true;
            this.lblMejl.Location = new System.Drawing.Point(98, 200);
            this.lblMejl.Name = "lblMejl";
            this.lblMejl.Size = new System.Drawing.Size(29, 13);
            this.lblMejl.TabIndex = 29;
            this.lblMejl.Text = "Mejl:";
            // 
            // txtMejl
            // 
            this.txtMejl.Location = new System.Drawing.Point(142, 197);
            this.txtMejl.Name = "txtMejl";
            this.txtMejl.ReadOnly = true;
            this.txtMejl.Size = new System.Drawing.Size(192, 20);
            this.txtMejl.TabIndex = 28;
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(343, 133);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(47, 13);
            this.lblPrezime.TabIndex = 27;
            this.lblPrezime.Text = "Prezime:";
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(401, 130);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.ReadOnly = true;
            this.txtPrezime.Size = new System.Drawing.Size(192, 20);
            this.txtPrezime.TabIndex = 26;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(95, 133);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(27, 13);
            this.lblIme.TabIndex = 25;
            this.lblIme.Text = "Ime:";
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(142, 130);
            this.txtIme.Name = "txtIme";
            this.txtIme.ReadOnly = true;
            this.txtIme.Size = new System.Drawing.Size(192, 20);
            this.txtIme.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(95, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "JMBG";
            // 
            // txtJmbg
            // 
            this.txtJmbg.Location = new System.Drawing.Point(142, 104);
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.ReadOnly = true;
            this.txtJmbg.Size = new System.Drawing.Size(192, 20);
            this.txtJmbg.TabIndex = 22;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(142, 75);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(100, 20);
            this.txtID.TabIndex = 21;
            // 
            // cbKorisnici
            // 
            this.cbKorisnici.FormattingEnabled = true;
            this.cbKorisnici.Location = new System.Drawing.Point(101, 36);
            this.cbKorisnici.Name = "cbKorisnici";
            this.cbKorisnici.Size = new System.Drawing.Size(492, 21);
            this.cbKorisnici.TabIndex = 41;
            this.cbKorisnici.SelectedIndexChanged += new System.EventHandler(this.cbKorisnici_SelectedIndexChanged);
            // 
            // ObrisiKorisnikaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 456);
            this.Controls.Add(this.cbKorisnici);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.lblGrad);
            this.Controls.Add(this.txtGrad);
            this.Controls.Add(this.lblBrKuce);
            this.Controls.Add(this.txtBrojKuce);
            this.Controls.Add(this.lblUlica);
            this.Controls.Add(this.txtUlica);
            this.Controls.Add(this.lblSifra);
            this.Controls.Add(this.txtSifra);
            this.Controls.Add(this.lblTelefon);
            this.Controls.Add(this.txtTelefon);
            this.Controls.Add(this.lblMejl);
            this.Controls.Add(this.txtMejl);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtIme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtJmbg);
            this.Controls.Add(this.txtID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ObrisiKorisnikaForma";
            this.Text = "ObrisiKorisnikaForma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ObrisiKorisnikaForma_FormClosed);
            this.Load += new System.EventHandler(this.ObrisiKorisnikaForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Label lblGrad;
        private System.Windows.Forms.TextBox txtGrad;
        private System.Windows.Forms.Label lblBrKuce;
        private System.Windows.Forms.TextBox txtBrojKuce;
        private System.Windows.Forms.Label lblUlica;
        private System.Windows.Forms.TextBox txtUlica;
        private System.Windows.Forms.Label lblSifra;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.TextBox txtTelefon;
        private System.Windows.Forms.Label lblMejl;
        private System.Windows.Forms.TextBox txtMejl;
        private System.Windows.Forms.Label lblPrezime;
        private System.Windows.Forms.TextBox txtPrezime;
        private System.Windows.Forms.Label lblIme;
        private System.Windows.Forms.TextBox txtIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtJmbg;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ComboBox cbKorisnici;
    }
}