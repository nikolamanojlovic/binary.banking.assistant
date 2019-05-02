using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerNapraviTransakciju
    {
        public const String KORISNIK_NE_POSTOJI = "Trenutno u sistemu nema korisnika {0}.";
        public const String KORISNICI_NE_POSTOJE = "Trenutno u sistemu nema korisnika.";
        public const String USPESNO = "Transakcija je uspešno sačuvana!";
        public const String NEUSPESNO = "Transakcija nije sačuvana!";

        public Klijent VratiPosiljaoca(NapraviTransakcijuForma napraviTransakcijuForma, string jmbg)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_VRATI_KORISNIKA,
                    Poruka = jmbg
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    napraviTransakcijuForma.PrikaziGreskaPoruku(String.Format(KORISNIK_NE_POSTOJI, jmbg));
                    return null;
                }
                else
                {
                    return odgovor.Objekat as Klijent;
                }
            }
            catch (Exception ex)
            {
                napraviTransakcijuForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
                return null;
            }
        }

        public List<Klijent> VratiPrimaoce(NapraviTransakcijuForma napraviTransakcijuForma)
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
                    napraviTransakcijuForma.PrikaziInfoPoruku(KORISNICI_NE_POSTOJE);
                    return null;
                }
                else
                {
                    return ((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (Klijent)x);
                }
            }
            catch (Exception ex)
            {
                napraviTransakcijuForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
                return null;
            }
        }

        public void SacuvajTransakciju(NapraviTransakcijuForma napraviTransakcijuForma, Transakcija transakcija, KeyValuePair<long, long> sifre)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ADMIN_SACUVAJ_TRANSAKCIJU,
                    Poruka = new KeyValuePair<Transakcija, KeyValuePair<long, long>>(transakcija, sifre)
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    napraviTransakcijuForma.PrikaziGreskaPoruku(NEUSPESNO);
                }
                else
                {
                    napraviTransakcijuForma.PrikaziInfoPoruku(USPESNO);
                }
            }
            catch (Exception ex)
            {
                napraviTransakcijuForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
