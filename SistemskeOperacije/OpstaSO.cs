using Domen;
using Sesija;
using System;

namespace SistemskeOperacije
{
    public abstract class OpstaSO
    {
        public bool IzvrsiSO(IDomenskiObjekat objekat)
        {
            bool rezultat = false;
            try
            {
                Broker.DajInstancu().OtvoriKonekciju();
                Broker.DajInstancu().ZapocniTransakciju();
                rezultat = Izvrsi(objekat);
                if (rezultat)
                {
                    Broker.DajInstancu().PotvrdiTransakciju();
                }
                else
                {
                    Broker.DajInstancu().PonistiTransakciju();
                }
                return rezultat;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                Broker.DajInstancu().ZatvoriKonekciju();
            }
        }

        protected abstract bool Izvrsi(IDomenskiObjekat objekat);
    }
}
