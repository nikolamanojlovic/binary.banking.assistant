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
    }
}
