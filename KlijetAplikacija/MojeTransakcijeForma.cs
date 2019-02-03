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
    public partial class MojeTransakcijeForma : Form
    {
        public MojeTransakcijeForma()
        {
            InitializeComponent();
        }

        public void PostaviSveTransakcije(List<Racun> racuni)
        {
            throw new NotImplementedException();
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
    }
}
