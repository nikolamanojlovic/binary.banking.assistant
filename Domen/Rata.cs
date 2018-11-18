using System;

namespace Domen
{
    public class Rata : IDomenskiObjekat
    {
        private long rb;
        private DateTime rokDospeca;
        private Transakcija transakcija;

        #region Get, Set
        public Transakcija Transakcija
        {
            get { return transakcija; }
            set { transakcija = value; }
        }

        public DateTime RokDospeca
        {
            get { return rokDospeca; }
            set { rokDospeca = value; }
        }

        public long RB
        {
            get { return rb; }
            set { rb = value; }
        }
        #endregion

        public string VratiNazivPK()
        {
            throw new NotImplementedException();
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaRata.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
            throw new NotImplementedException();
        }
    }
}
