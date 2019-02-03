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
        public string VratiPK()
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
                                 this.transakcija.VremenskaOznaka, this.transakcija.SlozeniKljuc.Posiljalac.ID, this.transakcija.SlozeniKljuc.RacunPosiljaoca.ID,
                                 this.transakcija.SlozeniKljuc.Primalac.ID, this.transakcija.SlozeniKljuc.RacunPrimaoca.ID);
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
                                 this.transakcija.VremenskaOznaka, this.transakcija.SlozeniKljuc.Posiljalac.ID, this.transakcija.SlozeniKljuc.RacunPosiljaoca.ID,
                                 this.transakcija.SlozeniKljuc.Primalac.ID, this.transakcija.SlozeniKljuc.RacunPrimaoca.ID);
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
                    IDomenskiObjekat trans = new Transakcija();
                    trans.Napuni(citac, ref trans);

                    objekat = new Rata()
                    {
                        RB = Convert.ToInt64(citac["redni_broj"] as String),
                        RokDospeca = DateTime.Parse(citac["rok_dospeca"] as String),
                        Transakcija = trans as Transakcija
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

        public string VratiUslovZaNadjiSlogove()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
