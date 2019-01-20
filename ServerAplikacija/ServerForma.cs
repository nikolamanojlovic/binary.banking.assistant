using Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAplikacija
{
    public partial class ServerForma : Form
    {
        private const String GRESKA_SERVER = "Nije moguce pokrenuti server!";
        private const String POKRENUT_SERVER = "Server je pokrenut!";
        private const String ZAUSTAVLJEN_SERVER = "Server nije pokrenut!";

        private Server server;
        private Thread serverNit;

        public ServerForma()
        {
            InitializeComponent();
            KontrolerPL.DajKontroler().Forma = this;

            btnZaustavi.Enabled = false;
            txtStatus.Text = ZAUSTAVLJEN_SERVER;
        }

        private void btnPokreni_Click(object sender, EventArgs e)
        {
            try
            {
                ThreadStart ts = PokreniServer;
                serverNit = new Thread(ts);
                serverNit.Start();

                PrikaziElemente();
                this.OsveziLog(POKRENUT_SERVER);
            }
            catch
            {
                MessageBox.Show(String.Format(Konstante.GUI.GRESKA_TEKST, GRESKA_SERVER), Konstante.GUI.GRESKA_NASLOV,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                SakrijiElemente();
            }
        }

        public void OsveziLog(String poruka)
        {
            txtLog.AppendText(poruka + Konstante.GUI.NOVI_RED);
        }

        private void btnZaustavi_Click(object sender, EventArgs e)
        {
            SakrijiElemente();
            ZaustaviServer();
        }

        private void PrikaziElemente()
        {
            this.btnZaustavi.Enabled = true;
            this.btnPokreni.Enabled = false;

            // 
            // dgvAktivni
            // 
            this.dgvAktivni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAktivni.Location = new System.Drawing.Point(15, 280);
            this.dgvAktivni.Name = "dgvAktivni";
            this.dgvAktivni.Size = new System.Drawing.Size(255, 122);
            this.dgvAktivni.TabIndex = 4;
            this.dgvAktivni.ReadOnly = true;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(15, 92);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(256, 157);
            this.txtLog.TabIndex = 5;
            this.txtLog.ReadOnly = true;
            this.txtLog.Cursor = DefaultCursor;
            // 
            // lblAktivni
            // 
            this.lblAktivni.AutoSize = true;
            this.lblAktivni.Location = new System.Drawing.Point(12, 256);
            this.lblAktivni.Name = "lblAktivni";
            this.lblAktivni.Size = new System.Drawing.Size(42, 13);
            this.lblAktivni.TabIndex = 6;
            this.lblAktivni.Text = "Aktivni:";

            this.ClientSize = new System.Drawing.Size(291, 414);
            this.Controls.Add(this.lblAktivni);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.dgvAktivni);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAktivni)).EndInit();

            txtStatus.Text = POKRENUT_SERVER;
            CenterToScreen();
        }

        private void SakrijiElemente()
        {
            txtStatus.Text = ZAUSTAVLJEN_SERVER;
            btnZaustavi.Enabled = false;
            btnPokreni.Enabled = true;

            this.Controls.Remove(this.lblAktivni);
            this.Controls.Remove(this.txtLog);
            this.Controls.Remove(this.dgvAktivni);
            this.ClientSize = new System.Drawing.Size(291, 100);
            CenterToScreen();
        }

        private void PokreniServer()
        {
            server = new Server();
            server.StartServer();
        }

        private void ZaustaviServer()
        {
            server.StopServer();
        }

        public delegate void OsveziLogCallback(string text);
    }
}
