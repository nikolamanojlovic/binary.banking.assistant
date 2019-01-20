using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public class Transakcija : IDomenskiObjekat
    {
        private Racun posiljalac;
        private Racun primalac;
        private double iznos;

        #region Get, Set
        public double Iznos
        {
            get { return iznos; }
            set { iznos = value; }
        }

        public Racun Primalac
        {
            get { return primalac; }
            set { primalac = value; }
        }

        public Racun Posiljalac
        {
            get { return posiljalac; }
            set { posiljalac = value; }
        }

        public bool ImaVezaniObjekat()
        {
            throw new System.NotImplementedException();
        }

        public bool Napuni(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new System.NotImplementedException();
        }

        public bool NapuniVezaneObjekte(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new System.NotImplementedException();
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            throw new System.NotImplementedException();
        }

        public string PostaviVrednostAtributa()
        {
            throw new System.NotImplementedException();
        }

        public void PovecajBroj(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new System.NotImplementedException();
        }

        public string VratiAtributPretrazivanja()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        public string VratiNazivPK()
        {
            throw new System.NotImplementedException();
        }

        public string VratiNazivTabele()
        {
            throw new System.NotImplementedException();
        }

        public string VratiNazivTabeleVezanogObjekta()
        {
            throw new System.NotImplementedException();
        }

        public string VratiUslovZaNadjiSlog()
        {
            throw new System.NotImplementedException();
        }

        public string VratiUslovZaNadjiSlogove()
        {
            throw new System.NotImplementedException();
        }

        public List<IDomenskiObjekat> VratiVezaniObjekat()
        {
            throw new System.NotImplementedException();
        }

        public string VratiVrednostiZaUbacivanje()
        {
            throw new System.NotImplementedException();
        }
    }
}