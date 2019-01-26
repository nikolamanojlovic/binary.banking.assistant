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

        public bool ImaVezaniObjekat()
        {
            throw new NotImplementedException();
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public string PostaviVrednostAtributa()
        {
            throw new NotImplementedException();
        }

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public string VratiAtributPretrazivanja()
        {
            throw new NotImplementedException();
        }
        #endregion

        public string VratiNazivPK()
        {
            return String.Concat(Konstante.TabelaKlijent.PK_KLIJENT_ID, Konstante.Opste.ZAREZ, Konstante.TabelaRacun.PK_RACUN_ID);
        }

        public string VratiNazivTabele()
        {
            throw new NotImplementedException();
        }

        public string VratiNazivTabeleVezanogObjekta()
        {
            return Konstante.TabelaRacun.NAZIV_TABELE;
        }

        public string VratiUslovZaJoin()
        {
            throw new NotImplementedException();
        }

        public string VratiUslovZaNadjiSlog()
        {
            throw new NotImplementedException();
        }

        public string VratiUslovZaNadjiSlogove()
        {
            throw new NotImplementedException();
        }

        public List<IDomenskiObjekat> VratiVezaniObjekat()
        {
            throw new NotImplementedException();
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
