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
        public override bool ImaVezaniObjekat()
        {
            return true;
        }

        public override string VratiNazivPK()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID;
        }

        public override string VratiNazivTabele()
        {
            return Konstante.TabelaKlijent.NAZIV_TABELE;
        }

        public override string VratiNazivTabeleVezanogObjekta()
        {
            return Konstante.TabelaRacun.NAZIV_TABELE;
        }
        
        public override string VratiUslovZaNadjiSlog()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_MEJL + "='" + Mejl + "'";
        }

        public override string VratiUslovZaNadjiSlogove()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + ID + "'";
        }

        public override string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaKlijent.TABELA_KLIJENT_UBACI, this.id, this.jmbg, this.ime, this.prezime, this.mejl,
                                 this.telefon, this.sifra, this.ulica, this.brojKuce, this.grad);
        }

        public override string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + ID + "'";
        }

        public override bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
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

        public override bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            try
            {
                while (citac.Read())
                {
                    (objekat as Klijent).Racuni.Add(new Racun()
                    {
                        ID = citac.GetInt64(0),
                        BrojRacuna = citac.GetString(1),
                        Tip = (TipRacuna)Enum.Parse(typeof(TipRacuna), citac.GetString(2), true),
                        DatumKreiranja = DateTime.Parse(citac.GetString(3))
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public override void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            (objekat as Klijent).ID = 0;
        }

        public override void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            (objekat as Klijent).ID = Convert.ToInt64(citac[Konstante.TabelaKlijent.PK_KLIJENT_ID]) + 1;
        }

        public override List<IDomenskiObjekat> VratiVezaniObjekat()
        {
            return new List<IDomenskiObjekat>(this.racuni);
        }

        #region Neimplementirane
        public override string VratiUslovZaJoin()
        {
            throw new NotImplementedException();
        }

        public override string PostaviVrednostAtributa()
        {
            throw new NotImplementedException();
        }
        #endregion

        #endregion
    }
}
 