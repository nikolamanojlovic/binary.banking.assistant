using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Klijent : Osoba, IDomenskiSlozeniObjekat
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
        public string VratiNazivPK()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID;
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
                if (citac.Read())
                {
                    objekat = new Klijent()
                    {
                        ID = citac.GetInt64(0),
                        JMBG = citac.GetString(1),
                        Ime = citac.GetString(2),
                        Prezime = citac.GetString(3),
                        Mejl = citac.GetString(4),
                        Telefon = citac.GetString(5),
                        Sifra = citac.GetString(6),
                        Ulica = citac.GetString(7),
                        BrojKuce = citac.GetInt32(8),
                        Grad = citac.GetString(9)
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
            return Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + ID + "'";
        }
        
        public IDomenskiObjekat VratiVezaniObjekat()
        {
            return new Racun();
        }

        public List<IDomenskiObjekat> VratiVezaneObjekte()
        {
            return new List<IDomenskiObjekat>(this.Racuni);
        }

        public bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                while (citac.Read())
                {
                    IDomenskiObjekat racun = new Racun();
                    racun.Napuni(citac, ref racun);
                    (objekat as Klijent).Racuni.Add(racun as Racun);
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
        #endregion
    }
}
 