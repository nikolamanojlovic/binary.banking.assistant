﻿using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerKrediti
    {
        public const String KREDITI_NE_POSTOJE = "Trenutno nemate kredite u našem sistemu.";

        public void PrikaziSveRacune(MojiKreditiForma mojiKreditiForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.KLIJENT_PRIKAZI_KREDITE,
                    Poruka = Komunikacija.DajKomunikaciju().VratiSesiju()
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    mojiKreditiForma.PrikaziInfoPoruku(KREDITI_NE_POSTOJE);
                }
                else
                {
                    List<AktiviraniKredit> krediti = new List<AktiviraniKredit>();
                    ((List<IDomenskiObjekat>)odgovor.Objekat).ForEach(kredit => krediti.Add((AktiviraniKredit)kredit));
                    mojiKreditiForma.PostaviSveKredite(krediti);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                mojiKreditiForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
