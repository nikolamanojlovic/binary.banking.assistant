using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Sesija;

namespace SistemskeOperacije
{
    public class VratiKlijentaSO : OpstaSO
    {
        protected override bool Izvrsi(IDomenskiObjekat objekat)
        {
            Rezultat = Broker.DajInstancu().NadjiSlogIVratiGa(objekat as Klijent);
            return true;
        }
    }
}
