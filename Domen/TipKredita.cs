using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    public class TipKredita : IDomenskiObjekat
    {
        private long id;
        private String naziv;
        private double minDug;
        private double maxDug;
        private VremenskiOkvir vremenskiOkvir;

        #region Get, Set
        public VremenskiOkvir VremenskiOkvir
        {
            get { return vremenskiOkvir; }
            set { vremenskiOkvir = value; }
        }

        public double MaxDug
        {
            get { return maxDug; }
            set { maxDug = value; }
        }

        public double MinDug
        {
            get { return minDug; }
            set { minDug = value; }
        }

        public long ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Naziv
        {
            get { return naziv; }
            set { naziv = value; }
        }

        public bool ImaVezaniObjekat()
        {
            throw new NotImplementedException();
        }

        public bool Napuni(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public bool NapuniVezaneObjekte(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public void PostaviPocetniBroj(ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public string PostaviVrednostAtributa()
        {
            throw new NotImplementedException();
        }

        public void PovecajBroj(SqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public string VratiAtributPretrazivanja()
        {
            throw new NotImplementedException();
        }
        #endregion

        public string VratiNazivPK()
        {
            return Konstante.TabelaTipKredita.PK_TIP_RACUNA_ID;
        }

        public string VratiNazivTabele()
        {
            throw new NotImplementedException();
        }

        public string VratiNazivTabeleVezanogObjekta()
        {
            return Konstante.TabelaRacun.NAZIV_TABELE;
        }

        public string VratiUslovZaNadjiSlog()
        {
            throw new NotImplementedException();
        }

        public string VratiUslovZaNadjiSlogove()
        {
            throw new NotImplementedException();
        }

        public List<IDomenskiObjekat> VratiVezaniObjekat()
        {
            throw new NotImplementedException();
        }

        public string VratiVrednostiZaUbacivanje()
        {
            return String.Format(Konstante.TabelaRacun.TABELA_RACUN_UBACI, this.id, this.naziv, this.minDug, this.maxDug, this.vremenskiOkvir);
        }
    }

    public enum VremenskiOkvir
    {
        ShortTerm,
        MediumTerm,
        LongTerm
    }
}
