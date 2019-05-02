using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerRacuni
    {
        public const String RACUNI_NE_POSTOJE = "Trenutno nemate otvorene račune u našem sistemu.";
           
        public void PrikaziSveRacune(MojiRacuniForma mojiRacuniForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.KLIJENT_PRIKAZI_RACUNE,
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if ( odgovor.Rezultat == 0)
                {
                    mojiRacuniForma.PrikaziInfoPoruku(RACUNI_NE_POSTOJE);
                }
                else
                {
                    mojiRacuniForma.PostaviSveRacune( ((List<IDomenskiObjekat>) odgovor.Objekat).ConvertAll(x => (Racun) x) );
                }
            }
            catch (Exception ex)
            {
                mojiRacuniForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public List<Racun> PrikaziRacuneSaKriterijumom(MojiRacuniForma mojiRacuniForma, string text)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.KLIJENT_PRIKAZI_RACUNE_KRITERIJUM,
                    Poruka = text
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    return null;
                }
                else
                {
                    return ((List<IDomenskiObjekat>)odgovor.Objekat).ConvertAll(x => (Racun)x);
                }
            }
            catch (Exception ex)
            {
                mojiRacuniForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
                return null;
            }
        }
    }
}
