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
            this.txtImePrezimeAdmina = new System.Windows.Forms.TextBox();
            this.txtMejlAdmina = new System.Windows.Forms.TextBox();
            this.txtPozicijaAdmina = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PictureLogo
            // 
            this.PictureLogo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureLogo.Image = ((System.Drawing.Image)(resources.GetObject("PictureLogo.Image")));
            this.PictureLogo.Location = new System.Drawing.Point(633, 318);
            this.PictureLogo.Name = "PictureLogo";
            this.PictureLogo.Size = new System.Drawing.Size(155, 120);
            this.PictureLogo.TabIndex = 1;
            this.PictureLogo.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPozicijaAdmina);
            this.groupBox1.Controls.Add(this.txtMejlAdmina);
            this.groupBox1.Controls.Add(this.txtImePrezimeAdmina);
            this.groupBox1.Location = new System.Drawing.Point(418, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 120);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ulogovani";
            // 
            // txtImePrezimeAdmina
            // 
            this.txtImePrezimeAdmina.Enabled = false;
            this.txtImePrezimeAdmina.Location = new System.Drawing.Point(6, 26);
            this.txtImePrezimeAdmina.Name = "txtImePrezimeAdmina";
            this.txtImePrezimeAdmina.Size = new System.Drawing.Size(188, 20);
            this.txtImePrezimeAdmina.TabIndex = 0;
            // 
            // txtMejlAdmina
            // 
            this.txtMejlAdmina.Enabled = false;
            this.txtMejlAdmina.Location = new System.Drawing.Point(6, 57);
            this.txtMejlAdmina.Name = "txtMejlAdmina";
            this.txtMejlAdmina.Size = new System.Drawing.Size(188, 20);
            this.txtMejlAdmina.TabIndex = 1;
            // 
            // txtPozicijaAdmina
            // 
            this.txtPozicijaAdmina.Enabled = false;
            this.txtPozicijaAdmina.Location = new System.Drawing.Point(6, 83);
            this.txtPozicijaAdmina.Name = "txtPozicijaAdmina";
            this.txtPozicijaAdmina.Size = new System.Drawing.Size(188, 20);
            this.txtPozicijaAdmina.TabIndex = 2;
            // 
            // GlavnaFormaAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PictureLogo);
            this.Name = "GlavnaFormaAdmin";
            this.Text = "GlavnaFormaAdmin";
            ((System.ComponentModel.ISupportInitialize)(this.PictureLogo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox PictureLogo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPozicijaAdmina;
        private System.Windows.Forms.TextBox txtMejlAdmina;
        private System.Windows.Forms.TextBox txtImePrezimeAdmina;
    }
}