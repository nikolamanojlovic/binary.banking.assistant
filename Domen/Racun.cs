using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;

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

        public string VratiUslovZaNadjiSlog()
        {
            return Konstante.TabelaRacun.POLJE_BROJ + "LIKE '*" + BrojRacuna + "*'";
        }

        public string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaRacun.PK_RACUN_ID;
        }

        public string PostaviVrednostAtributa()
        {
            return String.Format(Konstante.TabelaRacun.TABELA_RACUN_POSTAVI, this.id, this.brojRacuna, this.tip, this.datumKreiranja.ToString(Konstante.SQL.FORMAT_DATUMA));
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as Racun).ID = 0;
        }

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as Racun).ID = Convert.ToInt64(citac[Konstante.TabelaRacun.PK_RACUN_ID]) + 1;
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                if (citac.Read())
                {
                    objekat = new Racun()
                    {
                        ID = citac.GetInt64(0),
                        BrojRacuna = citac.GetString(1),
                        Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), citac.GetString(2), true),
                        DatumKreiranja = DateTime.Parse(citac.GetString(3))
                    };
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool ImaVezaniObjekat()
        {
            return false;
        }
        #endregion
    }

    public enum TipRacuna
    {
        RSD,
        EUR,
        USD
    }
}
