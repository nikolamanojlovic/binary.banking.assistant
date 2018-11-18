using System;

namespace Domen
{
    public class Admin : Osoba, IDomenskiObjekat
    {
        private string sifra;

        #region Get, Set
        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; }
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
