using Domen;
using Sesija;
using System;
using System.Collections.Generic;

namespace SistemskeOperacije
{
    public abstract class OpstaSO
   {
        protected object rezultat;

        #region Get, Set
        public object Rezultat
        {
            get { return rezultat; }
            set { rezultat = value; }
        }
        #endregion

        public bool IzvrsiSO(IDomenskiObjekat objekat, String kriterijum = "", String sifraJakog = "")
        {
            bool rezultat;
            try
            {
                Broker.DajInstancu().OtvoriKonekciju();
                Broker.DajInstancu().ZapocniTransakciju();
                rezultat = Izvrsi(objekat, kriterijum, sifraJakog);
                Broker.DajInstancu().ZatvoriCitac();
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
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Broker.DajInstancu().ZatvoriKonekciju();
            }
        }

        public bool IzvrsiStavkeSO(List<IDomenskiObjekat> stavke, String kriterijum = "", String sifraJakog = "")
        {
            bool rezultat;
            try
            {
                Broker.DajInstancu().OtvoriKonekciju();
                Broker.DajInstancu().ZapocniTransakciju();
                rezultat = IzvrsiStavke(stavke, kriterijum, sifraJakog);
                Broker.DajInstancu().ZatvoriCitac();
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
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                Broker.DajInstancu().ZatvoriKonekciju();
            }
        }

        protected abstract bool Izvrsi(IDomenskiObjekat objekat, String kriterijum = "", String sifraJakog = "");
        protected abstract bool IzvrsiStavke(List<IDomenskiObjekat> lodo, String kriterijum = "", String sifraJakog = "");
    }
}
