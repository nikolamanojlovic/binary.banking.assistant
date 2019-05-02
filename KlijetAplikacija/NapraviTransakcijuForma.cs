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
    public partial class NapraviTransakcijuForma : Form
    {
        private const String JMBG_GRESKA = "Polje JMBG ne može biti prazno.";
        private const String RACUNI_GRESKA = "Računi moraju biti iste valute.";
        private const String IZNOS_GRESKA = "Proverite unete podatke.";

        private GlavnaFormaAdmin glavnaFormaAdmin;
        private KontrolerNapraviTransakciju kontrolerNapraviTransakciju;

        public NapraviTransakcijuForma(GlavnaFormaAdmin glavnaFormaAdmin)
        {
            InitializeComponent();

            this.glavnaFormaAdmin = glavnaFormaAdmin;
            kontrolerNapraviTransakciju = new KontrolerNapraviTransakciju();
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

        private void VratiVrednosi(string jmbg)
        {
            List<Klijent> lista = new List<Klijent>();
            lista.Add(kontrolerNapraviTransakciju.VratiPosiljaoca(this, jmbg));
            cbPosiljalac.DataSource = lista;

            if ( lista.Count == 0)
            {
                return;
            }

            if (cbPosiljalac.DataSource != null)
            {
                cbRacunPosiljalac.DataSource = (cbPosiljalac.SelectedItem as Klijent).Racuni;

                if ( cbRacunPosiljalac.DataSource != null )
                {
                    cbRacunPosiljalac.Enabled = true;
                }

                cbPrimalac.DataSource = kontrolerNapraviTransakciju.VratiPrimaoce(this);

                if ( cbPrimalac.DataSource != null )
                {
                    cbPrimalac.Enabled = true;
                    btnPosalji.Enabled = true;
                }
                else
                {
                    cbPrimalac.Enabled = false;
                }
            }
        }

        private void NapraviTransakcijuForma_FormClosed(object sender, FormClosedEventArgs e)
        {
            glavnaFormaAdmin.Show();
        }

        private void NapraviTransakcijuForma_Load(object sender, EventArgs e)
        {
            txtIznos.Text = Konstante.Opste.NULA;
        }

        private void btnPronadji_Click(object sender, EventArgs e)
        {
            if ( String.IsNullOrEmpty(txtJmbg.Text) )
            {
                PrikaziGreskaPoruku(JMBG_GRESKA);
                return;
            }

            VratiVrednosi(txtJmbg.Text);
        }

        private void cbRacunPrimalac_SelectedIndexChanged(object sender, EventArgs e)
        {
            Racun pos = cbRacunPosiljalac.SelectedItem as Racun;
            Racun prim = cbRacunPrimalac.SelectedItem as Racun;

            if ( pos == null || prim == null )
            {
                return;
            }

            if ( !pos.Tip.Equals(prim.Tip) )
            {
                PrikaziGreskaPoruku(RACUNI_GRESKA);
                btnPosalji.Enabled = false;
            } else
            {
                btnPosalji.Enabled = true;
            }
        }

        private void cbPrimalac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPrimalac.SelectedItem != null)
            {
                cbRacunPrimalac.DataSource = (cbPrimalac.SelectedItem as Klijent).Racuni;
                
                if ( cbRacunPrimalac.DataSource == null)
                {
                    cbRacunPrimalac.Enabled = false;
                    txtIznos.Enabled = false;
                    btnPosalji.Enabled = false;
                }
                else
                {
                    cbRacunPrimalac.Enabled = true;
                    txtIznos.Enabled = true;
                }
            }
            else
            {
                cbRacunPrimalac.Enabled = false;
                txtIznos.Enabled = false;
            }
        }

        private void btnPosalji_Click(object sender, EventArgs e)
        {
            try
            {
                Klijent pos = cbPosiljalac.SelectedItem as Klijent;
                Klijent prim = cbPrimalac.SelectedItem as Klijent;
                Transakcija transakcija = new Transakcija()
                {
                    Iznos = Convert.ToDouble(txtIznos.Text),
                    Posiljalac = cbRacunPosiljalac.SelectedItem as Racun,
                    Primalac = cbRacunPrimalac.SelectedItem as Racun,
                    VremenskaOznaka = DateTime.Now
                };

                kontrolerNapraviTransakciju.SacuvajTransakciju(this, transakcija, 
                                                               new KeyValuePair<long, long>(pos.ID, prim.ID));
            }
            catch (Exception)
            {
                PrikaziGreskaPoruku(IZNOS_GRESKA);
            }
        }
    }
}
