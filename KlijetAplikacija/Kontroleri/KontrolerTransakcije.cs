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
        public const String TRANSAKCIJE_NE_POSTOJE = "Trenutno nemate transakcije u našem sistemu.";

        public void PrikaziSveTransakcije(MojeTransakcijeForma mojeTransakcijeForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.KLIJENT_PRIKAZI_RACUNE,
                    Poruka = Komunikacija.DajKomunikaciju().VratiSesiju()
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    mojeTransakcijeForma.PrikaziInfoPoruku(TRANSAKCIJE_NE_POSTOJE);
                }
                else
                {
                    List<Racun> racuni = new List<Racun>();
                    ((List<IDomenskiObjekat>)odgovor.Objekat).ForEach(racun => racuni.Add((Racun)racun));
                    mojeTransakcijeForma.PostaviSveTransakcije(racuni);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                mojeTransakcijeForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
