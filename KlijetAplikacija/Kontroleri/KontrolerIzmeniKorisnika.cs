using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerIzmeniKorisnika
    {
        public const String KORISNICI_NE_POSTOJE = "Trenutno u sistemu nema korisnika.";
        public const String NIJE_MOGUCE_IZMENITI_KORISNIKA = "Nije moguće izmeniti korisnika.";
        public const String KORISNIK_USPESNO_IZMENJEN = "Korisnik je uspešno izmenjen.";

        public void VratiSveKorisnike(IzmeniInformacijeForma izmeniInformacijeForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_VRATI_KORISNIKE
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    izmeniInformacijeForma.PrikaziInfoPoruku(KORISNICI_NE_POSTOJE);
                }
                else
                {
                    izmeniInformacijeForma.PopuniCBKorisnika(((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (Klijent)x));
                }
            }
            catch (Exception ex)
            {
                izmeniInformacijeForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public void IzmeniKorisnika(IzmeniInformacijeForma izmeniInformacijeForma, Klijent klijent)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_IZMENI_KORISNIKA,
                    Poruka = klijent
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    izmeniInformacijeForma.PrikaziGreskaPoruku(NIJE_MOGUCE_IZMENITI_KORISNIKA);
                }
                else
                {
                    izmeniInformacijeForma.PrikaziInfoPoruku(KORISNIK_USPESNO_IZMENJEN);
                }
            }
            catch (Exception ex)
            {
                izmeniInformacijeForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
