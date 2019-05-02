using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Admin : Osoba, IDomenskiObjekat
    {
        private string pozicija;

        #region Get, Set
        public string Pozicija
        {
            get { return pozicija; }
            set { pozicija = value; }
        }
        #endregion

        #region Metode
        public string PostaviVrednostAtributa(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaAdmin.TABELA_ADMIN_POSTAVI, this.jmbg, this.ime, this.prezime, this.mejl,
                                                                             this.telefon, this.sifra, this.pozicija);
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
                Admin admin = new Admin
                {
                    ID = Convert.ToInt64(citac["admin_id"]),
                    JMBG = Convert.ToString(citac["jmbg"]),
                    Ime = Convert.ToString(citac["ime"]),
                    Prezime = Convert.ToString(citac["prezime"]),
                    Mejl = Convert.ToString(citac["mejl"]),
                    Telefon = Convert.ToString(citac["telefon"]),
                    Sifra = Convert.ToString(citac["sifra"]),
                    Pozicija = Convert.ToString(citac["pozicija"])
                };
                lista.Add(admin);
            }

            return lista;
        }

        public string VratiNazivPK()
        {
            return Konstante.TabelaAdmin.PK_ADMIN_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaAdmin.NAZIV_TABELE;
        }

        public string VratiPK()
        {
            return Convert.ToString(this.id);
        }

        public string VratiPKIUslov(string sifraJakog = "")
        {
            return String.Format("{0} = '{1}'", Konstante.TabelaAdmin.PK_ADMIN_ID, Convert.ToString(this.id));
        }

        public string VratiUslovZaNadjiSlog()
        {
            return this.mejl;
        }

        public string VratiVrednostiZaJoin(String sifraJakog = "")
        {
            return String.Empty;
        }

        public string VratiVrednostiZaUbacivanje(string sifraJakog = "")
        {
            return String.Format(Konstante.TabelaAdmin.TABELA_ADMIN_UBACI, this.id, this.jmbg, this.ime, this.prezime, this.mejl,
                                                                           this.telefon, this.sifra, this.pozicija);
        }
        #endregion
    }
}
