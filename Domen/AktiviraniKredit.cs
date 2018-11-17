using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class AktiviraniKredit : IDomenskiObjekat
    {
        private Klijent klijent;
        private TipKredita tipKredita;
        private DateTime datumUzimanja;
        private DateTime rokDospeca;
        private DateTime datumIsplate;
        private double kamata;
        private List<Rata> rata;

        public List<Rata> Rata
        {
            get { return rata; }
            set { rata = value; }
        }

        public double Kamata
        {
            get { return kamata; }
            set { kamata = value; }
        }

        public DateTime DatumIsplate
        {
            get { return datumIsplate; }
            set { datumIsplate = value; }
        }

        public DateTime RokDospeca
        {
            get { return rokDospeca; }
            set { rokDospeca = value; }
        }

        public DateTime DatumUzimanja
        {
            get { return datumUzimanja; }
            set { datumUzimanja = value; }
        }

        public TipKredita TipKredita
        {
            get { return tipKredita; }
            set { tipKredita = value; }
        }

        public Klijent Klijent
        {
            get { return klijent; }
            set { klijent = value; }
        }
       
        public string VratiNazivPK()
        {
            throw new NotImplementedException();
        }

        public string VratiNazivTabele()
        {
            throw new NotImplementedException();
        }

        public string VratiVrednostiZaUbacivanje()
        {
            throw new NotImplementedException();
        }
    }
}
