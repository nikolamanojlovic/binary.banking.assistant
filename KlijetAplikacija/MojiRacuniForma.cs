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
    public partial class MojiRacuniForma : Form
    {
        public const String RACUNI_NE_POSTOJE_KRIJERIJUM = "Računi za kriterijum <{0}> ne postoje!";

        private GlavnaFormaKlijent glavnaFormaKlijent;
        private KontrolerRacuni kontrolerRacuni;

        public MojiRacuniForma(GlavnaFormaKlijent glavnaForma)
        {
            InitializeComponent();
            this.glavnaFormaKlijent = glavnaForma;
            this.kontrolerRacuni = new KontrolerRacuni();

            dgvMojiRacuni.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void OsveziTabeluRacuna(List<Racun> racuni)
        {
            dgvMojiRacuni.DataSource = new BindingList<Racun>(racuni);
        }

        public void PostaviSveRacune(List<Racun> racuni)
        {
            if ( racuni != null )
            {
                OsveziTabeluRacuna(racuni);
            }
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

        private void MojiRacuniForma_Load(object sender, EventArgs e)
        {
            kontrolerRacuni.PrikaziSveRacune(this);
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void MojiRacuniForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            glavnaFormaKlijent.Show();
        }

        private void txtPretraga_Leave(object sender, EventArgs e)
        {

            if ( String.IsNullOrEmpty(txtPretraga.Text) )
            {
                return;
            }

            List<Racun> filter = kontrolerRacuni.PrikaziRacuneSaKriterijumom(this, txtPretraga.Text);

            if (filter == null && !String.IsNullOrEmpty(txtPretraga.Text))
            {
                PrikaziGreskaPoruku(String.Format(RACUNI_NE_POSTOJE_KRIJERIJUM, txtPretraga.Text));
                return;
            }

            OsveziTabeluRacuna(filter);
        }
    }
}
