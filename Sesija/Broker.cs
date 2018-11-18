using System;
using System.Collections.Generic;
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

    }
}
