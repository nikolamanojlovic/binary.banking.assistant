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

                if ( odgovor.Rezultat == 0)
                {
                    mojiRacuniForma.PrikaziInfoPoruku(RACUNI_NE_POSTOJE);
                }
                else
                {
                    List<Racun> racuni = new List<Racun>();
                    ((List<IDomenskiObjekat>) odgovor.Objekat).ForEach(racun => racuni.Add((Racun)racun));
                    mojiRacuniForma.PostaviSveRacune(racuni);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                mojiRacuniForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
