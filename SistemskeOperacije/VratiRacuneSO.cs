using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Sesija;

namespace SistemskeOperacije
{
    public class VratiRacuneSO : OpstaSO
    {
        protected override bool Izvrsi(IDomenskiObjekat objekat)
        {
            Rezultat = Broker.DajInstancu().NadjiVezaneSlogoveIVratiIh(objekat as Klijent);
            return true;
        }
    }
}
