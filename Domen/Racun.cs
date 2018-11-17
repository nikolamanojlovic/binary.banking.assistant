using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Racun : IDomenskiObjekat
    {
        private long id;
        private String brojRacuna;
        private TipRacuna tip;
        private DateTime datumKreiranja;

        public DateTime DatumKreiranja
        {
            get { return datumKreiranja; }
            set { datumKreiranja = value; }
        }

        public TipRacuna Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public String BrojRacuna
        {
            get { return brojRacuna; }
            set { brojRacuna = value; }
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public string VratiNazivPK()
        {
            return String.Concat(Konstante.TabelaKlijent.PK_KLIJENT_ID, Konstante.Opste.ZAREZ, Konstante.TabelaRacun.PK_RACUN_ID);
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaRacun.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
          return String.Format(Konstante.TabelaRacun.TABELA_RACUN_UBACI, this.id, this.brojRacuna, this.tip, this.datumKreiranja.ToString(Konstante.SQL.FORMAT_DATUMA));
        }
    }

    public enum TipRacuna
    {
        RSD,
        EUR,
        USD
    }
}
