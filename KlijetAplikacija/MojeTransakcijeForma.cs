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
    public partial class MojeTransakcijeForma : Form
    {
        public const String RACUN = "racun";
        public const String UPLATE = "uplate";
        public const String ISPLATE = "isplate";
        public const String UPLATE_KREDITA = "uplate_kredita";
        public const String ISPLATE_KREDITA = "isplate_kredita";


        private KontrolerTransakcije kontrolerTransakcije;
        private GlavnaFormaKlijent glavnaFormaKlijent;

        public MojeTransakcijeForma(GlavnaFormaKlijent glavnaForma)
        {
            InitializeComponent();
            kontrolerTransakcije = new KontrolerTransakcije();
            this.glavnaFormaKlijent = glavnaForma;

            dgvMojeTransakije.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void PostaviSveTransakcije(List<Transakcija> transakcije)
        {
            dgvMojeTransakije.DataSource = transakcije;
        }

        public void PopuniCBRacuna(List<Racun> racuni)
        {
            if ( racuni != null )
            {
                btnPrikazi.Enabled = true;
                cbRacuni.Enabled = true;
                cbRacuni.DataSource = racuni;
            }
            else
            {
                btnPrikazi.Enabled = false;
                cbRacuni.Enabled = false;
            }
        }

        public Racun VratiIzabraniRacun()
        {
            return (Racun) cbRacuni.SelectedItem;
        }

        public Dictionary<String, String> VratiUsloveZaTransakcije()
        {
            return new Dictionary<String, String>()
            {
                { RACUN, Convert.ToString(this.VratiIzabraniRacun().ID) },
                { UPLATE, this.chbUplate.Checked.ToString() },
                { ISPLATE, this.chbIsplate.Checked.ToString() },
                { UPLATE_KREDITA, this.chbUplateKredita.Checked.ToString() },
                { ISPLATE_KREDITA, this.chbIsplateKredita.Checked.ToString() }
            };
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

        private void MojeTransakcijeForma_Load(object sender, EventArgs e)
        {
            kontrolerTransakcije.VratiRacune(this);
        }

        private void MojeTransakcijeForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            glavnaFormaKlijent.Show();
        }

        private void btnPrikazi_Click(object sender, EventArgs e)
        {
            kontrolerTransakcije.PrikaziSveTransakcije(this);
        }
    }
}
