using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Rata : IDomenskiObjekat
    {
        private long rb;
        private DateTime rokDospeca;
        private Transakcija transakcija;

        #region Get, Set
        public Transakcija Transakcija
        {
            get { return transakcija; }
            set { transakcija = value; }
        }

        public DateTime RokDospeca
        {
            get { return rokDospeca; }
            set { rokDospeca = value; }
        }

        public long RB
        {
            get { return rb; }
            set { rb = value; }
        }
        #endregion

        #region Metode
        public string VratiNazivPK()
        {
            return Konstante.TabelaRata.PK_RATA_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaRata.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaRata.TABELA_RATA_UBACI, this.rb, this.rokDospeca.ToString(Konstante.SQL.FORMAT_DATUMA),
                                 this.transakcija.VremenskaOznaka, this.transakcija.Posiljalac.ID, this.transakcija.Primalac.ID);
        }

        public string VratiUslovZaNadjiSlog()
        {
            return Konstante.TabelaRata.POLJE_BROJ + "='" + RB + "'";
        }

        public string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaRata.POLJE_BROJ;
        }

        public string PostaviVrednostAtributa()
        {
            return String.Format(Konstante.TabelaRata.TABELA_RATA_POSTAVI, this.rb, this.rokDospeca.ToString(Konstante.SQL.FORMAT_DATUMA),
                                 this.transakcija.VremenskaOznaka, this.transakcija.Posiljalac.ID, this.transakcija.Primalac.ID);
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as Rata).RB = 0;
        }

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as Rata).RB = Convert.ToInt64(citac[Konstante.TabelaRata.POLJE_BROJ]) + 1;
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                if (citac.Read())
                {
                    objekat = new Rata()
                    {
                        /** ????*/
                        RB = citac.GetInt64(0),
                        RokDospeca = DateTime.Parse(citac.GetString(1))
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
}
