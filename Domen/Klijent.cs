using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Klijent : Osoba, IDomenskiSlozeniObjekat, IDomenskiAgregiraniObjekat
    {
        private String ulica;
        private int brojKuce;
        private String grad;
        private List<Racun> racuni;

        #region Get, Set
        public List<Racun> Racuni
        {
            get { return racuni; }
            set { racuni = value; }
        }

        public String Grad
        {
            get { return grad; }
            set { grad = value; }
        }

        public int BrojKuce
        {
            get { return brojKuce; }
            set { brojKuce = value; }
        }

        public String Ulica
        {
            get { return ulica; }
            set { ulica = value; }
        }
        #endregion

        #region Metode
        public string VratiPK()
        {
            return String.Format(" {0}, ", Convert.ToString(this.id));
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaKlijent.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaKlijent.TABELA_KLIJENT_UBACI, this.id, this.jmbg, this.ime, this.prezime, this.mejl,
                                 this.telefon, this.sifra, this.ulica, this.brojKuce, this.grad);
        }

        public string VratiUslovZaNadjiSlog()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_MEJL + "='" + Mejl + "'";
        }

        public string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + ID + "'";
        }

        public string PostaviVrednostAtributa()
        {
            return String.Format(Konstante.TabelaKlijent.TABELA_KLIJENT_POSTAVI, this.id, this.jmbg, this.ime, this.prezime, this.mejl,
                                 this.telefon, this.sifra, this.ulica, this.brojKuce, this.grad);
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as Klijent).ID = 0;
        }

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as Klijent).ID = Convert.ToInt64(citac[Konstante.TabelaKlijent.PK_KLIJENT_ID]) + 1;
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                objekat = new Klijent()
                {
                    ID = Convert.ToInt64(citac["klijent_id"] as String),
                    JMBG = citac["jmbg"] as String,
                    Ime = citac["ime"] as String,
                    Prezime = citac["prezime"] as String,
                    Mejl = citac["mejl"] as String,
                    Telefon = citac["telefon"] as String,
                    Sifra = citac["sifra"] as String,
                    Ulica = citac["ulica"] as String,
                    BrojKuce = Convert.ToInt32(citac["brojKuce"] as String),
                    Grad = citac["grad"] as String
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
            return true;
        }

        #region Metode vezane za slab objekat
        public string VratiUslovZaNadjiSlogove()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + ID + "'";
        }
        
        public IDomenskiObjekat VratiVezaniObjekat()
        {
            return new Racun();
        }

        public List<IDomenskiObjekat> VratiVezaneObjekte()
        {
            if ( Racuni == null )
            {
                return null;
            }
            else
            {
                return new List<IDomenskiObjekat>(Racuni);
            }
        }

        public bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
               if (citac.HasRows)
                {
                    while(citac.Read())
                    {
                        if ( (objekat as Klijent).Racuni == null )
                        {
                            (objekat as Klijent).Racuni = new List<Racun>();
                        }

                        (objekat as Klijent).Racuni.Add(new Racun()
                        {
                            ID = Convert.ToInt64(citac["racun_id"] as String),
                            BrojRacuna = citac["broj_racuna"] as String,
                            Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), citac["tip_racuna"] as String, true),
                            DatumKreiranja = DateTime.Parse(Convert.ToString(citac["datum_kreiranja"]))
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }
        #endregion

        public IDomenskiObjekat VratiAgregiraniObjekat()
        {
            return new AktiviraniKredit();
        }

        #region Neimplementirane
        public string VratiVrednostiZaJoin()
        {
            return String.Join(" ", new String[]
            {
                String.Format(Konstante.SQL.JOIN, new String[]
            {
                Konstante.TabelaKlijent.NAZIV_TABELE,
                " klijent.klijent_id = aktivni_kredit.klijent_id "
            }),
                String.Format(Konstante.SQL.JOIN, new String[]
            {
                Konstante.TabelaTipKredita.NAZIV_TABELE,
                " tip_kredita.tip_kredita_id = aktivni_kredit.tip_kredita_id "
            }),

        });
        }
        #endregion
        #endregion

        public override string ToString()
        {
            return JMBG + Konstante.Opste.ZAREZ + String.Join(" ", new string[] { Ime, Prezime });
        }
    }
}
 