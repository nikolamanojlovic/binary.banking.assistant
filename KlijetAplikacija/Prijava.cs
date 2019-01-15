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
    public partial class Prijava : Form
    {
        public Prijava()
        {
            InitializeComponent();
            PictureLogo.BackColor = Color.Transparent;

            txtSifra.PasswordChar = Convert.ToChar(Konstante.Opste.CRNA_TACKA);
        }
    }
}
