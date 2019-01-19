namespace KlijetAplikacija
{
    partial class Prijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prijava));
            this.PictureLogo = new System.Windows.Forms.PictureBox();
            this.gbDobrodosli = new System.Windows.Forms.GroupBox();
            this.txtSifra = new System.Windows.Forms.TextBox();
            this.txtMejl = new System.Windows.Forms.TextBox();
            this.lblSifra = new System.Windows.Forms.Label();
            this.lblMejl = new System.Windows.Forms.Label();
            this.btnPrijaviSe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).BeginInit();
            this.gbDobrodosli.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureLogo
            // 
            this.PictureLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("PictureLogo.Image")));
            this.PictureLogo.Location = new System.Drawing.Point(12, 32);
            this.PictureLogo.Name = "PictureLogo";
            this.PictureLogo.Size = new System.Drawing.Size(155, 120);
            this.PictureLogo.TabIndex = 0;
            this.PictureLogo.TabStop = false;
            // 
            // gbDobrodosli
            // 
            this.gbDobrodosli.Controls.Add(this.btnPrijaviSe);
            this.gbDobrodosli.Controls.Add(this.txtSifra);
            this.gbDobrodosli.Controls.Add(this.txtMejl);
            this.gbDobrodosli.Controls.Add(this.lblSifra);
            this.gbDobrodosli.Controls.Add(this.lblMejl);
            this.gbDobrodosli.Location = new System.Drawing.Point(184, 32);
            this.gbDobrodosli.Name = "gbDobrodosli";
            this.gbDobrodosli.Size = new System.Drawing.Size(302, 120);
            this.gbDobrodosli.TabIndex = 1;
            this.gbDobrodosli.TabStop = false;
            this.gbDobrodosli.Text = "Dobrodošli";
            // 
            // txtSifra
            // 
            this.txtSifra.Location = new System.Drawing.Point(50, 56);
            this.txtSifra.Name = "txtSifra";
            this.txtSifra.Size = new System.Drawing.Size(240, 20);
            this.txtSifra.TabIndex = 3;
            // 
            // txtMejl
            // 
            this.txtMejl.Location = new System.Drawing.Point(50, 25);
            this.txtMejl.Name = "txtMejl";
            this.txtMejl.Size = new System.Drawing.Size(240, 20);
            this.txtMejl.TabIndex = 2;
            // 
            // lblSifra
            // 
            this.lblSifra.AutoSize = true;
            this.lblSifra.Location = new System.Drawing.Point(6, 59);
            this.lblSifra.Name = "lblSifra";
            this.lblSifra.Size = new System.Drawing.Size(31, 13);
            this.lblSifra.TabIndex = 1;
            this.lblSifra.Text = "Šifra:";
            // 
            // lblMejl
            // 
            this.lblMejl.AutoSize = true;
            this.lblMejl.Location = new System.Drawing.Point(6, 28);
            this.lblMejl.Name = "lblMejl";
            this.lblMejl.Size = new System.Drawing.Size(38, 13);
            this.lblMejl.TabIndex = 0;
            this.lblMejl.Text = "E-mail:";
            // 
            // btnPrijaviSe
            // 
            this.btnPrijaviSe.Location = new System.Drawing.Point(215, 82);
            this.btnPrijaviSe.Name = "btnPrijaviSe";
            this.btnPrijaviSe.Size = new System.Drawing.Size(75, 23);
            this.btnPrijaviSe.TabIndex = 4;
            this.btnPrijaviSe.Text = "Prijavi se";
            this.btnPrijaviSe.UseVisualStyleBackColor = true;
            this.btnPrijaviSe.Click += new System.EventHandler(this.btnPrijaviSe_Click);
            // 
            // Prijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 164);
            this.Controls.Add(this.gbDobrodosli);
            this.Controls.Add(this.PictureLogo);
            this.Name = "Prijava";
            this.Text = "BBA - Prijava";
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).EndInit();
            this.gbDobrodosli.ResumeLayout(false);
            this.gbDobrodosli.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureLogo;
        private System.Windows.Forms.GroupBox gbDobrodosli;
        private System.Windows.Forms.Label lblMejl;
        private System.Windows.Forms.Label lblSifra;
        private System.Windows.Forms.TextBox txtMejl;
        private System.Windows.Forms.TextBox txtSifra;
        private System.Windows.Forms.Button btnPrijaviSe;
    }
}

