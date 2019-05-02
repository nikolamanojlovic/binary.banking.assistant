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
    public partial class IzmeniInformacijeForma : Form
    {
        private GlavnaFormaAdmin glavnaFormaAdmin;
        private KontrolerIzmeniKorisnika kontrolerIzmeniKorisnika;

        public IzmeniInformacijeForma(GlavnaFormaAdmin glavnaFormaAdmin)
        {
            InitializeComponent();

            this.glavnaFormaAdmin = glavnaFormaAdmin;
            this.kontrolerIzmeniKorisnika = new KontrolerIzmeniKorisnika();
        }

        private void cbKorisnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            Klijent k = (Klijent) cbKorisnici.SelectedItem;
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

        private void IzmeniInformacijeForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            glavnaFormaAdmin.Show();
        }

        private void IzmeniInformacijeForma_Load(object sender, EventArgs e)
        {
            kontrolerIzmeniKorisnika.VratiSveKorisnike(this);
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {
            Klijent k;

            try
            {
                k = new Klijent()
                {
                    ID = Convert.ToInt64(txtID.Text),
                    Ime = txtIme.Text,
                    Prezime = txtPrezime.Text,
                    JMBG = txtJmbg.Text,
                    Mejl = txtMejl.Text,
                    Sifra = txtSifra.Text,
                    Telefon = txtTelefon.Text,
                    Grad = txtGrad.Text,
                    Ulica = txtUlica.Text,
                    BrojKuce = Convert.ToInt32(txtBrojKuce.Text)
                };
            }
            catch (Exception)
            {
                k = null;
            }

            kontrolerIzmeniKorisnika.IzmeniKorisnika(this, k);
            kontrolerIzmeniKorisnika.VratiSveKorisnike(this);
        }
    }
}
