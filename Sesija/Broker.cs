using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sesija
{
    public class Broker
    {
        public static Broker instanca;

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
            if ( instanca == null )
            {
                return new Broker();
            }
            return instanca;
        }

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
    }
}
