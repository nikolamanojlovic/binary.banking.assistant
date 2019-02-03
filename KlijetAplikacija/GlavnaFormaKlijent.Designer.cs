namespace KlijetAplikacija
{
    partial class GlavnaFormaKlijent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GlavnaFormaKlijent));
            this.tableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.lblMojeTransakcija = new System.Windows.Forms.Label();
            this.lblMojiKrediti = new System.Windows.Forms.Label();
            this.pbTransakcije = new System.Windows.Forms.PictureBox();
            this.pbRacuni = new System.Windows.Forms.PictureBox();
            this.lblMojiRacuni = new System.Windows.Forms.Label();
            this.pbKrediti = new System.Windows.Forms.PictureBox();
            this.lblIzbor = new System.Windows.Forms.Label();
            this.lblRazvijeno = new System.Windows.Forms.Label();
            this.tableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransakcije)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRacuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKrediti)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayout
            // 
            this.tableLayout.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tableLayout.ColumnCount = 3;
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayout.Controls.Add(this.lblMojeTransakcija, 2, 1);
            this.tableLayout.Controls.Add(this.lblMojiKrediti, 1, 1);
            this.tableLayout.Controls.Add(this.pbTransakcije, 2, 0);
            this.tableLayout.Controls.Add(this.pbRacuni, 0, 0);
            this.tableLayout.Controls.Add(this.lblMojiRacuni, 0, 1);
            this.tableLayout.Controls.Add(this.pbKrediti, 1, 0);
            this.tableLayout.Location = new System.Drawing.Point(12, 53);
            this.tableLayout.Name = "tableLayout";
            this.tableLayout.RowCount = 2;
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.11189F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.88811F));
            this.tableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayout.Size = new System.Drawing.Size(346, 117);
            this.tableLayout.TabIndex = 0;
            // 
            // lblMojeTransakcija
            // 
            this.lblMojeTransakcija.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMojeTransakcija.AutoSize = true;
            this.lblMojeTransakcija.Location = new System.Drawing.Point(233, 103);
            this.lblMojeTransakcija.Name = "lblMojeTransakcija";
            this.lblMojeTransakcija.Size = new System.Drawing.Size(110, 13);
            this.lblMojeTransakcija.TabIndex = 5;
            this.lblMojeTransakcija.Text = "Transakcije";
            this.lblMojeTransakcija.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMojiKrediti
            // 
            this.lblMojiKrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMojiKrediti.AutoSize = true;
            this.lblMojiKrediti.Location = new System.Drawing.Point(118, 103);
            this.lblMojiKrediti.Name = "lblMojiKrediti";
            this.lblMojiKrediti.Size = new System.Drawing.Size(109, 13);
            this.lblMojiKrediti.TabIndex = 4;
            this.lblMojiKrediti.Text = "Krediti";
            this.lblMojiKrediti.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbTransakcije
            // 
            this.pbTransakcije.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbTransakcije.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbTransakcije.Image = ((System.Drawing.Image)(resources.GetObject("pbTransakcije.Image")));
            this.pbTransakcije.Location = new System.Drawing.Point(233, 3);
            this.pbTransakcije.Name = "pbTransakcije";
            this.pbTransakcije.Size = new System.Drawing.Size(110, 97);
            this.pbTransakcije.TabIndex = 3;
            this.pbTransakcije.TabStop = false;
            // 
            // pbRacuni
            // 
            this.pbRacuni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbRacuni.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbRacuni.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbRacuni.Image = ((System.Drawing.Image)(resources.GetObject("pbRacuni.Image")));
            this.pbRacuni.Location = new System.Drawing.Point(3, 3);
            this.pbRacuni.Name = "pbRacuni";
            this.pbRacuni.Size = new System.Drawing.Size(109, 97);
            this.pbRacuni.TabIndex = 0;
            this.pbRacuni.TabStop = false;
            this.pbRacuni.Click += new System.EventHandler(this.pbRacuni_Click);
            // 
            // lblMojiRacuni
            // 
            this.lblMojiRacuni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMojiRacuni.AutoSize = true;
            this.lblMojiRacuni.Location = new System.Drawing.Point(3, 103);
            this.lblMojiRacuni.Name = "lblMojiRacuni";
            this.lblMojiRacuni.Size = new System.Drawing.Size(109, 13);
            this.lblMojiRacuni.TabIndex = 1;
            this.lblMojiRacuni.Text = "Računi";
            this.lblMojiRacuni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbKrediti
            // 
            this.pbKrediti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbKrediti.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbKrediti.Image = ((System.Drawing.Image)(resources.GetObject("pbKrediti.Image")));
            this.pbKrediti.Location = new System.Drawing.Point(118, 3);
            this.pbKrediti.Name = "pbKrediti";
            this.pbKrediti.Size = new System.Drawing.Size(109, 97);
            this.pbKrediti.TabIndex = 2;
            this.pbKrediti.TabStop = false;
            this.pbKrediti.Click += new System.EventHandler(this.pbKrediti_Click);
            // 
            // lblIzbor
            // 
            this.lblIzbor.AutoSize = true;
            this.lblIzbor.Location = new System.Drawing.Point(9, 24);
            this.lblIzbor.Name = "lblIzbor";
            this.lblIzbor.Size = new System.Drawing.Size(120, 13);
            this.lblIzbor.TabIndex = 1;
            this.lblIzbor.Text = "Izaberite željenu uslugu:";
            // 
            // lblRazvijeno
            // 
            this.lblRazvijeno.AutoSize = true;
            this.lblRazvijeno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblRazvijeno.Location = new System.Drawing.Point(237, 205);
            this.lblRazvijeno.Name = "lblRazvijeno";
            this.lblRazvijeno.Size = new System.Drawing.Size(121, 13);
            this.lblRazvijeno.TabIndex = 2;
            this.lblRazvijeno.Text = "BBA - Nikola Manojlović";
            this.lblRazvijeno.Click += new System.EventHandler(this.lblRazvijeno_Click);
            // 
            // GlavnaFormaKlijent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 227);
            this.Controls.Add(this.lblRazvijeno);
            this.Controls.Add(this.lblIzbor);
            this.Controls.Add(this.tableLayout);
            this.Name = "GlavnaFormaKlijent";
            this.Text = " ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GlavnaFormaKlijent_FormClosed);
            this.tableLayout.ResumeLayout(false);
            this.tableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbTransakcije)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbRacuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbKrediti)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayout;
        private System.Windows.Forms.PictureBox pbRacuni;
        private System.Windows.Forms.Label lblMojiRacuni;
        private System.Windows.Forms.PictureBox pbKrediti;
        private System.Windows.Forms.Label lblMojeTransakcija;
        private System.Windows.Forms.Label lblMojiKrediti;
        private System.Windows.Forms.PictureBox pbTransakcije;
        private System.Windows.Forms.Label lblIzbor;
        private System.Windows.Forms.Label lblRazvijeno;
    }
}