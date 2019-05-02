using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Transakcija : IDomenskiObjekat
    {
        private Racun posiljalac;
        private Racun primalac; 
        private DateTime vremenskaOznaka;
        private double iznos;

        #region Get, Set
        public Racun Posiljalac
        {
            get { return posiljalac; }
            set { posiljalac = value; }
        }

        public Racun Primalac
        {
            get { return primalac; }
            set { primalac = value; }
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

        #region Metode
        public string PostaviVrednostAtributa(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaTransakcija.TABELA_TRASAKCIJA_POSTAVI, this.iznos);
        }

        public string VratiKriterijumJakog(string sifraJakog = "")
        {
            return String.Format(Konstante.SQL.OR, new String[]
            {
                String.Format("{0} = '{1}'", Konstante.TabelaTransakcija.POLJE_POSILJALAC, sifraJakog),
                String.Format("{0} = '{1}'", Konstante.TabelaTransakcija.POLJE_PRIMALAC, sifraJakog)
            });
        }

        public List<IDomenskiObjekat> VratiListu(ref MySqlDataReader citac)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();

            while (citac.Read())
            {
                Transakcija transakcija = new Transakcija
                {
                    VremenskaOznaka = DateTime.Parse(Convert.ToString(citac["vremenska_oznaka"])),
                    Iznos = Convert.ToDouble(citac["iznos"]),
                    Posiljalac = new Racun
                    {
                        ID = Convert.ToInt64(citac["racun_id"]),
                        BrojRacuna = Convert.ToString(citac["broj_racuna"]),
                        Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), Convert.ToString(citac["tip_racuna"]), true),
                        DatumKreiranja = DateTime.Parse(Convert.ToString(citac["datum_kreiranja"]))
                    },
                    Primalac = new Racun()
                    {
                        ID = Convert.ToInt64(citac.GetValue(12)),
                        BrojRacuna = Convert.ToString(citac.GetValue(13)),
                        Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), Convert.ToString(citac.GetValue(14)), true),
                        DatumKreiranja = DateTime.Parse(Convert.ToString(citac.GetValue(15)))
                    }
                };
                lista.Add(transakcija);
            }

            return lista;
        }

        public string VratiNazivPK()
        {
            return Konstante.TabelaTransakcija.PK_TRANSAKCIJA_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaTransakcija.NAZIV_TABELE;
        }

        public string VratiPK()
        {
            return Convert.ToString(this.vremenskaOznaka);
        }

        public string VratiPKIUslov(string sifraJakog = "")
        {
            return String.Format("{0} AND {1} = '{2}'", this.VratiKriterijumJakog(), Konstante.TabelaTransakcija.PK_TRANSAKCIJA_ID, Convert.ToString(this.vremenskaOznaka));
        }

        public string VratiUslovZaNadjiSlog()
        {
            return Convert.ToString(vremenskaOznaka);
        }

        public string VratiVrednostiZaJoin(String sifraJakog = "")
        {
            return String.Join(" ", new string[] 
            {
                String.Format(Konstante.SQL.JOIN, new String[]
                {
                    Konstante.TabelaRacun.NAZIV_TABELE + Konstante.SQL.AS + " posiljalac ",
                    Konstante.TabelaTransakcija.POLJE_POSILJALAC_RACUN + " = posiljalac." + Konstante.TabelaRacun.PK_RACUN_ID 
                }),
                String.Format(Konstante.SQL.JOIN, new String[]
                {
                    Konstante.TabelaRacun.NAZIV_TABELE + Konstante.SQL.AS + " primalac ",
                    Konstante.TabelaTransakcija.POLJE_PRIMALAC_RACUN + " = primalac." + Konstante.TabelaRacun.PK_RACUN_ID
                })
            });
        }

        public string VratiVrednostiZaUbacivanje(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaTransakcija.TABELA_TRASAKCIJA_UBACI, this.vremenskaOznaka.ToString(Konstante.SQL.FORMAT_DATUMA), sifraJakog, this.iznos);
        }
        #endregion
    }
}