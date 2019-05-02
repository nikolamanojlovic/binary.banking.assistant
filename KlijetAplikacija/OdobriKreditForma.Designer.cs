namespace KlijetAplikacija
{
    partial class OdobriKreditForma
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
            this.lblIzaberiKorisnika = new System.Windows.Forms.Label();
            this.cbKorisnici = new System.Windows.Forms.ComboBox();
            this.lblTipKredita = new System.Windows.Forms.Label();
            this.cbTipKredita = new System.Windows.Forms.ComboBox();
            this.lblBrojKredita = new System.Windows.Forms.Label();
            this.txtBrojKredita = new System.Windows.Forms.TextBox();
            this.lblDatumUzimanja = new System.Windows.Forms.Label();
            this.dtpDatumUzimanja = new System.Windows.Forms.DateTimePicker();
            this.dtpRokDospeca = new System.Windows.Forms.DateTimePicker();
            this.lblRokDospeca = new System.Windows.Forms.Label();
            this.txtKamata = new System.Windows.Forms.TextBox();
            this.lblKamata = new System.Windows.Forms.Label();
            this.txtBrojRata = new System.Windows.Forms.TextBox();
            this.lblBrojRata = new System.Windows.Forms.Label();
            this.lblIznos = new System.Windows.Forms.Label();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.btnPostaviVrednosti = new System.Windows.Forms.Button();
            this.btnOdobri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblIzaberiKorisnika
            // 
            this.lblIzaberiKorisnika.AutoSize = true;
            this.lblIzaberiKorisnika.Location = new System.Drawing.Point(20, 19);
            this.lblIzaberiKorisnika.Name = "lblIzaberiKorisnika";
            this.lblIzaberiKorisnika.Size = new System.Drawing.Size(95, 13);
            this.lblIzaberiKorisnika.TabIndex = 66;
            this.lblIzaberiKorisnika.Text = "Izaberite korisnika:";
            // 
            // cbKorisnici
            // 
            this.cbKorisnici.FormattingEnabled = true;
            this.cbKorisnici.Location = new System.Drawing.Point(23, 37);
            this.cbKorisnici.Name = "cbKorisnici";
            this.cbKorisnici.Size = new System.Drawing.Size(268, 21);
            this.cbKorisnici.TabIndex = 65;
            this.cbKorisnici.SelectedIndexChanged += new System.EventHandler(this.cbKorisnici_SelectedIndexChanged);
            // 
            // lblTipKredita
            // 
            this.lblTipKredita.AutoSize = true;
            this.lblTipKredita.Location = new System.Drawing.Point(20, 66);
            this.lblTipKredita.Name = "lblTipKredita";
            this.lblTipKredita.Size = new System.Drawing.Size(99, 13);
            this.lblTipKredita.TabIndex = 68;
            this.lblTipKredita.Text = "Izaberite tip kredita:";
            // 
            // cbTipKredita
            // 
            this.cbTipKredita.FormattingEnabled = true;
            this.cbTipKredita.Location = new System.Drawing.Point(23, 84);
            this.cbTipKredita.Name = "cbTipKredita";
            this.cbTipKredita.Size = new System.Drawing.Size(268, 21);
            this.cbTipKredita.TabIndex = 67;
            // 
            // lblBrojKredita
            // 
            this.lblBrojKredita.AutoSize = true;
            this.lblBrojKredita.Location = new System.Drawing.Point(326, 19);
            this.lblBrojKredita.Name = "lblBrojKredita";
            this.lblBrojKredita.Size = new System.Drawing.Size(63, 13);
            this.lblBrojKredita.TabIndex = 69;
            this.lblBrojKredita.Text = "Broj kredita:";
            // 
            // txtBrojKredita
            // 
            this.txtBrojKredita.Location = new System.Drawing.Point(329, 38);
            this.txtBrojKredita.Name = "txtBrojKredita";
            this.txtBrojKredita.ReadOnly = true;
            this.txtBrojKredita.Size = new System.Drawing.Size(121, 20);
            this.txtBrojKredita.TabIndex = 70;
            // 
            // lblDatumUzimanja
            // 
            this.lblDatumUzimanja.AutoSize = true;
            this.lblDatumUzimanja.Location = new System.Drawing.Point(20, 145);
            this.lblDatumUzimanja.Name = "lblDatumUzimanja";
            this.lblDatumUzimanja.Size = new System.Drawing.Size(85, 13);
            this.lblDatumUzimanja.TabIndex = 71;
            this.lblDatumUzimanja.Text = "Datum uzimanja:";
            // 
            // dtpDatumUzimanja
            // 
            this.dtpDatumUzimanja.Enabled = false;
            this.dtpDatumUzimanja.Location = new System.Drawing.Point(23, 165);
            this.dtpDatumUzimanja.Name = "dtpDatumUzimanja";
            this.dtpDatumUzimanja.Size = new System.Drawing.Size(200, 20);
            this.dtpDatumUzimanja.TabIndex = 72;
            // 
            // dtpRokDospeca
            // 
            this.dtpRokDospeca.Location = new System.Drawing.Point(250, 165);
            this.dtpRokDospeca.Name = "dtpRokDospeca";
            this.dtpRokDospeca.Size = new System.Drawing.Size(200, 20);
            this.dtpRokDospeca.TabIndex = 74;
            // 
            // lblRokDospeca
            // 
            this.lblRokDospeca.AutoSize = true;
            this.lblRokDospeca.Location = new System.Drawing.Point(247, 145);
            this.lblRokDospeca.Name = "lblRokDospeca";
            this.lblRokDospeca.Size = new System.Drawing.Size(74, 13);
            this.lblRokDospeca.TabIndex = 73;
            this.lblRokDospeca.Text = "Rok dospeća:";
            // 
            // txtKamata
            // 
            this.txtKamata.Location = new System.Drawing.Point(23, 214);
            this.txtKamata.Name = "txtKamata";
            this.txtKamata.Size = new System.Drawing.Size(200, 20);
            this.txtKamata.TabIndex = 76;
            // 
            // lblKamata
            // 
            this.lblKamata.AutoSize = true;
            this.lblKamata.Location = new System.Drawing.Point(20, 195);
            this.lblKamata.Name = "lblKamata";
            this.lblKamata.Size = new System.Drawing.Size(46, 13);
            this.lblKamata.TabIndex = 75;
            this.lblKamata.Text = "Kamata:";
            // 
            // txtBrojRata
            // 
            this.txtBrojRata.Location = new System.Drawing.Point(250, 214);
            this.txtBrojRata.Name = "txtBrojRata";
            this.txtBrojRata.ReadOnly = true;
            this.txtBrojRata.Size = new System.Drawing.Size(200, 20);
            this.txtBrojRata.TabIndex = 78;
            // 
            // lblBrojRata
            // 
            this.lblBrojRata.AutoSize = true;
            this.lblBrojRata.Location = new System.Drawing.Point(247, 195);
            this.lblBrojRata.Name = "lblBrojRata";
            this.lblBrojRata.Size = new System.Drawing.Size(49, 13);
            this.lblBrojRata.TabIndex = 77;
            this.lblBrojRata.Text = "Broj rata:";
            // 
            // lblIznos
            // 
            this.lblIznos.AutoSize = true;
            this.lblIznos.Location = new System.Drawing.Point(20, 247);
            this.lblIznos.Name = "lblIznos";
            this.lblIznos.Size = new System.Drawing.Size(35, 13);
            this.lblIznos.TabIndex = 79;
            this.lblIznos.Text = "Iznos:";
            // 
            // txtIznos
            // 
            this.txtIznos.Location = new System.Drawing.Point(23, 266);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(200, 20);
            this.txtIznos.TabIndex = 80;
            // 
            // btnPostaviVrednosti
            // 
            this.btnPostaviVrednosti.Location = new System.Drawing.Point(632, 415);
            this.btnPostaviVrednosti.Name = "btnPostaviVrednosti";
            this.btnPostaviVrednosti.Size = new System.Drawing.Size(75, 23);
            this.btnPostaviVrednosti.TabIndex = 81;
            this.btnPostaviVrednosti.Text = "Izračunaj";
            this.btnPostaviVrednosti.UseVisualStyleBackColor = true;
            this.btnPostaviVrednosti.Click += new System.EventHandler(this.btnPostaviVrednosti_Click);
            // 
            // btnOdobri
            // 
            this.btnOdobri.Enabled = false;
            this.btnOdobri.Location = new System.Drawing.Point(713, 415);
            this.btnOdobri.Name = "btnOdobri";
            this.btnOdobri.Size = new System.Drawing.Size(75, 23);
            this.btnOdobri.TabIndex = 82;
            this.btnOdobri.Text = "Odobri kredit";
            this.btnOdobri.UseVisualStyleBackColor = true;
            this.btnOdobri.Click += new System.EventHandler(this.btnOdobri_Click);
            // 
            // OdobriKreditForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnOdobri);
            this.Controls.Add(this.btnPostaviVrednosti);
            this.Controls.Add(this.txtIznos);
            this.Controls.Add(this.lblIznos);
            this.Controls.Add(this.txtBrojRata);
            this.Controls.Add(this.lblBrojRata);
            this.Controls.Add(this.txtKamata);
            this.Controls.Add(this.lblKamata);
            this.Controls.Add(this.dtpRokDospeca);
            this.Controls.Add(this.lblRokDospeca);
            this.Controls.Add(this.dtpDatumUzimanja);
            this.Controls.Add(this.lblDatumUzimanja);
            this.Controls.Add(this.txtBrojKredita);
            this.Controls.Add(this.lblBrojKredita);
            this.Controls.Add(this.lblTipKredita);
            this.Controls.Add(this.cbTipKredita);
            this.Controls.Add(this.lblIzaberiKorisnika);
            this.Controls.Add(this.cbKorisnici);
            this.Name = "OdobriKreditForma";
            this.Text = "OdobriKreditForma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OdobriKreditForma_FormClosed);
            this.Load += new System.EventHandler(this.OdobriKreditForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIzaberiKorisnika;
        private System.Windows.Forms.ComboBox cbKorisnici;
        private System.Windows.Forms.Label lblTipKredita;
        private System.Windows.Forms.ComboBox cbTipKredita;
        private System.Windows.Forms.Label lblBrojKredita;
        private System.Windows.Forms.TextBox txtBrojKredita;
        private System.Windows.Forms.Label lblDatumUzimanja;
        private System.Windows.Forms.DateTimePicker dtpDatumUzimanja;
        private System.Windows.Forms.DateTimePicker dtpRokDospeca;
        private System.Windows.Forms.Label lblRokDospeca;
        private System.Windows.Forms.TextBox txtKamata;
        private System.Windows.Forms.Label lblKamata;
        private System.Windows.Forms.TextBox txtBrojRata;
        private System.Windows.Forms.Label lblBrojRata;
        private System.Windows.Forms.Label lblIznos;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Button btnPostaviVrednosti;
        private System.Windows.Forms.Button btnOdobri;
    }
}