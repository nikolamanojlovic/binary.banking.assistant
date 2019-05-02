namespace KlijetAplikacija
{
    partial class OtvoriRacunForma
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
            this.cbKorisnici = new System.Windows.Forms.ComboBox();
            this.lblIzaberiKorisnika = new System.Windows.Forms.Label();
            this.dgvRacuni = new System.Windows.Forms.DataGridView();
            this.lblNoviRacuni = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblBrojRacuna = new System.Windows.Forms.Label();
            this.lblTipRacuna = new System.Windows.Forms.Label();
            this.lblDatumKreiranja = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDatumKreiranja = new System.Windows.Forms.TextBox();
            this.txtBrojRacuna = new System.Windows.Forms.TextBox();
            this.cbTipRacuna = new System.Windows.Forms.ComboBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).BeginInit();
            this.SuspendLayout();
            // 
            // cbKorisnici
            // 
            this.cbKorisnici.FormattingEnabled = true;
            this.cbKorisnici.Location = new System.Drawing.Point(16, 31);
            this.cbKorisnici.Name = "cbKorisnici";
            this.cbKorisnici.Size = new System.Drawing.Size(268, 21);
            this.cbKorisnici.TabIndex = 63;
            this.cbKorisnici.SelectedIndexChanged += new System.EventHandler(this.cbKorisnici_SelectedIndexChanged);
            // 
            // lblIzaberiKorisnika
            // 
            this.lblIzaberiKorisnika.AutoSize = true;
            this.lblIzaberiKorisnika.Location = new System.Drawing.Point(13, 13);
            this.lblIzaberiKorisnika.Name = "lblIzaberiKorisnika";
            this.lblIzaberiKorisnika.Size = new System.Drawing.Size(95, 13);
            this.lblIzaberiKorisnika.TabIndex = 64;
            this.lblIzaberiKorisnika.Text = "Izaberite korisnika:";
            // 
            // dgvRacuni
            // 
            this.dgvRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRacuni.Location = new System.Drawing.Point(326, 30);
            this.dgvRacuni.Name = "dgvRacuni";
            this.dgvRacuni.Size = new System.Drawing.Size(347, 414);
            this.dgvRacuni.TabIndex = 65;
            // 
            // lblNoviRacuni
            // 
            this.lblNoviRacuni.AutoSize = true;
            this.lblNoviRacuni.Location = new System.Drawing.Point(323, 13);
            this.lblNoviRacuni.Name = "lblNoviRacuni";
            this.lblNoviRacuni.Size = new System.Drawing.Size(64, 13);
            this.lblNoviRacuni.TabIndex = 66;
            this.lblNoviRacuni.Text = "Novi računi:";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(13, 74);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(21, 13);
            this.lblID.TabIndex = 68;
            this.lblID.Text = "ID:";
            // 
            // lblBrojRacuna
            // 
            this.lblBrojRacuna.AutoSize = true;
            this.lblBrojRacuna.Location = new System.Drawing.Point(13, 107);
            this.lblBrojRacuna.Name = "lblBrojRacuna";
            this.lblBrojRacuna.Size = new System.Drawing.Size(64, 13);
            this.lblBrojRacuna.TabIndex = 69;
            this.lblBrojRacuna.Text = "Broj računa:";
            // 
            // lblTipRacuna
            // 
            this.lblTipRacuna.AutoSize = true;
            this.lblTipRacuna.Location = new System.Drawing.Point(13, 141);
            this.lblTipRacuna.Name = "lblTipRacuna";
            this.lblTipRacuna.Size = new System.Drawing.Size(61, 13);
            this.lblTipRacuna.TabIndex = 70;
            this.lblTipRacuna.Text = "Tip računa:";
            // 
            // lblDatumKreiranja
            // 
            this.lblDatumKreiranja.AutoSize = true;
            this.lblDatumKreiranja.Location = new System.Drawing.Point(13, 174);
            this.lblDatumKreiranja.Name = "lblDatumKreiranja";
            this.lblDatumKreiranja.Size = new System.Drawing.Size(84, 13);
            this.lblDatumKreiranja.TabIndex = 71;
            this.lblDatumKreiranja.Text = "Datum kreiranja:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(133, 74);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(151, 20);
            this.txtID.TabIndex = 72;
            // 
            // txtDatumKreiranja
            // 
            this.txtDatumKreiranja.Location = new System.Drawing.Point(133, 171);
            this.txtDatumKreiranja.Name = "txtDatumKreiranja";
            this.txtDatumKreiranja.ReadOnly = true;
            this.txtDatumKreiranja.Size = new System.Drawing.Size(151, 20);
            this.txtDatumKreiranja.TabIndex = 73;
            // 
            // txtBrojRacuna
            // 
            this.txtBrojRacuna.Location = new System.Drawing.Point(133, 104);
            this.txtBrojRacuna.Name = "txtBrojRacuna";
            this.txtBrojRacuna.Size = new System.Drawing.Size(151, 20);
            this.txtBrojRacuna.TabIndex = 74;
            // 
            // cbTipRacuna
            // 
            this.cbTipRacuna.FormattingEnabled = true;
            this.cbTipRacuna.Location = new System.Drawing.Point(133, 138);
            this.cbTipRacuna.Name = "cbTipRacuna";
            this.cbTipRacuna.Size = new System.Drawing.Size(151, 21);
            this.cbTipRacuna.TabIndex = 75;
            // 
            // btnDodaj
            // 
            this.btnDodaj.Location = new System.Drawing.Point(16, 219);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(75, 23);
            this.btnDodaj.TabIndex = 77;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(97, 219);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(75, 23);
            this.btnSacuvaj.TabIndex = 78;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // OtvoriRacunForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 456);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.cbTipRacuna);
            this.Controls.Add(this.txtBrojRacuna);
            this.Controls.Add(this.txtDatumKreiranja);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.lblDatumKreiranja);
            this.Controls.Add(this.lblTipRacuna);
            this.Controls.Add(this.lblBrojRacuna);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.lblNoviRacuni);
            this.Controls.Add(this.dgvRacuni);
            this.Controls.Add(this.lblIzaberiKorisnika);
            this.Controls.Add(this.cbKorisnici);
            this.Name = "OtvoriRacunForma";
            this.Text = "OtvoriRacunForma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OtvoriRacunForma_FormClosed);
            this.Load += new System.EventHandler(this.OtvoriRacunForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbKorisnici;
        private System.Windows.Forms.Label lblIzaberiKorisnika;
        private System.Windows.Forms.DataGridView dgvRacuni;
        private System.Windows.Forms.Label lblNoviRacuni;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblBrojRacuna;
        private System.Windows.Forms.Label lblTipRacuna;
        private System.Windows.Forms.Label lblDatumKreiranja;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDatumKreiranja;
        private System.Windows.Forms.TextBox txtBrojRacuna;
        private System.Windows.Forms.ComboBox cbTipRacuna;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnSacuvaj;
    }
}