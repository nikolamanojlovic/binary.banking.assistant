using System;

namespace Domen
{
    public class Admin : Osoba
    {
        private string sifra;

        #region Get, Set
        public string Sifra
        {
            get { return sifra; }
            set { sifra = value; }
        }
        #endregion

        public override string VratiNazivPK()
        {
            throw new NotImplementedException();
        }

        public override string VratiNazivTabele()
        {
            throw new NotImplementedException();
        }

        public override string VratiVrednostiZaUbacivanje()
        {
            throw new NotSupportedException();
        }
    }
}
