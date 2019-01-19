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
        public const String RACUNI_NE_POSTOJE_KRIJERIJUM = "Računi za kriterijum <{0}> ne postoje!";

        private List<Racun> racuni;
           
        public void PrikaziSveRacune(MojiRacuniForma mojiRacuniForma, String kriterijum)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.KLIJENT_PRIKAZI_RACUNE,
                    Poruka = kriterijum
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                racuni = (List<Racun>) odgovor.Objekat;
                if ( odgovor.Rezultat == 0 )
                {
                    mojiRacuniForma.PrikaziInfoPoruku(RACUNI_NE_POSTOJE);
                }
                else if (racuni.Count < 0)
                {
                    mojiRacuniForma.PrikaziInfoPoruku(String.Format(RACUNI_NE_POSTOJE_KRIJERIJUM, kriterijum));
                }
                else
                {
                    mojiRacuniForma.OsveziTabeluRacuna(racuni);
                }
            }
            catch (Exception ex)
            {

            }
        }

        public List<Racun> Racuni
        {
            get { return racuni; }
            set { racuni = value; }
        }
    }
}
