using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Klijent : IDomenskiObjekat
    {
        private long id;
        private String jmbg;
        private String ime;
        private String prezime;
        private String mejl;
        private String telefon;
        private String ulica;
        private int brojKuce;
        private String grad;
        private List<Racun> racuni;

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

        public String Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public String Mejl
        {
            get { return mejl; }
            set { mejl = value; }
        }

        public String Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }

        public String Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public String JMBG
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

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