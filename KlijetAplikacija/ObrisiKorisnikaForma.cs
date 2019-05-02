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
    public partial class ObrisiKorisnikaForma : Form
    {

        private GlavnaFormaAdmin glavnaFormaAdmin;
        private KontrolerObrisiKorisnika kontrolerObrisiKorisnika;

        public ObrisiKorisnikaForma(GlavnaFormaAdmin glavnaFormaAdmin)
        {
            InitializeComponent();

            this.glavnaFormaAdmin = glavnaFormaAdmin;
            this.kontrolerObrisiKorisnika = new KontrolerObrisiKorisnika();
        }

        public void PrikaziInfoPoruku(String poruka)
        {
            MessageBox.Show(String.Format(Konstante.GUI.INFO_TEKS, poruka), Konstante.GUI.INFO_NASLOV,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void PrikaziGreskaPoruku(String poruka)
        {
            MessageBox.Show(String.Format(Konstante.GUI.GRESKA_TEKST, poruka), Konstante.GUI.GRESKA_NASLOV,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void PopuniCBKorisnika(List<Klijent> klijenti)
        {
            cbKorisnici.DataSource = klijenti;
        }

        private void ObrisiKorisnikaForma_Load(object sender, EventArgs e)
        {
            kontrolerObrisiKorisnika.VratiSveKorisnike(this);
        }

        private void ObrisiKorisnikaForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            glavnaFormaAdmin.Show();
        }

        private void cbKorisnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            Klijent k = (Klijent)cbKorisnici.SelectedItem;
            txtID.Text = Convert.ToString(k.ID);
            txtIme.Text = k.Ime;
            txtPrezime.Text = k.Prezime;
            txtJmbg.Text = k.JMBG;
            txtMejl.Text = k.Mejl;
            txtSifra.Text = k.Sifra;
            txtTelefon.Text = k.Telefon;
            txtGrad.Text = k.Grad;
            txtUlica.Text = k.Ulica;
            txtBrojKuce.Text = Convert.ToString(k.BrojKuce);
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            kontrolerObrisiKorisnika.ObrisiKorisnika(this, (Klijent)cbKorisnici.SelectedItem);
            kontrolerObrisiKorisnika.VratiSveKorisnike(this);

            List<TextBox> unosi = this.Controls.OfType<TextBox>().ToList();
            unosi.ForEach(x => x.Text = String.Empty);
        }
    }
}
