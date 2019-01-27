﻿using Domen;
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
           
        public void PrikaziSveRacune(MojiRacuniForma mojiRacuniForma)
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

                racuni = (List<Racun>) odgovor.Objekat;
                if ( racuni == null || racuni.Count == 0 )
                {
                    mojiRacuniForma.PrikaziInfoPoruku(RACUNI_NE_POSTOJE);
                }
                else
                {
                    mojiRacuniForma.OsveziTabeluRacuna(racuni);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                mojiRacuniForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }

        public List<Racun> Racuni
        {
            get { return racuni; }
            set { racuni = value; }
        }
    }
}
