using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class SlozeniKljucTransakcije
    {
        private Klijent posiljalac;
        private Racun racunPosiljaoca;
        private Klijent primalac;
        private Racun racunPrimaoca;

        #region Get, Set
        public Racun RacunPrimaoca
        {
            get { return racunPrimaoca; }
            set { racunPrimaoca = value; }
        }

        public Racun RacunPosiljaoca
        {
            get { return racunPosiljaoca; }
            set { racunPosiljaoca = value; }
        }

        public Klijent Primalac
        {
            get { return primalac; }
            set { primalac = value; }
        }

        public Klijent Posiljalac
        {
            get { return posiljalac; }
            set { posiljalac = value; }
        }
        #endregion
    }
}
