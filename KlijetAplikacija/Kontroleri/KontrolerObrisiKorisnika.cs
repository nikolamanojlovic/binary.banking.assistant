using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerObrisiKorisnika
    {
        public const String KORISNICI_NE_POSTOJE = "Trenutno u sistemu nema korisnika.";
        public const String NIJE_MOGUCE_OBRISATI_KORISNIKA = "Nije moguće obrisati korisnika.";
        public const String USPESNO_OBRISAN_KORISNIK = "Korisnik {0} je uspešno obrisan.";

        public void VratiSveKorisnike(ObrisiKorisnikaForma obrisiKorisnikaForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_VRATI_KORISNIKE,
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    obrisiKorisnikaForma.PrikaziInfoPoruku(KORISNICI_NE_POSTOJE);
                }
                else
                {
                    obrisiKorisnikaForma.PopuniCBKorisnika(((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (Klijent)x));
                }
            }
            catch (Exception ex)
            {
                obrisiKorisnikaForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public void ObrisiKorisnika(ObrisiKorisnikaForma obrisiKorisnikaForma, Klijent klijent)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_OBRISI_KORISNIKA,
                    Poruka = klijent
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    obrisiKorisnikaForma.PrikaziGreskaPoruku(NIJE_MOGUCE_OBRISATI_KORISNIKA);
                }
                else
                {
                    obrisiKorisnikaForma.PrikaziInfoPoruku(String.Format(USPESNO_OBRISAN_KORISNIK, klijent.Ime + " " + klijent.Prezime));
                }
            }
            catch (Exception ex)
            {
                obrisiKorisnikaForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
