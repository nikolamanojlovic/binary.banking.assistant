using Domen;
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
    public partial class GlavnaFormaAdmin : Form
    {
        public const String KREIRANJE_KORISNIKA = " - Kreiranje korisnika";
        public const String BRISANJE_KORISNIKA = " - Brisanje korisnika";
        public const String IZMENA_KORISNIKA = " - Izmena korisnika";
        public const String OTVARANJE_RACUNA = " - Otvaranje računa";
        public const String ODOBRAVANJE_KREDITA = " - Odobravanje kredita";

        public GlavnaFormaAdmin()
        {
            InitializeComponent();
        }

        private void GlavnaFormaAdmin_Load(object sender, EventArgs e)
        {
            this.txtImePrezimeAdmina.Text = String.Join(" ", new String[]
            {
                Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                Komunikacija.DajKomunikaciju().VratiSesiju().Prezime
            });
            this.txtMejlAdmina.Text = (Komunikacija.DajKomunikaciju().VratiSesiju() as Admin).Mejl;
            this.txtPozicijaAdmina.Text = (Komunikacija.DajKomunikaciju().VratiSesiju() as Admin).Pozicija;
        }

        private void btnKreirajKorisnika_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new KreirajKorisnikaForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime,
                                     KREIRANJE_KORISNIKA })
            }).Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new ObrisiKorisnikaForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime,
                                     BRISANJE_KORISNIKA })
            }).Show();
        }

        private void btnOdobriKredit_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new OdobriKreditForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime,
                                     ODOBRAVANJE_KREDITA })
            }).Show();
        }

        private void btnOtvoriRacun_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new OtvoriRacunForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime,
                                     OTVARANJE_RACUNA })
            }).Show();
        }

        private void btnIzmeniInformacije_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new IzmeniInformacijeForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime,
                                     IZMENA_KORISNIKA })
            }).Show();
        }

        private void btnNapraviTransakciju_Click(object sender, EventArgs e)
        {
            this.Hide();
            (new NapraviTransakcijuForma(this)
            {
                FormBorderStyle = FormBorderStyle.FixedSingle,
                StartPosition = FormStartPosition.CenterScreen,
                Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                     Komunikacija.DajKomunikaciju().VratiSesiju().Prezime,
                                     IZMENA_KORISNIKA })
            }).Show();
        }
    }
}
