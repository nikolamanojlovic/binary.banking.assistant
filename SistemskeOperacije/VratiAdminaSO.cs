using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Sesija;

namespace SistemskeOperacije
{
    public class VratiAdminaSO : OpstaSO
    {
        protected override bool Izvrsi(IDomenskiObjekat objekat)
        {
            return Broker.DajBrokera().Vrati();
        }
    }
}
