using System;

namespace Domen
{
    public abstract class Osoba
    {
        protected long id;
        protected String jmbg;
        protected String ime;
        protected String prezime;
        protected String mejl;
        protected String telefon;

        #region Get, Set
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
    }
}
