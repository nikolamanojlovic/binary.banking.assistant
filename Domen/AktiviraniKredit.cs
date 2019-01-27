using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class AktiviraniKredit : IDomenskiObjekat
    {
        private Klijent klijent;
        private TipKredita tipKredita;
        private int brKredita;
        private DateTime datumUzimanja;
        private DateTime rokDospeca;
        private DateTime datumIsplate;
        private double kamata;
        private int brojRata;
        private List<Rata> rata;

        #region Get, Set
        public List<Rata> Rata
        {
            get { return rata; }
            set { rata = value; }
        }

        public double Kamata
        {
            get { return kamata; }
            set { kamata = value; }
        }

        public DateTime DatumIsplate
        {
            get { return datumIsplate; }
            set { datumIsplate = value; }
        }

        public DateTime RokDospeca
        {
            get { return rokDospeca; }
            set { rokDospeca = value; }
        }

        public DateTime DatumUzimanja
        {
            get { return datumUzimanja; }
            set { datumUzimanja = value; }
        }

        public int BRKredita
        {
            get { return brKredita; }
            set { brKredita = value; }
        }

        public TipKredita TipKredita
        {
            get { return tipKredita; }
            set { tipKredita = value; }
        }

        public Klijent Klijent
        {
            get { return klijent; }
            set { klijent = value; }
        }

        public int BrojRata
        {
            get { return brojRata; }
            set { brojRata = value; }
        }
        #endregion

        #region Metode
        public bool ImaVezaniObjekat()
        {
            return true;
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            if (citac.Read())
            {
                objekat = new AktiviraniKredit()
                {
                    Klijent = new Klijent() { },
                    TipKredita = new TipKredita() { },
                };
            }
            return false;
        }

        public bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as AktiviraniKredit).BRKredita = 0;
        }

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as AktiviraniKredit).BRKredita = Convert.ToInt32(citac[Konstante.TabelaAktiviraniKredit.PK_AK_ID]) + 1;
        }

        public string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + Klijent.ID + "'" + Konstante.SQL.AND + Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID + "='" + TipKredita.ID + "'";
        }

        public string VratiNazivPK()
        {
            return Konstante.TabelaAktiviraniKredit.PK_AK_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaAktiviraniKredit.NAZIV_TABELE;
        }

        public string VratiNazivTabeleVezanogObjekta()
        {
            return Konstante.TabelaRacun.NAZIV_TABELE;
        }

        public string VratiUslovZaNadjiSlog()
        {
            return String.Join(" ", new String[]
            {
                Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + Klijent.ID + "'" + Konstante.SQL.AND,
                Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID + "='" + TipKredita.ID + "'" + Konstante.SQL.AND,
                Konstante.TabelaAktiviraniKredit.PK_AK_ID + "='" + BRKredita + "'"
            });
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaAktiviraniKredit.TABELA_AK_UBACI, this.klijent.ID, this.tipKredita.ID, this.brKredita,
                                 this.datumUzimanja, this.rokDospeca, this.datumIsplate, this.kamata);
        }

        public string VratiUslovZaNadjiSlogove()
        {
            throw new NotImplementedException();
        }

        public IDomenskiObjekat VratiVezaniObjekat()
        {
            throw new NotImplementedException();
        }

        #region Neimplementirane
        public string PostaviVrednostAtributa()
        {
            throw new NotImplementedException();
        }

        public string VratiUslovZaJoin()
        {
            return "";
        }
        #endregion
        #endregion
    }
}
