using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private double iznos;

        #region Get, Sets
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

        [DisplayName("Iznos")]
        public double Iznos
        {
            get { return iznos; }
            set { iznos = value; }
        }
        #endregion

        #region Metode
        public string PostaviVrednostAtributa(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaAktiviraniKredit.TABELA_KLIJENT_POSTAVI, this.datumIsplate.ToString(Konstante.SQL.FORMAT_DATUMA), this.rokDospeca.ToString(Konstante.SQL.FORMAT_DATUMA),
                                                                                          this.datumIsplate.ToString(Konstante.SQL.FORMAT_DATUMA), this.kamata, this.brojRata);
        }

        public string VratiKriterijumJakog(string sifraJakog = "")
        {
            return String.Format(Konstante.SQL.OR, new String[]
            {
                String.Format("{0} = '{1}'", Konstante.TabelaKlijent.NAZIV_TABELE + Konstante.Opste.TACKA + Konstante.TabelaKlijent.PK_KLIJENT_ID, sifraJakog),
                String.Format("{0} = '{1}'", Konstante.TabelaTipKredita.NAZIV_TABELE + Konstante.Opste.TACKA + Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID, sifraJakog)
            });
        }

        public List<IDomenskiObjekat> VratiListu(ref MySqlDataReader citac)
        {
            List<IDomenskiObjekat> lista = new List<IDomenskiObjekat>();

            while (citac.Read())
            {
                Klijent klijent = new Klijent
                {
                    ID = Convert.ToInt64(citac["klijent_id"]),
                    JMBG = Convert.ToString(citac["jmbg"]),
                    Ime = Convert.ToString(citac["ime"]),
                    Prezime = Convert.ToString(citac["prezime"]),
                    Mejl = Convert.ToString(citac["mejl"]),
                    Telefon = Convert.ToString(citac["telefon"]),
                    Sifra = Convert.ToString(citac["sifra"]),
                    Ulica = Convert.ToString(citac["ulica"]),
                    BrojKuce = Convert.ToInt32(citac["broj_kuce"]),
                    Grad = Convert.ToString(citac["grad"])
                };

                TipKredita tipKredita = new TipKredita
                {
                    ID = Convert.ToInt64(citac["tip_kredita_id"]),
                    Naziv = Convert.ToString(citac["naziv"]),
                    MinDug = Convert.ToDouble(citac["min_dug"]),
                    MaksDug = Convert.ToDouble(citac["max_dug"]),
                    VremenskiOkvir = (VremenskiOkvir)Enum.Parse(typeof(VremenskiOkvir), Convert.ToString(citac["vremenski_okvir"]), true)
                };

                AktiviraniKredit ak = new AktiviraniKredit()
                {
                    Klijent = klijent,
                    TipKredita = tipKredita,
                    BRKredita = Convert.ToInt32(citac["broj_kredita"]),
                    DatumUzimanja = DateTime.Parse(Convert.ToString(citac["datum_uzimanja"])),
                    RokDospeca = DateTime.Parse(Convert.ToString(citac["rok_dospeca"])),
                    kamata = Convert.ToDouble(citac["kamata"]),
                    brojRata = Convert.ToInt32(citac["broj_rata"])
                };

                lista.Add(ak);
            }

            return lista;
        }

        public string VratiNazivPK()
        {
            return Konstante.TabelaAktiviraniKredit.PK_AK_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaAktiviraniKredit.NAZIV_TABELE;
        }

        public string VratiPK()
        {
            return Convert.ToString(this.brKredita);
        }

        public string VratiPKIUslov(string sifraJakog = "")
        {
            return String.Format("{0} AND {1} = '{2}'", this.VratiKriterijumJakog(sifraJakog) ,Konstante.TabelaAktiviraniKredit.PK_AK_ID, Convert.ToString(this.brKredita));
        }

        public string VratiUslovZaNadjiSlog()
        {
            return Convert.ToString(this.rokDospeca);
        }

        public string VratiVrednostiZaJoin(String sifraJakog = "")
        {
            return String.Join(" ", new String[] 
            {
                String.Format(Konstante.SQL.JOIN, new String[] 
                {
                    Konstante.TabelaKlijent.NAZIV_TABELE,
                    String.Format(" {0} = {1} ", new String[]
                    {
                        Konstante.TabelaKlijent.NAZIV_TABELE + Konstante.Opste.TACKA + Konstante.TabelaKlijent.PK_KLIJENT_ID,
                        Konstante.TabelaAktiviraniKredit.NAZIV_TABELE + Konstante.Opste.TACKA + Konstante.TabelaKlijent.PK_KLIJENT_ID
                    })
                }),
                String.Format(Konstante.SQL.JOIN, new String[] 
                {
                    Konstante.TabelaTipKredita.NAZIV_TABELE,
                    String.Format(" {0} = {1} ", new String[]
                    {
                        Konstante.TabelaTipKredita.NAZIV_TABELE + Konstante.Opste.TACKA + Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID,
                        Konstante.TabelaAktiviraniKredit.NAZIV_TABELE + Konstante.Opste.TACKA + Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID
                    })
                })
            });
        }

        public string VratiVrednostiZaUbacivanje(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaAktiviraniKredit.TABELA_AK_UBACI, this.klijent.ID, this.tipKredita.ID, this.brKredita, this.datumUzimanja.ToString(Konstante.SQL.FORMAT_DATUMA),
                                                                                   this.rokDospeca.ToString(Konstante.SQL.FORMAT_DATUMA), this.datumIsplate.ToString(Konstante.SQL.FORMAT_DATUMA), 
                                                                                   this.kamata, this.brojRata, this.iznos);
        }
        #endregion
    }
}
