using Domen;
using KlijetAplikacija.Kontroleri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KlijetAplikacija
{
    public partial class Prijava : Form
    {
        KontrolerPrijava kontroler;

        public Prijava()
        {
            InitializeComponent();
            kontroler = new KontrolerPrijava();

            PictureLogo.BackColor = Color.Transparent;
            txtSifra.PasswordChar = Convert.ToChar(Konstante.Opste.CRNA_TACKA);
        }

        public void PrikaziGreskaPoruku(String poruka)
        {
            MessageBox.Show(String.Format(Konstante.GUI.GRESKA_TEKST, poruka), Konstante.GUI.GRESKA_NASLOV,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnPrijaviSe_Click(object sender, EventArgs e)
        {
            kontroler.PrijaviKlijenta(txtMejl.Text, txtSifra.Text, this);
        }
    }
}
