using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Transakcija : IDomenskiAgregiraniObjekat
    {
        private SlozeniKljucTransakcije slozeniKljuc;
        private DateTime vremenskaOznaka;
        private double iznos;

        #region Get, Set
        public SlozeniKljucTransakcije SlozeniKljuc
        {
            get { return slozeniKljuc; }
            set { slozeniKljuc = value; }
        }

        public DateTime VremenskaOznaka
        {
            get { return vremenskaOznaka; }
            set { vremenskaOznaka = value; }
        }

        public double Iznos
        {
            get { return iznos; }
            set { iznos = value; }
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
            return String.Format(Konstante.TabelaTransakcija.TABELA_TRASAKCIJA_UBACI, this.vremenskaOznaka, this.slozeniKljuc.Posiljalac.ID, this.slozeniKljuc.RacunPosiljaoca.ID,
                                 this.slozeniKljuc.Primalac.ID, this.slozeniKljuc.RacunPrimaoca.ID, this.iznos);
        }

        public string VratiUslovZaNadjiSlog()
        {
            if ( SlozeniKljuc.Primalac == null )
            {
                return Konstante.TabelaTransakcija.POLJE_POSILJALAC + "='" + SlozeniKljuc.Posiljalac.ID + "'";
            } else
            {
                return String.Join(" ", new string[] 
                {
                    Konstante.TabelaTransakcija.POLJE_POSILJALAC + "='" + SlozeniKljuc.Posiljalac.ID + "'",
                    Konstante.SQL.AND,
                    Konstante.TabelaTransakcija.POLJE_PRIMALAC + "='" +  SlozeniKljuc.Primalac.ID + "'"
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
                    objekat = objekat as Transakcija;

                    IDomenskiObjekat pos = new Klijent();
                    pos.Napuni(citac, ref pos);

                    IDomenskiObjekat posr = new Racun();
                    posr.Napuni(citac, ref posr);

                    IDomenskiObjekat prim = new Klijent();
                    prim.Napuni(citac, ref prim);

                    IDomenskiObjekat primr = new Racun();
                    primr.Napuni(citac, ref primr);

                    Transakcija transakcija = new Transakcija()
                    {
                        SlozeniKljuc = new SlozeniKljucTransakcije()
                        {
                            Posiljalac = pos as Klijent,
                            Primalac = prim as Klijent,
                            RacunPosiljaoca = posr as Racun,
                            RacunPrimaoca = primr as Racun
                        },
                        VremenskaOznaka = DateTime.Parse(citac["vremenska_oznaka"] as String),
                        Iznos = Double.Parse(citac["iznos"] as String)
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
                    Konstante.TabelaTransakcija.POLJE_POSILJALAC + "='" + SlozeniKljuc.Posiljalac.ID + "' "
                }),
                String.Format(Konstante.SQL.JOIN, new String[]
                {
                    Konstante.TabelaRacun.NAZIV_TABELE,
                    Konstante.TabelaTransakcija.POLJE_PRIMALAC + "='" + SlozeniKljuc.Primalac.ID + "' "
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