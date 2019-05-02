using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Domen
{
    [Serializable]
    public class Racun : IDomenskiObjekat
    {
        private long id;
        private String brojRacuna;
        private TipRacuna tip;
        private DateTime datumKreiranja;

        #region Get, Set
        [DisplayName("Datum kreiranja")]
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

        [DisplayName("Broj računa")]
        public String BrojRacuna
        {
            get { return brojRacuna; }
            set { brojRacuna = value; }
        }

        [Browsable(false)]
        public long ID
        {
            get { return id; }
            set { id = value; }
        }
        #endregion

        #region Metode
        public string PostaviVrednostAtributa(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaRacun.TABELA_RACUN_POSTAVI, this.brojRacuna, this.tip, this.datumKreiranja.ToString(Konstante.SQL.FORMAT_DATUMA));
        }

        public string VratiKriterijumJakog(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaKlijent.PK_KLIJENT_ID +  " = '{0}'", sifraJakog);
        }

        public List<IDomenskiObjekat> VratiListu(ref MySqlDataReader citac)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();

            while (citac.Read())
            {
                Racun racun = new Racun
                {
                    ID = Convert.ToInt64(citac["racun_id"]),
                    BrojRacuna = Convert.ToString(citac["broj_racuna"]),
                    Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), Convert.ToString(citac["tip_racuna"]), true),
                    DatumKreiranja = DateTime.Parse(Convert.ToString(citac["datum_kreiranja"]))
                };
                lista.Add(racun);
            }

            return lista;
        }

        public string VratiNazivPK()
        {
            return Konstante.TabelaRacun.PK_RACUN_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaRacun.NAZIV_TABELE;
        }

        public string VratiPK()
        {
            return String.Format(" {0}, ", Convert.ToString(this.id));
        }

        public string VratiPKIUslov(string sifraJakog = "")
        {
            return String.Format("{0} AND {1} = '{2}'", this.VratiKriterijumJakog(sifraJakog),  Konstante.TabelaRacun.PK_RACUN_ID, Convert.ToString(this.id));
        }

        public string VratiUslovZaNadjiSlog()
        {
            return this.brojRacuna;
        }

        public string VratiVrednostiZaJoin(String sifraJakog = "")
        {
            return String.Empty;
        }

        public string VratiVrednostiZaUbacivanje(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaRacun.TABELA_RACUN_UBACI, sifraJakog, this.id, this.brojRacuna, this.tip, this.datumKreiranja.ToString(Konstante.SQL.FORMAT_DATUMA));
        }
        #endregion

        public override string ToString()
        {
            return this.brojRacuna + Konstante.Opste.ZAREZ + this.tip.ToString();
        }
    }

    public enum TipRacuna
    {
        RSD,
        EUR,
        USD
    }
}
