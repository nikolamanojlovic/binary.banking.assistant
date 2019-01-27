using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Transakcija : IDomenskiAgregiraniObjekat
    {
        private DateTime vremenskaOznaka;
        private Klijent posiljalac;
        private Racun racunPosiljaoca;
        private Klijent primalac;
        private Racun racunPrimaoca;
        private double iznos;

        #region Get, Set
        public double Iznos
        {
            get { return iznos; }
            set { iznos = value; }
        }

        public Racun RacunPrimaoca
        {
            get { return racunPrimaoca; }
            set { racunPrimaoca = value; }
        }

        public Racun RacunPosiljaoca
        {
            get { return racunPosiljaoca; }
            set { racunPosiljaoca = value; }
        }

        public DateTime VremenskaOznaka
        {
            get { return vremenskaOznaka; }
            set { vremenskaOznaka = value; }
        }

        public Klijent Primalac
        {
            get { return primalac; }
            set { primalac = value; }
        }

        public Klijent Posiljalac
        {
            get { return posiljalac; }
            set { posiljalac = value; }
        }
        #endregion

        #region Metodes
        public string VratiNazivPK()
        {
            return Konstante.TabelaTransakcija.PK_TRANSAKCIJA_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaTransakcija.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaTransakcija.TABELA_TRASAKCIJA_UBACI, this.vremenskaOznaka, this.posiljalac.ID, this.racunPosiljaoca.ID,
                                 this.primalac.ID, this.racunPrimaoca.ID, this.iznos);
        }

        public string VratiUslovZaNadjiSlog()
        {
            if ( Primalac == null )
            {
                return Konstante.TabelaTransakcija.POLJE_POSILJALAC + "='" + Posiljalac.ID + "'";
            } else
            {
                return String.Join(" ", new string[] 
                {
                    Konstante.TabelaTransakcija.POLJE_POSILJALAC + "='" + Posiljalac.ID + "'",
                    Konstante.SQL.AND,
                    Konstante.TabelaTransakcija.POLJE_PRIMALAC + "='" + Primalac.ID + "'"
                });
            }
        }

        public string PostaviVrednostAtributa()
        {
            return String.Format(Konstante.TabelaTransakcija.TABELA_TRASAKCIJA_POSTAVI, this.vremenskaOznaka.ToString(Konstante.SQL.FORMAT_DATUMA),
                                 this.iznos);
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                if (citac.Read())
                {
                    objekat = new Transakcija()
                    {
                        VremenskaOznaka = DateTime.Parse(citac.GetString(0)),
                        Iznos = citac.GetDouble(8)
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

        #region Metode agregiranog objekta
        public string VratiVrednostiZaJoin()
        {
            return String.Join(" ", new String[]
            {
                String.Format(Konstante.SQL.JOIN, new String[] 
                {
                    Konstante.TabelaRacun.NAZIV_TABELE,
                    Konstante.TabelaTransakcija.POLJE_POSILJALAC + "='" + Posiljalac.ID + "' "
                }),
                String.Format(Konstante.SQL.JOIN, new String[]
                {
                    Konstante.TabelaRacun.NAZIV_TABELE,
                    Konstante.TabelaTransakcija.POLJE_PRIMALAC + "='" + Primalac.ID + "' "
                })
            });
        }
        #endregion

        #region Neimplementirane
        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
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

        #endregion
    }
}