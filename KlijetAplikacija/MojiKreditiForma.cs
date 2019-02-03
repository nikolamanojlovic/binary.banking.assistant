using Domen;
using KlijetAplikacija.Kontroleri;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace KlijetAplikacija
{
    public partial class MojiKreditiForma : Form
    {
        public const String KREDITI_NE_POSTOJE_KRIJERIJUM = "Krediti za kriterijum <{0}> ne postoje!";

        private List<DGVKredit> kreditiKlijenta;
        private GlavnaFormaKlijent glavnaFormaKlijent;
        private KontrolerKrediti kontrolerKrediti;

        public MojiKreditiForma(GlavnaFormaKlijent glavnaForma)
        {
            InitializeComponent();
            this.glavnaFormaKlijent = glavnaForma;
            this.kontrolerKrediti = new KontrolerKrediti();
            this.kreditiKlijenta = new List<DGVKredit>();

            dgvMojiKrediti.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMojiKrediti.DataSource = new BindingList<DGVKredit>(kreditiKlijenta);
        }

        public void OsveziTabeluKredita(List<AktiviraniKredit> krediti)
        {
            List<DGVKredit> k = new List<DGVKredit>();

            krediti.ForEach(kredit =>
            {
                k.Add(new DGVKredit()
                {
                    Klijent = kredit.Klijent.ToString(),
                    TipKredita = kredit.TipKredita.ToString(),
                    BrojRata = kredit.BrojRata,
                    Kamata = kredit.Kamata,
                    DatumIsplate = DateTime.MaxValue.Equals(kredit.DatumIsplate) ? "NEPOZNATO" : kredit.DatumIsplate.ToShortDateString(),
                    DatumUzimanja = kredit.DatumUzimanja.ToShortDateString(),
                    RokDospeca = kredit.RokDospeca.ToShortDateString()
                });
            });
            
            dgvMojiKrediti.DataSource = new BindingList<DGVKredit>(k);
        }

        public void PostaviSveKredite(List<AktiviraniKredit> krediti)
        {
            OsveziTabeluKredita(krediti);
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

        private void MojiKreditiForma_Load(object sender, EventArgs e)
        {
            kontrolerKrediti.PrikaziSveRacune(this);
        }
    }
}
