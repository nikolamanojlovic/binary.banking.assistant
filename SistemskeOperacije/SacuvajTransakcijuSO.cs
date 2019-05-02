using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domen;
using Sesija;

namespace SistemskeOperacije
{
    public class SacuvajTransakcijuSO : OpstaSO
    {
        protected override bool Izvrsi(IDomenskiObjekat objekat, string kriterijum = "", string sifraJakog = "")
        {
            Transakcija transakcija = (Transakcija) objekat;
            String uslov1 = " '" + kriterijum + "', '" + transakcija.Posiljalac.ID + "', '" + sifraJakog + "', '" + transakcija.Primalac.ID + "' ";
            String uslov2 = " '" + sifraJakog + "', '" + transakcija.Primalac.ID + "', '" + kriterijum + "', '" + transakcija.Posiljalac.ID + "' ";
            return Broker.DajInstancu().PamtiSlog(objekat, uslov1) && Broker.DajInstancu().PamtiSlog(objekat, uslov2);
        }

        protected override bool IzvrsiStavke(List<IDomenskiObjekat> lodo, string kriterijum = "", string sifraJakog = "")
        {
            throw new NotImplementedException();
        }
    }
}
