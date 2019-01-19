using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerPrijava
    {
        private const String NEODGOVARAJUCI_KREDENCIJALI = "Kredencijali nisu odgovarajući, pokušajte ponovo!";

        public void PrijaviKlijenta(String mejl, String sifra, GlavnaFormaKlijent glavnaFormaKlijent, Prijava prijavaForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ULOGUJ_KLIJENTA,
                    Poruka = new KeyValuePair<String, String>(mejl, sifra)
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    prijavaForma.PrikaziGreskaPoruku(NEODGOVARAJUCI_KREDENCIJALI);
                    return;
                }
                else if (odgovor.Objekat is Admin)
                {

                }
                else if (odgovor.Objekat is Klijent)
                {
                    glavnaFormaKlijent.Klijent = odgovor.Objekat as Klijent;
                    glavnaFormaKlijent.Show();
                }
                prijavaForma.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
