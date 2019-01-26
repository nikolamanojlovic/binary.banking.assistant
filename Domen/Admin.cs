using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class Admin : Osoba
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
        public override bool ImaVezaniObjekat()
        {
            return false;
        }

        public override bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
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

        public override string VratiNazivPK()
        {
            return Konstante.TabelaAdmin.PK_ADMIN_ID;
        }

        public override string VratiNazivTabele()
        {
            return Konstante.TabelaAdmin.NAZIV_TABELE;
        }

        public override string VratiUslovZaNadjiSlog()
        {
            return Konstante.TabelaAdmin.POLJE_EMAIL + "='" + Mejl + "'";
        }

        public override string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaKlijent.TABELA_KLIJENT_UBACI, this.id, this.jmbg, this.ime, this.prezime, this.mejl,
                   this.telefon, this.sifra, this.pozicija);
        }

        public override string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaAdmin.PK_ADMIN_ID;
        }

        public override void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as Admin).ID = 0;
        }

        public override void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as Admin).ID = Convert.ToInt64(citac[Konstante.TabelaAdmin.PK_ADMIN_ID]) + 1;
        }

        #region Neimplementirane
        public override bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekti)
        {
            throw new NotImplementedException();
        }

        public override string PostaviVrednostAtributa()
        {
            throw new NotImplementedException();
        }

        public override string VratiNazivTabeleVezanogObjekta()
        {
            throw new NotImplementedException();
        }

        public override string VratiUslovZaNadjiSlogove()
        {
            throw new NotImplementedException();
        }

        public override List<IDomenskiObjekat> VratiVezaniObjekat()
        {
            throw new NotImplementedException();
        }

        public override string VratiUslovZaJoin()
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
