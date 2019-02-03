using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Browsable(false)]
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

        [DisplayName("Datum isplate")]
        public DateTime DatumIsplate
        {
            get { return datumIsplate; }
            set { datumIsplate = value; }
        }

        [DisplayName("Rok dospeća")]
        public DateTime RokDospeca
        {
            get { return rokDospeca; }
            set { rokDospeca = value; }
        }

        [DisplayName("Datum uzimanja")]
        public DateTime DatumUzimanja
        {
            get { return datumUzimanja; }
            set { datumUzimanja = value; }
        }

        [Browsable(false)]
        public int BRKredita
        {
            get { return brKredita; }
            set { brKredita = value; }
        }

        [DisplayName("Tip kredita")]
        public TipKredita TipKredita
        {
            get { return tipKredita; }
            set { tipKredita = value; }
        }

        [DisplayName("Klijent")]
        public Klijent Klijent
        {
            get { return klijent; }
            set { klijent = value; }
        }

        [DisplayName("Broj rata")]
        public int BrojRata
        {
            get { return brojRata; }
            set { brojRata = value; }
        }
        #endregion

        #region Metode
        public string VratiPK()
        {
            return String.Join(" {0}, {1}, {2}, ", new string[] { Convert.ToString(this.klijent.ID), Convert.ToString(this.tipKredita.ID), Convert.ToString(brKredita) });
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
                IDomenskiObjekat k = new Klijent();
                k.Napuni(citac, ref k);

                IDomenskiObjekat tk = new TipKredita();
                tk.Napuni(citac, ref tk);

                objekat = new AktiviraniKredit()
                {
                    Klijent = k as Klijent,
                    TipKredita = tk as TipKredita,
                    BRKredita = Convert.ToInt32(citac["broj_kredita"] as String),
                    DatumUzimanja = DateTime.Parse(Convert.ToString(citac["datum_uzimanja"])),
                    RokDospeca = DateTime.Parse(Convert.ToString(citac["rok_dospeca"])),
                    kamata = Convert.ToDouble(citac["kamata"]),
                    brojRata = Convert.ToInt32(citac["broj_rata"])
                };

                try
                {
                    (objekat as AktiviraniKredit).DatumIsplate = DateTime.Parse(Convert.ToString(citac["datum_isplate"]));
                }
                catch (FormatException ex)
                {
                    (objekat as AktiviraniKredit).DatumIsplate = DateTime.MaxValue;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
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

        public IDomenskiObjekat VratiAgregiraniObjekat()
        {
            throw new NotImplementedException();
        }
        #endregion
        #endregion
    }
}
