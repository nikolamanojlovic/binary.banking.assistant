using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerOtvoriRacun
    {
        public const String KORISNICI_NE_POSTOJE = "Trenutno u sistemu nema korisnika.";
        public const String ID_GRESKA = "Sistem nije u mogućnosti da vrati ID novog racuna.";
        public const String RACUNI_GRESKA = "Došlo je do greške, računi nisu sačuvani.";
        public const String RACUNI_USPEH = "Računi su uspešno sačuvani.";

        public void VratiSveKorisnike(OtvoriRacunForma otvoriRacunForma)
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
                    otvoriRacunForma.PrikaziInfoPoruku(KORISNICI_NE_POSTOJE);
                }
                else
                {
                    otvoriRacunForma.PopuniCBKorisnika(((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (Klijent)x));
                }
            }
            catch (Exception ex)
            {
                otvoriRacunForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public void VratiID(OtvoriRacunForma otvoriRacunForma, Klijent klijent)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_VRATI_ID_RACUNA,
                    Poruka = klijent
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    otvoriRacunForma.PrikaziGreskaPoruku(ID_GRESKA);
                }
                else
                {
                    otvoriRacunForma.PostaviID(Convert.ToString(odgovor.Objekat));
                }
            }
            catch (Exception ex)
            {
                otvoriRacunForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public void SacuvajRacune(OtvoriRacunForma otvoriRacunForma, Klijent klijent, List<Racun> racuni)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_SACUVAJ_RACUNE_KORISNIKA,
                    Poruka = new KeyValuePair<Klijent, List<Racun>>(klijent, racuni)
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    otvoriRacunForma.PrikaziGreskaPoruku(RACUNI_GRESKA);
                }
                else
                {
                    otvoriRacunForma.PrikaziInfoPoruku(RACUNI_USPEH);
                }
            }
            catch (Exception ex)
            {
                otvoriRacunForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
