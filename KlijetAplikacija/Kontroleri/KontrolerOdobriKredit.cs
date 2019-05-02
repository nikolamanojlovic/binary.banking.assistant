using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerOdobriKredit
    {
        public const String KORISNICI_NE_POSTOJE = "Trenutno u sistemu nema korisnika.";
        public const String KREDITI_NE_POSTOJE = "Trenutno u sistemu nema tipova kredita.";
        public const String ID_GRESKA = "Sistem nije u mogućnosti da vrati ID novog kredita.";
        public const String KREDIT_GRESKA = "Sistem nije u mogućnosti da odobri novi kredit.";
        public const String KREDIT_PODTVRA = "Sistem je odobrio novi kredit.";

        public void VratiSveKorisnike(OdobriKreditForma odobriKreditForma)
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
                    odobriKreditForma.PrikaziGreskaPoruku(KORISNICI_NE_POSTOJE);
                }
                else
                {
                    odobriKreditForma.PopuniCBKorisnika(((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (Klijent)x));
                }
            }
            catch (Exception ex)
            {
                odobriKreditForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public void VratiSveTipoveKredita(OdobriKreditForma odobriKreditForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_VRATI_TIPOVE_KREDITA,
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    odobriKreditForma.PrikaziGreskaPoruku(KREDITI_NE_POSTOJE);
                }
                else
                {
                    odobriKreditForma.PopuniCBTipovaKredita(((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (TipKredita)x));
                }
            }
            catch (Exception ex)
            {
                odobriKreditForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public void PostaviBrojKredita(OdobriKreditForma odobriKreditForma, Klijent klijent)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_VRATI_ID_KREDITA,
                    Poruka = klijent
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    odobriKreditForma.PrikaziGreskaPoruku(ID_GRESKA);
                }
                else
                {
                    odobriKreditForma.PostaviIDKredita(Convert.ToString(odgovor.Objekat));
                }
            }
            catch (Exception ex)
            {
                odobriKreditForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public void OdobriKredit(OdobriKreditForma odobriKreditForma, AktiviraniKredit ak)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_SACUVAJ_KREDIT,
                    Poruka = ak
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    odobriKreditForma.PrikaziGreskaPoruku(KREDIT_GRESKA);
                }
                else
                {
                    odobriKreditForma.PrikaziInfoPoruku(KREDIT_PODTVRA);
                }
            }
            catch (Exception ex)
            {
                odobriKreditForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
