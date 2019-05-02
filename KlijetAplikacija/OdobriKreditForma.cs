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
    public partial class OdobriKreditForma : Form
    {
        private const String DATUM_I_TIP = "Morate izabrati tip kredita pre roka dospeća";
        private const String ROK_DOSPECA_POSLE_DANAS = "Rok dospeća mora biti datum posle današnjeg!";

        private const String KRATKOROCNI = "Rok dospeća kratkoročnog kredita je najviše 1 godina!";
        private const String SREDNJEROCNI = "Rok dospeća srednjeročnog kredita je od 1 do 5 godina!";
        private const String DUGOROCNI = "Rok dospeća dugoročnog kredita je više od 5 godina!";

        private const String KREDIT_IZNOS = "Za izabrani kredit iznos mora biti od {0} do {1}.";
        private const String KAMATA = "Kamata mora biti veća od 0.";
        private const String PROVERITE_INFORMACIJE = "Proverite unete informacije.";

        private GlavnaFormaAdmin glavnaFormaAdmin;
        private KontrolerOdobriKredit kontrolerOdobriKredit;

        public OdobriKreditForma(GlavnaFormaAdmin glavnaFormaAdmin)
        {
            InitializeComponent();

            this.glavnaFormaAdmin = glavnaFormaAdmin;
            this.kontrolerOdobriKredit = new KontrolerOdobriKredit();
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

        public void PopuniCBKorisnika(List<Klijent> list)
        {
            cbKorisnici.DataSource = list;
        }

        public void PopuniCBTipovaKredita(List<TipKredita> list)
        {
            cbTipKredita.DataSource = list;
        }

        public bool ValidirajDatume()
        {
            if (cbTipKredita.SelectedItem == null)
            {
                PrikaziInfoPoruku(DATUM_I_TIP);
                return false;
            }

            DateTime rokDospeca = dtpRokDospeca.Value.Date;
            DateTime datumUzimanja = dtpDatumUzimanja.Value.Date;
            TipKredita tip = cbTipKredita.SelectedItem as TipKredita;

            if (rokDospeca == datumUzimanja)
            {
                PrikaziInfoPoruku(ROK_DOSPECA_POSLE_DANAS);
                return false;
            }

            switch (tip.VremenskiOkvir)
            {
                case VremenskiOkvir.Kratkorocni:
                    if (datumUzimanja.AddYears(1) < rokDospeca)
                    {
                        PrikaziInfoPoruku(KRATKOROCNI);
                        return false;
                    }
                    break;
                case VremenskiOkvir.Srednjerocni:
                    if (datumUzimanja.AddYears(1) > rokDospeca || datumUzimanja.AddYears(5) < rokDospeca)
                    {
                        PrikaziInfoPoruku(SREDNJEROCNI);
                        return false;
                    }
                    break;
                case VremenskiOkvir.Dugorocni:
                    if (datumUzimanja.AddYears(5) < rokDospeca)
                    {
                        PrikaziInfoPoruku(DUGOROCNI);
                        return false;
                    }
                    break;
            }
            return true;
        }

        public bool ValidirajIznos()
        {
            TipKredita tip = cbTipKredita.SelectedItem as TipKredita;

            if (String.IsNullOrEmpty(txtIznos.Text) || !txtIznos.Text.All(x => Char.IsNumber(x)))
            {
                PrikaziInfoPoruku(String.Format(KREDIT_IZNOS, new String[]
                {
                    Convert.ToString(tip.MinDug),
                    Convert.ToString(tip.MaksDug)
                }));
                return false;
            }

            double iznos = Convert.ToDouble(txtIznos.Text);

            if ( iznos < tip.MinDug || iznos > tip.MaksDug )
            {
                PrikaziInfoPoruku(String.Format(KREDIT_IZNOS, new String[]
                {
                    Convert.ToString(tip.MinDug),
                    Convert.ToString(tip.MaksDug)
                }));
                return false;
            }
            return true;
        }

        public bool ValidirajKamatu()
        {
            if ( String.IsNullOrEmpty(txtKamata.Text) || !txtKamata.Text.All(x => Char.IsNumber(x)) || !(Convert.ToDouble(txtKamata.Text) > 0) )
            {
                PrikaziInfoPoruku(KAMATA);
                return false;
            }
            return true;
        }

        public int IzracunajBrojRata()
        { 
            return (dtpRokDospeca.Value.Date.Year - dtpDatumUzimanja.Value.Date.Year)*12 + dtpRokDospeca.Value.Date.Month
                   - dtpDatumUzimanja.Value.Date.Month;
        }

        public void PostaviIDKredita(String id)
        {
            txtBrojKredita.Text = id;
        }

        private void OdobriKreditForma_Load(object sender, EventArgs e)
        {
            kontrolerOdobriKredit.VratiSveKorisnike(this);
            kontrolerOdobriKredit.VratiSveTipoveKredita(this);
            dtpDatumUzimanja.Value = DateTime.Now;

            if (cbTipKredita.SelectedItem != null)
            {
                kontrolerOdobriKredit.PostaviBrojKredita(this, cbKorisnici.SelectedItem as Klijent);
            }
        }

        private void OdobriKreditForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            glavnaFormaAdmin.Show();
        }

        private void btnPostaviVrednosti_Click(object sender, EventArgs e)
        {
            if ( ValidirajDatume() && ValidirajIznos() && ValidirajKamatu() )
            {
                txtBrojRata.Text = Convert.ToString(IzracunajBrojRata());
                btnOdobri.Enabled = true;
                return;
            }
            btnOdobri.Enabled = false;
        }

        private void cbKorisnici_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTipKredita.SelectedItem != null)
            {
                kontrolerOdobriKredit.PostaviBrojKredita(this, cbKorisnici.SelectedItem as Klijent);
            }
        }

        private void btnOdobri_Click(object sender, EventArgs e)
        {
            try
            {
                AktiviraniKredit ak = new AktiviraniKredit()
                {
                    Klijent = cbKorisnici.SelectedItem as Klijent,
                    TipKredita = cbTipKredita.SelectedItem as TipKredita,
                    BRKredita = Convert.ToInt32(txtBrojKredita.Text),
                    BrojRata = Convert.ToInt32(txtBrojRata.Text),
                    Kamata = Convert.ToDouble(txtKamata.Text),
                    DatumUzimanja = dtpDatumUzimanja.Value.Date,
                    DatumIsplate = DateTime.MinValue,
                    RokDospeca = dtpRokDospeca.Value.Date,
                    Iznos = Convert.ToDouble(txtIznos.Text)
                };
                kontrolerOdobriKredit.OdobriKredit(this, ak);
            }
            catch (Exception)
            {
                PrikaziGreskaPoruku(PROVERITE_INFORMACIJE);
            }
        }
    }
}
