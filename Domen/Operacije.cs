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
            KLIJENT_PRIKAZI_KREDITE,
            KLIJENT_PRIKAZI_TRANSAKCIJE_ZA_RACUN,
            ULOGUJ_KLIJENTA
        }
    }
}
