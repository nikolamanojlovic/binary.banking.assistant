using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Domen
{
    [Serializable]
    public class TipKredita : IDomenskiObjekat
    {
        private long id;
        private String naziv;
        private double minDug;
        private double maksDug;
        private VremenskiOkvir vremenskiOkvir;

        #region Get, Set
        public VremenskiOkvir VremenskiOkvir
        {
            get { return vremenskiOkvir; }
            set { vremenskiOkvir = value; }
        }

        public double MaksDug
        {
            get { return maksDug; }
            set { maksDug = value; }
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

        public bool Napuni(MySqlDataReader citac, ref IDomenskiObjekat objekat)
        {
            throw new NotImplementedException();
        }

        public bool NapuniVezaneObjekte(MySqlDataReader citac, ref IDomenskiObjekat objekat)
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

        public void PovecajBroj(MySqlDataReader citac, ref IDomenskiObjekat objekat)
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
            return Konstante.TabelaTipKredita.PK_TIP_KREDITA_ID;
        }

        public string VratiNazivTabele()
        {
            throw new NotImplementedException();
        }

        public string VratiNazivTabeleVezanogObjekta()
        {
            return Konstante.TabelaRacun.NAZIV_TABELE;
        }

        public string VratiUslovZaJoin()
        {
            throw new NotImplementedException();
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
            return String.Format(Konstante.TabelaRacun.TABELA_RACUN_UBACI, this.id, this.naziv, this.minDug, this.maksDug, this.vremenskiOkvir);
        }
    }

    public enum VremenskiOkvir
    {
        ShortTerm,
        MediumTerm,
        LongTerm
    }
}
