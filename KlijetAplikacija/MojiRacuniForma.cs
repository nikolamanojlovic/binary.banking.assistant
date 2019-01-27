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
    }
}
