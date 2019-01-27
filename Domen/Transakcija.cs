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
        private Racun posiljalac;
        private Racun primalac;
        private double iznos;

        #region Get, Set
        public double Iznos
        {
            get { return iznos; }
            set { iznos = value; }
        }

        public Racun Primalac
        {
            get { return primalac; }
            set { primalac = value; }
        }

        public Racun Posiljalac
        {
            get { return posiljalac; }
            set { posiljalac = value; }
        }

        public DateTime VremenskaOznaka
        {
            get { return vremenskaOznaka; }
            set { vremenskaOznaka = value; }
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
            return String.Format(Konstante.TabelaTransakcija.TABELA_TRASAKCIJA_UBACI, this.vremenskaOznaka, this.primalac, this.posiljalac, this.iznos);
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
                        Posiljalac = new Racun()
                        {
                            ID = citac.GetInt64(1),
                            BrojRacuna = citac.GetString(2),
                            Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), citac.GetString(3), true),
                            DatumKreiranja = DateTime.Parse(citac.GetString(4))
                        },
                        Primalac = new Racun()
                        {
                            ID = citac.GetInt64(5),
                            BrojRacuna = citac.GetString(6),
                            Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), citac.GetString(7), true),
                            DatumKreiranja = DateTime.Parse(citac.GetString(8))
                        },
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