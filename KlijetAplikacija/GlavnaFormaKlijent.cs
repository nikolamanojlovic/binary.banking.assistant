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
    public partial class GlavnaFormaKlijent : Form
    {

        private static readonly string INFO_NASLOV = "BBA - Binary Banking Assistant";
        private static readonly string INFO_TEKST = "Projekat iz predmeta Projektovanje Softvera (FON, 2019)";

        public GlavnaFormaKlijent(Klijent klijent)
        {
            InitializeComponent();

            this.Text = String.Format(this.Text, new String[] { klijent.Ime, klijent.Prezime });

            this.pbRacuni.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbRacuni.BackColor = Color.Transparent;
            this.pbKrediti.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbKrediti.BackColor = Color.Transparent;
            this.pbTransakcije.SizeMode = PictureBoxSizeMode.Zoom;
            this.pbTransakcije.BackColor = Color.Transparent;
        }

        private void lblRazvijeno_Click(object sender, EventArgs e)
        {
            MessageBox.Show(INFO_TEKST, INFO_NASLOV, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
