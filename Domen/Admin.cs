using System;

namespace Domen
{
    public class Admin : Osoba
    {
        private string pozicija;

        #region Get, Set
        public string Pozicija
        {
            get { return pozicija; }
            set { pozicija = value; }
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
