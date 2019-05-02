using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Klijent : Osoba, IDomenskiObjekat
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
        public string VratiKriterijumJakog(string sifraJakog = "")
        {
            return String.Empty;
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
                lista.Add(klijent);
            }
            return lista;
        }

        public string VratiNazivPK()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaKlijent.NAZIV_TABELE;
        }

        public string VratiPK()
        {
            return Convert.ToString(this.id);
        }

        public string VratiPKIUslov(string sifraJakog = "")
        {
            return String.Format("{0} = '{1}'", Konstante.TabelaKlijent.PK_KLIJENT_ID, Convert.ToString(this.id));
        }

        public string VratiUslovZaNadjiSlog()
        {
            return this.JMBG;
        }

        public string VratiVrednostiZaJoin(String sifraJakog = "")
        {
            return String.Empty;
        }

        public string PostaviVrednostAtributa(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaKlijent.TABELA_KLIJENT_POSTAVI, this.ime, this.prezime, this.mejl, this.telefon,
                                                                                 this.sifra, this.ulica, this.brojKuce, this.grad);
        }

        public string VratiVrednostiZaUbacivanje(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaKlijent.TABELA_KLIJENT_UBACI, this.id, this.jmbg, this.ime, this.prezime, this.mejl,
                                 this.telefon, this.sifra, this.ulica, this.brojKuce, this.grad);
        }
        #endregion

        public override string ToString()
        {
            return JMBG + Konstante.Opste.ZAREZ + String.Join(" ", new string[] { Ime, Prezime });
        }
    }
}
 