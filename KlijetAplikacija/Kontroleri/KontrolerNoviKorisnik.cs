using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerNoviKorisnik
    {
        public const String ID_GRESKA = "Sistem nije u mogućnosti da vrati ID novog korisnika.";
        public const String KORISNIK_GRESKA = "Sistem nije u mogućnosti da sačuva novog korisnika.";
        public const String KORISNIK_USPEH = "Sistem je uspešno sačuvao novog korisnika.";

        public void VratiID(KreirajKorisnikaForma kreirajKorisnikaForm)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_VRATI_ID,
                    Poruka = new Klijent()
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    kreirajKorisnikaForm.PrikaziInfoPoruku(ID_GRESKA);
                }
                else
                {
                    kreirajKorisnikaForm.PostaviID(Convert.ToString(odgovor.Objekat));
                }
            }
            catch (Exception ex)
            {
                kreirajKorisnikaForm.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public void SacuvajKorisnika(KreirajKorisnikaForma kreirajKorisnikaForm, Klijent noviKorisnik)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_SACUVAJ_KORISNIKA,
                    Poruka = noviKorisnik
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    kreirajKorisnikaForm.PrikaziGreskaPoruku(KORISNIK_GRESKA);
                }
                else
                {
                    kreirajKorisnikaForm.PrikaziInfoPoruku(KORISNIK_USPEH);
                }
            }
            catch (Exception ex)
            {
                kreirajKorisnikaForm.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
