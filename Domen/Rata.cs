using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

        public bool ImaVezaniObjekat()
        {
            throw new NotImplementedException();
        }

        public bool Napuni(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public bool NapuniVezaneObjekte(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public string PostaviVrednostAtributa()
        {
            throw new NotImplementedException();
        }

        public void PovecajBroj(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public string VratiAtributPretrazivanja()
        {
            throw new NotImplementedException();
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

        public string VratiNazivTabeleVezanogObjekta()
        {
            return Konstante.TabelaRata.NAZIV_TABELE;
        }

        public string VratiUslovZaNadjiSlog()
        {
            throw new NotImplementedException();
        }

        public string VratiUslovZaNadjiSlogove()
        {
            throw new NotImplementedException();
        }

        public List<IDomenskiObjekat> VratiVezaniObjekat()
        {
            throw new NotImplementedException();
        }

        public string VratiVrednostiZaUbacivanje()
        {
            throw new NotImplementedException();
        }
    }
}
