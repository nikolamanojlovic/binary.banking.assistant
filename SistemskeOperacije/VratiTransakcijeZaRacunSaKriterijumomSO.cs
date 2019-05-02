using Domen;
using Sesija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemskeOperacije
{
    public class VratiTransakcijeZaRacunSaKriterijumomSO : OpstaSO
    {
        protected override bool Izvrsi(IDomenskiObjekat objekat, string kriterijum, string sifraJakog)
        {
            Transakcija transakcija = objekat as Transakcija;
            Rezultat = Broker.DajInstancu().VratiSveAgregiranebjekteSaKriterijumom(transakcija, kriterijum, sifraJakog);
            return true;
        }

        protected override bool IzvrsiStavke(List<IDomenskiObjekat> lodo, string kriterijum, string sifraJakog)
        {
            throw new NotImplementedException();
        }
    }
}
