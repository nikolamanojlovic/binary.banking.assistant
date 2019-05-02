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
        protected override bool Izvrsi(IDomenskiObjekat objekat, string kriterijum, string sifraJakog)
        {
            List<IDomenskiObjekat> admin = Broker.DajInstancu().VratiPoKriterijumu(objekat, kriterijum);
            Rezultat = admin.FirstOrDefault();
            return true;
        }

        protected override bool IzvrsiStavke(List<IDomenskiObjekat> lodo, string kriterijum, string sifraJakog)
        {
            throw new NotImplementedException();
        }
    }
}
