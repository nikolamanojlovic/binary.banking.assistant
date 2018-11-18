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
        #endregion

        public string VratiNazivPK()
        {
            throw new System.NotImplementedException();
        }

        public string VratiNazivTabele()
        {
            throw new System.NotImplementedException();
        }

        public string VratiVrednostiZaUbacivanje()
        {
            throw new System.NotImplementedException();
        }
    }
}