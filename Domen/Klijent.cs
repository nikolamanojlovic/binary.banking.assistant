using System;
using System.Collections.Generic;

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
        #endregion

        public string RetrivePK()
        {
            return this.id.ToString();
        }

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
            return String.Format(Konstante.TabelaKlijent.TABELA_KLIJENT_UBACI, this.id, this.jmbg, this.ime, this.prezime, this.mejl, this.telefon, this.ulica, this.brojKuce, this.grad);
        }
    }
}