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
        public string VratiPK()
        {
            return String.Format(" {0}, ", Convert.ToString(this.id));
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaTipKredita.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaTipKredita.TABELA_TIP_KREDITA_UBACI, this.id, this.naziv, this.minDug, this.maksDug, this.vremenskiOkvir);
        }

        public string VratiUslovZaNadjiSlog()
        {
            return Konstante.TabelaTipKredita.POLJE_NAZIV + "='" + Naziv + "'";
        }

        public string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID;
        }

        public string PostaviVrednostAtributa()
        {
            return String.Format(Konstante.TabelaTipKredita.TABELA_TIP_KREDITA_POSTAVI, this.id, this.naziv, this.minDug, this.maksDug, this.vremenskiOkvir);
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as TipKredita).ID = 0;
        }

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as TipKredita).ID = Convert.ToInt64(citac[Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID]) + 1;
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                objekat = new TipKredita()
                {
                    ID = Convert.ToInt64(citac["tip_kredita_id"]),
                    Naziv = Convert.ToString(citac["naziv"]),
                    MinDug = Convert.ToDouble(citac["min_dug"]),
                    MaksDug = Convert.ToDouble(citac["max_dug"]),
                    VremenskiOkvir = (VremenskiOkvir)Enum.Parse(typeof(VremenskiOkvir), Convert.ToString(citac["vremenski_okvir"]), true)
                };
                return true;

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

        public IDomenskiObjekat vratiAgregiraniObjekat()
        {
            return new AktiviraniKredit();
        }

        #region Neimplementirane
        public string VratiVrednostiZaJoin()
        {
            throw new NotImplementedException();
        }

        public string VratiUslovZaNadjiSlogove()
        {
            throw new NotImplementedException();
        }
        #endregion
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
