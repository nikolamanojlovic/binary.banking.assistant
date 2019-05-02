using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerTransakcije
    {
        public const String RACUNI_NE_POSTOJE = "Trenutno nemate otvorene račune u našem sistemu.";
        public const String TRANSAKCIJE_NE_POSTOJE = "Trenutno nemate transakcije u našem sistemu.";
        public const String TRANSAKCIJE_NE_POSTOJE_ZA_RACUN = "Trenutno nemate transakcije u našem sistemu za račun {0}.";

        public void VratiRacune(MojeTransakcijeForma mojeTransakcijeForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.KLIJENT_PRIKAZI_RACUNE
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    mojeTransakcijeForma.PrikaziInfoPoruku(RACUNI_NE_POSTOJE);
                    mojeTransakcijeForma.PopuniCBRacuna(null);
                }
                else
                {
                    mojeTransakcijeForma.PopuniCBRacuna( ((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (Racun)x) );
                }
            }
            catch (Exception ex)
            {
                mojeTransakcijeForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
                mojeTransakcijeForma.PopuniCBRacuna(null);
            }
        }

        public void PrikaziSveTransakcije(MojeTransakcijeForma mojeTransakcijeForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.KLIJENT_PRIKAZI_TRANSAKCIJE_ZA_RACUN,
                    Poruka = mojeTransakcijeForma.VratiUsloveZaTransakcije()
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    mojeTransakcijeForma.PrikaziInfoPoruku(String.Format(TRANSAKCIJE_NE_POSTOJE_ZA_RACUN, mojeTransakcijeForma.VratiIzabraniRacun().BrojRacuna));
                }
                else
                {
                    mojeTransakcijeForma.PostaviSveTransakcije( ((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (Transakcija)x) );
                }
            }
            catch (Exception ex)
            {
                mojeTransakcijeForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
