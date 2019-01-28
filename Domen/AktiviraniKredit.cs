using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class AktiviraniKredit : IDomenskiAgregiraniObjekat, IDomenskiSlozeniObjekat
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
        public string VratiNazivPK()
        {
            return Konstante.TabelaAktiviraniKredit.PK_AK_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaAktiviraniKredit.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaAktiviraniKredit.TABELA_AK_UBACI, this.klijent.ID, this.tipKredita.ID, this.brKredita, this.datumIsplate.ToString(Konstante.SQL.FORMAT_DATUMA),
                                this.rokDospeca.ToString(Konstante.SQL.FORMAT_DATUMA), this.datumIsplate.ToString(Konstante.SQL.FORMAT_DATUMA), this.kamata, this.brojRata);
        }

        public string VratiUslovZaNadjiSlog()
        {
            return Konstante.TabelaAktiviraniKredit.PK_AK_ID + "='" + BRKredita + "'";
        }

        public string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaAktiviraniKredit.PK_AK_ID + "='" + BRKredita + "'";
        }

        public string PostaviVrednostAtributa()
        {
            return String.Format(Konstante.TabelaKlijent.TABELA_KLIJENT_POSTAVI, this.klijent.ID, this.tipKredita.ID, this.brKredita, this.datumIsplate.ToString(Konstante.SQL.FORMAT_DATUMA),
                                this.rokDospeca.ToString(Konstante.SQL.FORMAT_DATUMA), this.datumIsplate.ToString(Konstante.SQL.FORMAT_DATUMA), this.kamata, this.brojRata);
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as AktiviraniKredit).BRKredita = 0;
        }

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as AktiviraniKredit).BRKredita = Convert.ToInt32(citac[Konstante.TabelaAktiviraniKredit.PK_AK_ID]) + 1;
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                if (citac.Read())
                {
                    IDomenskiObjekat k = new Klijent();
                    k.Napuni(citac, ref k);

                    IDomenskiObjekat tk = new TipKredita();
                    tk.Napuni(citac, ref tk);

                    objekat = new AktiviraniKredit()
                    {
                        Klijent = k as Klijent,
                        TipKredita = tk as TipKredita,
                        BRKredita = Convert.ToInt32(citac["broj_kredita"] as String),
                        DatumUzimanja = DateTime.Parse(citac["datum_uzimanja"] as String),
                        RokDospeca = DateTime.Parse(citac["rok_dospeca"] as String),
                        DatumIsplate = DateTime.Parse(citac["datum_isplate"] as String),
                        kamata = Convert.ToDouble(citac["kamata"] as String),
                        brojRata = Convert.ToInt32(citac["broj_rata"] as String)
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
            return true;
        }

        #region Metode vezane za slab objekat
        public string VratiUslovZaNadjiSlogove()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + Klijent.ID + "'" + Konstante.SQL.AND + Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID + "='" + TipKredita.ID +
                   Konstante.SQL.AND + Konstante.TabelaAktiviraniKredit.PK_AK_ID + "='" + BRKredita + "'";
        }

        public IDomenskiObjekat VratiVezaniObjekat()
        {
            return new Rata();
        }

        public List<IDomenskiObjekat> VratiVezaneObjekte()
        {
            return new List<IDomenskiObjekat>(this.Rata);
        }

        public bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                while (citac.Read())
                {
                    IDomenskiObjekat r = new Rata();
                    r.Napuni(citac, ref r);
                    (objekat as AktiviraniKredit).Rata.Add(r as Rata);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public string VratiVrednostiZaJoin()
        {
            return String.Join(" ", new String[]
            {
                String.Format(Konstante.SQL.JOIN, new String[]
                {
                    Konstante.TabelaKlijent.NAZIV_TABELE,
                    Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + Klijent.ID + "' "
                }),
                String.Format(Konstante.SQL.JOIN, new String[]
                {
                    Konstante.TabelaTipKredita.NAZIV_TABELE,
                    Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID + "='" + TipKredita.ID + "' "
                })
            });
        }
        #endregion
        #endregion
    }
}
