using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class DGVKredit
    {
        private String klijent;
        private String tipKredita;
        private String datumUzimanja;
        private String rokDospeca;
        private String datumIsplate;
        private double kamata;
        private int brojRata;

        #region Get, Set
        public double Kamata
        {
            get { return kamata; }
            set { kamata = value; }
        }

        [DisplayName("Datum isplate")]
        public String DatumIsplate
        {
            get { return datumIsplate; }
            set { datumIsplate = value; }
        }

        [DisplayName("Rok dospeća")]
        public String RokDospeca
        {
            get { return rokDospeca; }
            set { rokDospeca = value; }
        }

        [DisplayName("Datum uzimanja")]
        public String DatumUzimanja
        {
            get { return datumUzimanja; }
            set { datumUzimanja = value; }
        }

        [DisplayName("Tip kredita")]
        public String TipKredita
        {
            get { return tipKredita; }
            set { tipKredita = value; }
        }

        [DisplayName("Klijent")]
        public String Klijent
        {
            get { return klijent; }
            set { klijent = value; }
        }

        [DisplayName("Broj rata")]
        public int BrojRata
        {
            get { return brojRata; }
            set { brojRata = value; }
        }
        #endregion
    }
}
