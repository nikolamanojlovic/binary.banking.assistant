using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public abstract class Osoba
    {
        protected long id;
        protected String jmbg;
        protected String ime;
        protected String prezime;
        protected String mejl;
        protected String telefon;
        protected String sifra;

        #region Get, Set
        [Browsable(false)]
        public String Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }

        [Browsable(false)]
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

        [Browsable(false)]
        public String JMBG
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        [Browsable(false)]
        public long ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion
    }
}
