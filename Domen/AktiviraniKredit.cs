using System;
using System.Collections.Generic;

namespace Domen
{
    public class AktiviraniKredit : IDomenskiObjekat
    {
        private Klijent klijent;
        private TipKredita tipKredita;
        private int brKredita;
        private DateTime datumUzimanja;
        private DateTime rokDospeca;
        private DateTime datumIsplate;
        private double kamata;
        private List<Rata> rata;

        #region Get, Set
        public List<Rata> Rata
        {
            get { return rata; }
            set { rata = value; }
        }

        public double Kamata
        {
            get { return kamata; }
            set { kamata = value; }
        }

        public DateTime DatumIsplate
        {
            get { return datumIsplate; }
            set { datumIsplate = value; }
        }

        public DateTime RokDospeca
        {
            get { return rokDospeca; }
            set { rokDospeca = value; }
        }

        public DateTime DatumUzimanja
        {
            get { return datumUzimanja; }
            set { datumUzimanja = value; }
        }

        public int BRKredita
        {
            get { return brKredita; }
            set { brKredita = value; }
        }

        public TipKredita TipKredita
        {
            get { return tipKredita; }
            set { tipKredita = value; }
        }

        public Klijent Klijent
        {
            get { return klijent; }
            set { klijent = value; }
        }
        #endregion

        public string VratiNazivPK()
        {
            throw new NotImplementedException();
        }

        public string VratiNazivTabele()
        {
            throw new NotImplementedException();
        }

        public string VratiVrednostiZaUbacivanje()
        {
            throw new NotImplementedException();
        }
    }
}
