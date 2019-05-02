namespace KlijetAplikacija
{
    partial class MojiKreditiForma
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
            this.dgvMojiKrediti = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMojiKrediti)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMojiKrediti
            // 
            this.dgvMojiKrediti.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMojiKrediti.Location = new System.Drawing.Point(12, 12);
            this.dgvMojiKrediti.Name = "dgvMojiKrediti";
            this.dgvMojiKrediti.Size = new System.Drawing.Size(664, 432);
            this.dgvMojiKrediti.TabIndex = 5;
            // 
            // MojiKreditiForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 456);
            this.Controls.Add(this.dgvMojiKrediti);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MojiKreditiForma";
            this.Text = "MojiKreditiForma";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MojiKreditiForma_FormClosed);
            this.Load += new System.EventHandler(this.MojiKreditiForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMojiKrediti)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMojiKrediti;
    }
}