using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Sesija;

namespace SistemskeOperacije
{
    public class VratiIDNovogRacunaSO : OpstaSO
    {
        protected override bool Izvrsi(IDomenskiObjekat objekat, string kriterijum = "", string sifraJakog = "")
        {
            Rezultat = Broker.DajInstancu().VratiIDSlabog(objekat, objekat.VratiKriterijumJakog(sifraJakog));
            return true;
        }

        protected override bool IzvrsiStavke(List<IDomenskiObjekat> lodo, string kriterijum = "", string sifraJakog = "")
        {
            throw new NotImplementedException();
        }
    }
}
