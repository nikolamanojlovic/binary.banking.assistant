using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    public class Operacije
    {
        public enum Operacija
        {
            KRAJ,
            KLIJENT_PRIKAZI_RACUNE,
            KLIJENT_PRIKAZI_RACUNE_KRITERIJUM,
            KLIJENT_PRIKAZI_KREDITE,
            KLIJENT_PRIKAZI_TRANSAKCIJE_ZA_RACUN,
            ULOGUJ_KLIJENTA,
            ADMIN_VRATI_ID,
            ADMIN_VRATI_ID_RACUNA,
            ADMIN_VRATI_ID_KREDITA,
            ADMIN_VRATI_TIPOVE_KREDITA,
            ADMIN_VRATI_KORISNIKE,
            ADMIN_SACUVAJ_KORISNIKA,
            ADMIN_OBRISI_KORISNIKA,
            ADMIN_IZMENI_KORISNIKA,
            ADMIN_SACUVAJ_RACUNE_KORISNIKA,
            ADMIN_SACUVAJ_KREDIT,
            ADMIN_VRATI_KORISNIKA,
            ADMIN_SACUVAJ_TRANSAKCIJU
        }
    }
}
