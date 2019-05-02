using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class TipKredita : IDomenskiObjekat
    {
        private long id;
        private String naziv;
        private double minDug;
        private double maksDug;
        private VremenskiOkvir vremenskiOkvir;

        #region Get, Set
        public VremenskiOkvir VremenskiOkvir
        {
            get { return vremenskiOkvir; }
            set { vremenskiOkvir = value; }
        }

        public double MaksDug
        {
            get { return maksDug; }
            set { maksDug = value; }
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
        #endregion

        #region Metode
        public string PostaviVrednostAtributa(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaTipKredita.TABELA_TIP_KREDITA_POSTAVI, this.naziv, this.minDug, this.maksDug, this.vremenskiOkvir);
        }

        public string VratiKriterijumJakog(string sifraJakog = "")
        {
            return String.Empty;
        }

        public List<IDomenskiObjekat> VratiListu(ref MySqlDataReader citac)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();

            while (citac.Read())
            {
                TipKredita tipKredita = new TipKredita
                {
                    ID = Convert.ToInt64(citac["tip_kredita_id"]),
                    Naziv = Convert.ToString(citac["naziv"]),
                    MinDug = Convert.ToDouble(citac["min_dug"]),
                    MaksDug = Convert.ToDouble(citac["max_dug"]),
                    VremenskiOkvir = (VremenskiOkvir)Enum.Parse(typeof(VremenskiOkvir), Convert.ToString(citac["vremenski_okvir"]), true)
                };
                lista.Add(tipKredita);
            }

            return lista;
        }

        public string VratiNazivPK()
        {
            return Konstante.TabelaAktiviraniKredit.PK_AK_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaTipKredita.NAZIV_TABELE;
        }

        public string VratiPK()
        {
            return String.Format(" {0}, ", Convert.ToString(this.id));
        }

        public string VratiPKIUslov(string sifraJakog = "")
        {
            return String.Format("{0} = '{1}'", Konstante.TabelaAktiviraniKredit.PK_AK_ID, Convert.ToString(this.id));
        }

        public string VratiUslovZaNadjiSlog()
        {
            return this.naziv;
        }

        public string VratiVrednostiZaJoin(String sifraJakog = "")
        {
            return String.Empty;
        }

        public string VratiVrednostiZaUbacivanje(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaTipKredita.TABELA_TIP_KREDITA_UBACI, this.id, this.naziv, this.minDug, this.maksDug, this.vremenskiOkvir);
        }
        #endregion

        public override string ToString()
        {
            return Naziv;
        }
    }

    public enum VremenskiOkvir
    {
        Kratkorocni,
        Srednjerocni,
        Dugorocni
    }
}
