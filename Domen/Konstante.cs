namespace Domen
{
    public static class Konstante
    {
        public static class Opste
        {
            public static readonly string ZAREZ = ",";
            public static readonly string CRNA_TACKA = "\u2022";
        }

        public static class SQL
        {
            public static readonly string FORMAT_DATUMA = "yyyy-MM-dd HH:mm:ss.fff";
            public static readonly string INSERT_INTO = " INSERT INTO ";
            public static readonly string VALUES = " ( {0} ) ";
            public static readonly string DELETE_FROM = " DELETE {0} FROM ";
            public static readonly string ALL = "*";
            public static readonly string WHERE = " WHERE {0} ";
            public static readonly string UPDATE = " UPDATE ";
            public static readonly string SET = " SET {0} ";
            public static readonly string SELECT_FROM = " SELECT {0} FROM ";
            public static readonly string MAX = " MAX({0}) AS max ";
            public static readonly string AND = " AND ";
        }

        public static class DB
        {
            public static readonly string SLOG_NE_POSTOJI = "Slog ne postoji u bazi.";
            public static readonly string SLOG_POSTOJI = "Slog postoji u bazi.";
            public static readonly string NAUSPESNO_PRETRAZIVANJE = "Neuspesno pretrazivanje baze.";
            public static readonly string VEZANI_SLOG_USPESNO_PROCITAN = "Vezani slog je uspešno pročitan iz bazi.";
            public static readonly string VEZANI_SLOG_NEUSPESNO_PROCITAN = "Vezani slog je neuspešno pročitan iz baze.";
            public static readonly string SLOZENI_SLOG_USPENO_ZAPAMCEN = "Složeni slog uspešno zapamćen.";
            public static readonly string SLOZENI_SLOG_NEUSPENO_ZAPAMCEN = "Složeni slog neuspešno zapamćen.";
        }

        public static class GUI
        {
            public static readonly string NOVI_RED = "\r\n";
            public static readonly string GRESKA_NASLOV = "BBA - Binary Banking Assistant (GRESKA)";
            public static readonly string INFO_NASLOV = "BBA - Binary Banking Assistant (INFO)";
            public static readonly string GRESKA_TEKST = "Došlo je do greške. {0} ";
            public static readonly string INFO_TEKS = "{0}";
        }

        public static class Server
        {
            public static readonly string LOCALHOST = "127.0.0.1";
            public static readonly string SERVER_NIJE_DOSTUPAN = "Server nije dostupan, pokušajte kasnije!";
        }

        public static class TabelaRacun
        {
            public static readonly string NAZIV_TABELE = "racun";
            public static readonly string PK_RACUN_ID = "racun_id";
            public static readonly string TABELA_RACUN_UBACI = " '{0}', '{1}', '{2}', '{3}' ";
        }

        public static class TabelaKlijent
        {
            public static readonly string NAZIV_TABELE = "klijent";
            public static readonly string PK_KLIJENT_ID = "klijent_id";
            public static readonly string PK_KLIJENT_MEJL = "mejl";
            public static readonly string TABELA_KLIJENT_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}'";
        }

        public static class TabelaAdmin
        {
            public static readonly string NAZIV_TABELE = "admin";
            public static readonly string PK_ADMIN_ID = "admin_id";
            public static readonly string POLJE_SIFRA = "sifra";
            public static readonly string POLJE_EMAIL = "mejl";
            public static readonly string TABELA_ADMIN_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}' ";
        }

        public static class TabelaTipKredita
        {
            public static readonly string NAZIV_TABELE = "tip_kredita";
            public static readonly string PK_TIP_KREDITA_ID = "tip_kredita_id";
            public static readonly string TABELA_TIP_KREDITA_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}' ";
        }

        public static class TabelaRata
        {
            public static readonly string NAZIV_TABELE = "rata";
            public static readonly string PK_RATA_ID = "rata_rb";
            public static readonly string TABELA_RATA_UBACI = " '{0}', '{1}', '{2}', '{3}' ";
        }

        public static class TabelaAktiviraniKredit
        {
            public static readonly string NAZIV_TABELE = "aktivirani_kredit";
            public static readonly string PK_AK_ID = "broj_kredita";
            public static readonly string TABELA_AK_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}' ";
        }
    }
}