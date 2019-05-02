using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Sesija;

namespace SistemskeOperacije
{
    public class SacuvajKlijentoveRacuneSO : OpstaSO
    {
        protected override bool Izvrsi(IDomenskiObjekat objekat, string kriterijum = "", string sifraJakog = "")
        {
            throw new NotImplementedException();
        }

        protected override bool IzvrsiStavke(List<IDomenskiObjekat> lodo, string kriterijum = "", string sifraJakog = "")
        {
            Rezultat = true;
            foreach(IDomenskiObjekat o in lodo)
            {
                if ( !Broker.DajInstancu().PamtiSlog(o, sifraJakog) )
                {
                    Rezultat = false;
                }
            }
            return (bool) Rezultat;
        }
    }
}
