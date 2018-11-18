using System.Data;
using System.Data.SqlClient;

namespace Sesija
{
    public class Broker
    {
        public static Broker Instanca;

        public SqlConnection Konekcija;
        public SqlCommand Komanda;
        public SqlDataReader Citac;
        public SqlTransaction Transakcija;

        public Broker ()
        {
            Konekcija = new SqlConnection(@"server=localhost;user id=root;database=bba_bp");
            Komanda = new SqlCommand
            {
                Connection = Konekcija
            };
        }

        public static Broker DajInstancu()
        {
            if (Instanca == null)
            {
                return new Broker();
            }
            return Instanca;
        }

        #region Konekcija i Transakcija
        public void OtvoriKonekciju()
        {
            Konekcija.Open();
        }

        public void ZatvoriKonekciju()
        {
            if (Konekcija != null && Konekcija.State == ConnectionState.Open)
            {
                Konekcija.Close();
            }
        }

        public void ZapocniTransakciju()
        {
            Transakcija = Konekcija.BeginTransaction();
        }

        public void PotvrdiTransakciju()
        {
            Transakcija.Commit();
        }

        public void PonistiTransakciju()
        {
            Transakcija.Rollback();
        }
        #endregion

        #region Operacije nad bazom

        #endregion
    }
}
