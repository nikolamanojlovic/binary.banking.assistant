using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
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

        public override bool ImaVezaniObjekat()
        {
            throw new NotImplementedException();
        }

        public override bool Napuni(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public override bool NapuniVezaneObjekte(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public override void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public override string PostaviVrednostAtributa()
        {
            throw new NotImplementedException();
        }

        public override void PovecajBroj(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Metode
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
            return Konstante.TabelaKlijent.PK_KLIJENT_ID + "='" + ID + "'";
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

        public override List<IDomenskiObjekat> VratiVezaniObjekat()
        {
            return new List<IDomenskiObjekat>(this.racuni);
        }

        public override string VratiAtributPretrazivanja()
        {
            return Konstante.TabelaKlijent.PK_KLIJENT_MEJL + "='" + Mejl + "'" + Konstante.SQL.AND + Konstante.TabelaAdmin.POLJE_SIFRA + "='" + Sifra + "'";
        }

        #region Neimplementirane
        #endregion

        #endregion
    }
}