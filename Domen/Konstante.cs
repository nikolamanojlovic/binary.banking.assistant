using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public static class Konstante
    {
        public static class Opste
        {
            public static readonly string ZAREZ = ",";
        }

        public static class SQL
        {
            public static readonly string FORMAT_DATUMA = "yyyy-MM-dd HH:mm:ss.fff";
        }

        public static class TabelaRacun
        {
            public static readonly string NAZIV_TABELE = "account";
            public static readonly string PK_RACUN_ID = "account_id";
            public static readonly string TABELA_RACUN_UBACI = " '{0}', '{1}', '{2}', '{3}' ";
        }

        public static class TabelaKlijent
        {
            public static readonly string NAZIV_TABELE = "client";
            public static readonly string PK_KLIJENT_ID = "client_id";
            public static readonly string TABELA_KLIJENT_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}' ";
        }

        public static class TabelaTipKredita
        {
            public static readonly string NAZIV_TABELE = "loan_type";
            public static readonly string PK_TIP_RACUNA_ID = "loan_type_id";
            public static readonly string TABELA_TIP_KREDITA_UBACI
                = " '{0}', '{1}', '{2}', '{3}', '{4}' ";
        }
    }
}