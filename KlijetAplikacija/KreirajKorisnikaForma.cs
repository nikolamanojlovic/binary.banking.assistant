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
    public partial class KreirajKorisnikaForma : Form
    {
        private const String GRESKA_UNOS = "Došlo je do greške, proverite unete vrednosti!";

        private GlavnaFormaAdmin glavnaFormaAdmin;
        private KontrolerNoviKorisnik kontrolerNoviKorisnik;

        public KreirajKorisnikaForma(GlavnaFormaAdmin glavnaFormaAdmin)
        {
            InitializeComponent();

            this.glavnaFormaAdmin = glavnaFormaAdmin;
            this.kontrolerNoviKorisnik = new KontrolerNoviKorisnik();
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

        public void PonistiUnos()
        {
            List<TextBox> unosi = this.Controls.OfType<TextBox>().ToList();
            unosi.ForEach(x => 
            {
                if ( !x.Name.Equals("txtID"))
                {
                    x.Text = String.Empty;
                }
            });
        }

        internal void PostaviID(string id)
        {
            txtID.Text = id;
        }

        private void btnPonistiUnos_Click(object sender, EventArgs e)
        {
            PonistiUnos();
        }

        private void KreirajKorisnikaForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            glavnaFormaAdmin.Show();
        }

        private void KreirajKorisnikaForma_Load(object sender, EventArgs e)
        {
            kontrolerNoviKorisnik.VratiID(this);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            try
            {
                Klijent k = new Klijent()
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

                kontrolerNoviKorisnik.SacuvajKorisnika(this, k);

                List<TextBox> unosi = this.Controls.OfType<TextBox>().ToList();
                unosi.ForEach(x => x.Text = String.Empty);
                kontrolerNoviKorisnik.VratiID(this);
            }
            catch (Exception)
            {
                PrikaziGreskaPoruku(GRESKA_UNOS);
                PonistiUnos();
            }
        }
    }
}
