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
    public partial class OtvoriRacunForma : Form
    {
        private const String GRESKA_RACUNI = "Da biste mogli da sačuvate morate uneti bar jedan račun.";
        private const String GRESKA_BROJ_RACUNA = "Broj računa mora sadržati bar 10 brojeva.";
        private const String GRESKA_BROJ_RACUNA_PONOVLJEN = "Uneti broj računa se već nalazi u tabeli.";
        private const String GRESKA_KORISNIK = "Morate izabrati klijenta da biste sačuvali račune.";

        private GlavnaFormaAdmin glavnaFormaAdmin;
        private KontrolerOtvoriRacun kontrolerOtvoriRacun;

        public OtvoriRacunForma(GlavnaFormaAdmin glavnaFormaAdmin)
        {
            InitializeComponent();

            this.glavnaFormaAdmin = glavnaFormaAdmin;
            this.kontrolerOtvoriRacun = new KontrolerOtvoriRacun();

            dgvRacuni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
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

        public void PostaviID(string id)
        {
            txtID.Text = id;
        }

        private void OtvoriRacunForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.glavnaFormaAdmin.Show();
        }

        private void cbKorisnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            kontrolerOtvoriRacun.VratiID(this, (Klijent)cbKorisnici.SelectedItem);
            txtDatumKreiranja.Text = DateTime.Now.ToShortDateString();
            dgvRacuni.DataSource = null;
        }

        private void OtvoriRacunForma_Load(object sender, EventArgs e)
        {
            kontrolerOtvoriRacun.VratiSveKorisnike(this);
            cbTipRacuna.DataSource = Enum.GetNames(typeof(TipRacuna)).ToList<String>();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtBrojRacuna.Text) || txtBrojRacuna.Text.Length < 10 || !txtBrojRacuna.Text.All(x => char.IsNumber(x)) )
            {
                PrikaziInfoPoruku(GRESKA_BROJ_RACUNA);
                return;
            }

            if ( dgvRacuni.DataSource == null )
            {
                dgvRacuni.DataSource = new BindingList<Racun>();
            } else
            {
                if (((BindingList<Racun>)dgvRacuni.DataSource).ToList<Racun>().FindAll(x => x.BrojRacuna.Equals(txtBrojRacuna.Text)).Count > 0)
                {
                    PrikaziInfoPoruku(GRESKA_BROJ_RACUNA_PONOVLJEN);
                    return;
                }
            }

            ((BindingList<Racun>)dgvRacuni.DataSource).Add(new Racun()
            {
                ID = Convert.ToInt64(txtID.Text),
                BrojRacuna = txtBrojRacuna.Text,
                DatumKreiranja = DateTime.Parse(txtDatumKreiranja.Text),
                Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), cbTipRacuna.SelectedItem.ToString(), true)
            });

            txtID.Text = Convert.ToString(Convert.ToInt64(txtID.Text) + 1);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if ( dgvRacuni.DataSource == null )
            {
                PrikaziInfoPoruku(GRESKA_RACUNI);
                return;
            }

            if (cbKorisnici.SelectedItem == null)
            {
                PrikaziInfoPoruku(GRESKA_KORISNIK);
                return;
            }

            List<Racun> racuni = ((BindingList<Racun>)dgvRacuni.DataSource).ToList<Racun>();
            kontrolerOtvoriRacun.SacuvajRacune(this, (Klijent)cbKorisnici.SelectedItem, racuni);
        }
    }
}
