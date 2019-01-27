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
        public string VratiNazivPK()
        {
            return Konstante.TabelaAdmin.PK_ADMIN_ID;
        }

        public string VratiNazivTabele()
        {
            return Konstante.TabelaAdmin.NAZIV_TABELE;
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaAdmin.TABELA_ADMIN_UBACI, this.id, this.jmbg, this.ime, this.prezime, this.mejl,
                   this.telefon, this.sifra, this.pozicija);
        }

        public string VratiUslovZaNadjiSlog()
        {
            return Konstante.TabelaAdmin.POLJE_EMAIL + "='" + Mejl + "'";
        }

        public string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaAdmin.PK_ADMIN_ID;
        }

        public string PostaviVrednostAtributa()
        {
            return String.Format(Konstante.TabelaAdmin.TABELA_ADMIN_POSTAVI, this.id, this.jmbg, this.ime, this.prezime, this.mejl,
                                 this.telefon, this.sifra, this.pozicija);
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as Admin).ID = 0;
        }

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as Admin).ID = Convert.ToInt64(citac[Konstante.TabelaAdmin.PK_ADMIN_ID]) + 1;
        }

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                if (citac.Read())
                {
                    objekat = new Admin()
                    {
                        ID = citac.GetInt64(0),
                        JMBG = citac.GetString(1),
                        Ime = citac.GetString(2),
                        Prezime = citac.GetString(3),
                        Mejl = citac.GetString(4),
                        Telefon = citac.GetString(5),
                        Sifra = citac.GetString(6),
                        Pozicija = citac.GetString(7)
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
            return false;
        }
        #endregion
    }
}
