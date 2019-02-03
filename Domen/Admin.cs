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
        public string VratiPK()
        {
            return String.Format(" {0}, ", this.id);
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
                        ID = Convert.ToInt64(citac["admin_id"] as String),
                        JMBG = citac["jmbg"] as String,
                        Ime = citac["ime"] as String,
                        Prezime = citac["prezime"] as String,
                        Mejl = citac["mejl"] as String,
                        Telefon = citac["telefon"] as String,
                        Sifra = citac["sifra"] as String,
                        Pozicija = citac["pozicija"] as String
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

        public string VratiUslovZaNadjiSlogove()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
