using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class TipKredita : IDomenskiObjekat
    {
        private long id;
        private String naziv;
        private double minDug;
        private double maxDug;
        private VremenskiOkvir vremenskiOkvir;

        public VremenskiOkvir VremenskiOkvir
        {
            get { return vremenskiOkvir; }
            set { vremenskiOkvir = value; }
        }

        public double MaxDug
        {
            get { return maxDug; }
            set { maxDug = value; }
        }

        public double MinDug
        {
            get { return minDug; }
            set { minDug = value; }
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public string VratiNazivPK()
        {
            return Konstante.TabelaTipKredita.PK_TIP_RACUNA_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaRacun.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaRacun.TABELA_RACUN_UBACI, this.id, this.naziv, this.minDug, this.maxDug, this.vremenskiOkvir);
        }
    }

    public enum VremenskiOkvir
    {
        ShortTerm,
        MediumTerm,
        LongTerm
    }
}
