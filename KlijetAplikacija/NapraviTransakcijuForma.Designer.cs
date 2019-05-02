namespace KlijetAplikacija
{
    partial class NapraviTransakcijuForma
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
            this.cbPosiljalac = new System.Windows.Forms.ComboBox();
            this.lblPosiljalac = new System.Windows.Forms.Label();
            this.lblPrimalac = new System.Windows.Forms.Label();
            this.cbPrimalac = new System.Windows.Forms.ComboBox();
            this.lblJmbg = new System.Windows.Forms.Label();
            this.txtJmbg = new System.Windows.Forms.TextBox();
            this.cbRacunPrimalac = new System.Windows.Forms.ComboBox();
            this.cbRacunPosiljalac = new System.Windows.Forms.ComboBox();
            this.txtIznos = new System.Windows.Forms.TextBox();
            this.lblIznos = new System.Windows.Forms.Label();
            this.btnPosalji = new System.Windows.Forms.Button();
            this.btnPronadji = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbPosiljalac
            // 
            this.cbPosiljalac.Enabled = false;
            this.cbPosiljalac.FormattingEnabled = true;
            this.cbPosiljalac.Location = new System.Drawing.Point(90, 118);
            this.cbPosiljalac.Name = "cbPosiljalac";
            this.cbPosiljalac.Size = new System.Drawing.Size(212, 21);
            this.cbPosiljalac.TabIndex = 0;
            // 
            // lblPosiljalac
            // 
            this.lblPosiljalac.AutoSize = true;
            this.lblPosiljalac.Location = new System.Drawing.Point(30, 121);
            this.lblPosiljalac.Name = "lblPosiljalac";
            this.lblPosiljalac.Size = new System.Drawing.Size(54, 13);
            this.lblPosiljalac.TabIndex = 1;
            this.lblPosiljalac.Text = "Pošiljalac:";
            // 
            // lblPrimalac
            // 
            this.lblPrimalac.AutoSize = true;
            this.lblPrimalac.Location = new System.Drawing.Point(354, 121);
            this.lblPrimalac.Name = "lblPrimalac";
            this.lblPrimalac.Size = new System.Drawing.Size(50, 13);
            this.lblPrimalac.TabIndex = 3;
            this.lblPrimalac.Text = "Primalac:";
            // 
            // cbPrimalac
            // 
            this.cbPrimalac.Enabled = false;
            this.cbPrimalac.FormattingEnabled = true;
            this.cbPrimalac.Location = new System.Drawing.Point(414, 118);
            this.cbPrimalac.Name = "cbPrimalac";
            this.cbPrimalac.Size = new System.Drawing.Size(212, 21);
            this.cbPrimalac.TabIndex = 2;
            this.cbPrimalac.SelectedIndexChanged += new System.EventHandler(this.cbPrimalac_SelectedIndexChanged);
            // 
            // lblJmbg
            // 
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Location = new System.Drawing.Point(29, 61);
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(39, 13);
            this.lblJmbg.TabIndex = 4;
            this.lblJmbg.Text = "JMBG:";
            // 
            // txtJmbg
            // 
            this.txtJmbg.Location = new System.Drawing.Point(89, 58);
            this.txtJmbg.Name = "txtJmbg";
            this.txtJmbg.Size = new System.Drawing.Size(212, 20);
            this.txtJmbg.TabIndex = 5;
            // 
            // cbRacunPrimalac
            // 
            this.cbRacunPrimalac.Enabled = false;
            this.cbRacunPrimalac.FormattingEnabled = true;
            this.cbRacunPrimalac.Location = new System.Drawing.Point(414, 145);
            this.cbRacunPrimalac.Name = "cbRacunPrimalac";
            this.cbRacunPrimalac.Size = new System.Drawing.Size(212, 21);
            this.cbRacunPrimalac.TabIndex = 7;
            this.cbRacunPrimalac.SelectedIndexChanged += new System.EventHandler(this.cbRacunPrimalac_SelectedIndexChanged);
            // 
            // cbRacunPosiljalac
            // 
            this.cbRacunPosiljalac.Enabled = false;
            this.cbRacunPosiljalac.FormattingEnabled = true;
            this.cbRacunPosiljalac.Location = new System.Drawing.Point(90, 145);
            this.cbRacunPosiljalac.Name = "cbRacunPosiljalac";
            this.cbRacunPosiljalac.Size = new System.Drawing.Size(212, 21);
            this.cbRacunPosiljalac.TabIndex = 6;
            // 
            // txtIznos
            // 
            this.txtIznos.Enabled = false;
            this.txtIznos.Location = new System.Drawing.Point(90, 198);
            this.txtIznos.Name = "txtIznos";
            this.txtIznos.Size = new System.Drawing.Size(212, 20);
            this.txtIznos.TabIndex = 8;
            // 
            // lblIznos
            // 
            this.lblIznos.AutoSize = true;
            this.lblIznos.Location = new System.Drawing.Point(30, 201);
            this.lblIznos.Name = "lblIznos";
            this.lblIznos.Size = new System.Drawing.Size(35, 13);
            this.lblIznos.TabIndex = 9;
            this.lblIznos.Text = "Iznos:";
            // 
            // btnPosalji
            // 
            this.btnPosalji.Enabled = false;
            this.btnPosalji.Location = new System.Drawing.Point(90, 224);
            this.btnPosalji.Name = "btnPosalji";
            this.btnPosalji.Size = new System.Drawing.Size(75, 23);
            this.btnPosalji.TabIndex = 10;
            this.btnPosalji.Text = "Pošalji";
            this.btnPosalji.UseVisualStyleBackColor = true;
            this.btnPosalji.Click += new System.EventHandler(this.btnPosalji_Click);
            // 
            // btnPronadji
            // 
            this.btnPronadji.Location = new System.Drawing.Point(307, 56);
            this.btnPronadji.Name = "btnPronadji";
            this.btnPronadji.Size = new System.Drawing.Size(75, 23);
            this.btnPronadji.TabIndex = 11;
            this.btnPronadji.Text = "Pronađi";
            this.btnPronadji.UseVisualStyleBackColor = true;
            this.btnPronadji.Click += new System.EventHandler(this.btnPronadji_Click);
            // 
            // NapraviTransakcijuForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 456);
            this.Controls.Add(this.btnPronadji);
            this.Controls.Add(this.btnPosalji);
            this.Controls.Add(this.lblIznos);
            this.Controls.Add(this.txtIznos);
            this.Controls.Add(this.cbRacunPrimalac);
            this.Controls.Add(this.cbRacunPosiljalac);
            this.Controls.Add(this.txtJmbg);
            this.Controls.Add(this.lblJmbg);
            this.Controls.Add(this.lblPrimalac);
            this.Controls.Add(this.cbPrimalac);
            this.Controls.Add(this.lblPosiljalac);
            this.Controls.Add(this.cbPosiljalac);
            this.Name = "NapraviTransakcijuForma";
            this.Text = "NapraviTransakcijuForma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NapraviTransakcijuForma_FormClosed);
            this.Load += new System.EventHandler(this.NapraviTransakcijuForma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbPosiljalac;
        private System.Windows.Forms.Label lblPosiljalac;
        private System.Windows.Forms.Label lblPrimalac;
        private System.Windows.Forms.ComboBox cbPrimalac;
        private System.Windows.Forms.Label lblJmbg;
        private System.Windows.Forms.TextBox txtJmbg;
        private System.Windows.Forms.ComboBox cbRacunPrimalac;
        private System.Windows.Forms.ComboBox cbRacunPosiljalac;
        private System.Windows.Forms.TextBox txtIznos;
        private System.Windows.Forms.Label lblIznos;
        private System.Windows.Forms.Button btnPosalji;
        private System.Windows.Forms.Button btnPronadji;
    }
}