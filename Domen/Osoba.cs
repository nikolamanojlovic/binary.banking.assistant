using System;

namespace Domen
{
    public abstract class Osoba : IDomenskiObjekat
    {
        protected long id;
        protected String jmbg;
        protected String ime;
        protected String prezime;
        protected String mejl;
        protected String telefon;
        private String sifra;

        #region Get, Set
        public String Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        public String Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public String Mejl
        {
            get { return mejl; }
            set { mejl = value; }
        }

        public String Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public String Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public String JMBG
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        public abstract string VratiNazivPK();
        public abstract string VratiNazivTabele();
        public abstract string VratiVrednostiZaUbacivanje();
    }
}
