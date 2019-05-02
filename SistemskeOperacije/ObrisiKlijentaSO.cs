using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Sesija;

namespace SistemskeOperacije
{
    public class ObrisiKlijentaSO : OpstaSO
    {
        protected override bool Izvrsi(IDomenskiObjekat objekat, string kriterijum = "", string sifraJakog = "")
        {
            Rezultat = Broker.DajInstancu().BrisiSlog(objekat);

            List<Racun> racuni = ((Klijent)objekat).Racuni;
            List<IDomenskiObjekat> lodo =  racuni != null ? racuni.ConvertAll(x => (IDomenskiObjekat) x) : null;
            Rezultat = IzvrsiStavke(lodo, sifraJakog: sifraJakog);
            return (bool) Rezultat;
        }

        protected override bool IzvrsiStavke(List<IDomenskiObjekat> lodo, string kriterijum = "", string sifraJakog = "")
        {
            Rezultat = true;
            if (lodo == null || lodo.Count == 0 )
            {
                return (bool)Rezultat;
            }

            List<Racun> racuni = lodo.ConvertAll(x => (Racun)x);
            foreach (Racun r in racuni)
            {
                Rezultat = Broker.DajInstancu().BrisiSlabeSlogove(r, sifraJakog);
            }

            return (bool)Rezultat;
        }
    }
}
