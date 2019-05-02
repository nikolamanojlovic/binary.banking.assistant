namespace Domen
{
    public static class Konstante
    {
        public static class Opste
        {
            public static readonly string ZAREZ = ", ";
            public static readonly string TACKA = ".";
            public static readonly string CRNA_TACKA = "\u2022";
            public static readonly string NULA = "0";
        }

        public static class SQL
        {
            public static readonly string FORMAT_DATUMA = "yyyy-MM-dd HH:mm:ss";
            public static readonly string INSERT_INTO = " INSERT INTO ";
            public static readonly string VALUES = " VALUES ( {0} ) ";
            public static readonly string DELETE_FROM = " DELETE FROM {0} ";
            public static readonly string ALL = "*";
            public static readonly string WHERE = " WHERE {0} ";
            public static readonly string UPDATE = " UPDATE ";
            public static readonly string SET = " SET {0} ";
            public static readonly string SELECT_FROM = " SELECT {0} FROM ";
            public static readonly string MAX = " MAX({0}) AS max ";
            public static readonly string AND = " AND ";
            public static readonly string JOIN = " JOIN {0} ON {1}";
            public static readonly string OR = " {0} OR {1} ";
            public static readonly string OR_BEZ_UBACIVANJA = " OR ";
            public static readonly string AS = " AS ";
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
            public static readonly string DOBRODOSLI = "BBA - {0} {1}";
        }

        public static class Server
        {
            public static readonly string LOCALHOST = "127.0.0.1";
            public static readonly string SERVER_NIJE_DOSTUPAN = "Server nije dostupan, pokušajte kasnije!";
        }

        public static class TabelaRacun
        {
            public static readonly string NAZIV_TABELE = "racun";
            public static readonly string PRIMALAC = "primalac_klijent_id";
            public static readonly string POSILJALAC = "posiljalac_klijent_id";
            public static readonly string PK_RACUN_ID = "racun_id";
            public static readonly string POLJE_BROJ = "broj_racuna";
            public static readonly string TABELA_RACUN_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}' ";
            public static readonly string TABELA_RACUN_POSTAVI = " broj_racuna='{0}', tip='{1}', datum_kreiranja='{2}' ";
        }

        public static class TabelaKlijent
        {
            public static readonly string NAZIV_TABELE = "klijent";
            public static readonly string PK_KLIJENT_ID = "klijent_id";
            public static readonly string POLJE_MEJL = "mejl";
            public static readonly string POLJE_SIFRA = "sifra";
            public static readonly string TABELA_KLIJENT_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}'";
            public static readonly string TABELA_KLIJENT_POSTAVI = " ime='{0}', prezime='{1}', mejl='{2}', telefon='{3}', sifra='{4}', ulica='{5}', broj_kuce='{6}', grad='{7}' ";
        }

        public static class TabelaAdmin
        {
            public static readonly string NAZIV_TABELE = "admin";
            public static readonly string PK_ADMIN_ID = "admin_id";
            public static readonly string POLJE_SIFRA = "sifra";
            public static readonly string POLJE_EMAIL = "mejl";
            public static readonly string TABELA_ADMIN_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}' ";
            public static readonly string TABELA_ADMIN_POSTAVI = " jmbg='{0}', ime='{1}', prezime='{2}', mejl='{3}', telefon='{4}', sifra='{5}', pozicija='{6}' ";
        }

        public static class TabelaTipKredita
        {
            public static readonly string NAZIV_TABELE = "tip_kredita";
            public static readonly string PK_TIP_KREDITA_ID = "tip_kredita_id";
            public static readonly string POLJE_NAZIV = "naziv";
            public static readonly string TABELA_TIP_KREDITA_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}' ";
            public static readonly string TABELA_TIP_KREDITA_POSTAVI = " naziv='{0}', min_dug='{1}', maks_dug='{2}', vremenski_okvir='{3}' ";
        }

        public static class TabelaRata
        {
            public static readonly string NAZIV_TABELE = "rata";
            public static readonly string PK_RATA_ID = " redni_broj ";
            public static readonly string POLJE_BROJ = "redni_broj";
            public static readonly string TABELA_RATA_UBACI = " '{0}', '{1}', '{2}', '{3} ";
            public static readonly string TABELA_RATA_POSTAVI = "  datum_naplate='{0}', {1} ";
        }

        public static class TabelaTransakcija
        {
            public static readonly string NAZIV_TABELE = " transakcija ";
            public static readonly string PK_TRANSAKCIJA_ID = " vremenska_oznaka ";
            public static readonly string POLJE_POSILJALAC = "posiljalac_klijent_id";
            public static readonly string POLJE_PRIMALAC = "primalac_klijent_id";
            public static readonly string POLJE_POSILJALAC_RACUN = "posiljalac_racun_id";
            public static readonly string POLJE_PRIMALAC_RACUN = "primalac_racun_id";
            public static readonly string TABELA_TRASAKCIJA_UBACI = " '{0}', {1}, '{2}' ";
            public static readonly string TABELA_TRASAKCIJA_POSTAVI = " iznos='{1}' ";
        }

        public static class TabelaAktiviraniKredit
        {
            public static readonly string NAZIV_TABELE = "aktivni_kredit";
            public static readonly string PK_AK_ID = " broj_kredita ";
            public static readonly string TABELA_AK_UBACI = " '{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}' ";
            public static readonly string TABELA_KLIJENT_POSTAVI = " datum_uzimanja='{0}', rok_dospeca='{1}', datum_isplate='{2}', kamata='{3}', broj_rata='{4}'";
        }
    }
}