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
        private const String kriterijumRacuna = " broj_racuna LIKE '%{0}%' ";

        protected override bool Izvrsi(IDomenskiObjekat objekat, string kriterijum, string sifraJakog)
        {
            Klijent klijent = objekat as Klijent;
            if ( !String.IsNullOrEmpty(kriterijum) )
            {
                Rezultat = Broker.DajInstancu().VratiSveSlabeObjekteSaKriterijumom(new Racun(), String.Format(kriterijumRacuna, kriterijum), klijent.VratiPK());
            } else
            {
                Rezultat = Broker.DajInstancu().VratiSveSlabeObjekte(new Racun(), klijent.VratiPK());
            }
            return true;
        }

        protected override bool IzvrsiStavke(List<IDomenskiObjekat> lodo, string kriterijum, string sifraJakog)
        {
            throw new NotImplementedException();
        }
    }
}
