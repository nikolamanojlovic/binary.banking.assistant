using Domen;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using static Domen.Operacije;

namespace ServerAplikacija
{
    public class ObradaKlijenta
    {
        private NetworkStream tok;
        private BinaryFormatter formater;
        private bool kraj;
        private Osoba ulogovani;

        public ObradaKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();
            PokreniKlijenta();
        }

        private void PokreniKlijenta()
        {
            kraj = false;
            ThreadStart ts = ObradaZahteva;
            Thread kljentovaNit = new Thread(ts);
            kljentovaNit.Start();
        }

        private void ObradaZahteva()
        {
            try
            {
                while (!kraj)
                {
                    KlijentTransferObjekat zahtev = formater.Deserialize(tok) as KlijentTransferObjekat;
                    ServerTransferObjekat odgovor = null;

                    switch(zahtev.Operacija)
                    {
                        case Operacija.ULOGUJ_KLIJENTA:
                            KeyValuePair<String, String> kredencijali = (KeyValuePair < String, String >) zahtev.Poruka;
                            IDomenskiObjekat klijent = KontrolerPL.DajKontroler().PronadjiKlijenta(kredencijali.Key, kredencijali.Value);

                            if (klijent == null)
                            {
                                odgovor = new ServerTransferObjekat()
                                {
                                    Rezultat = 0
                                };
                               
                            } else
                            {
                                odgovor = new ServerTransferObjekat()
                                {
                                    Rezultat = 1,
                                    Objekat = klijent
                                };
                                ulogovani = klijent as Klijent;
                            }

                            break;
                        case Operacija.KLIJENT_PRIKAZI_RACUNE:
                            List<IDomenskiObjekat> racuni = KontrolerPL.DajKontroler().PronadjiKljentoveRacune(zahtev.Poruka as Klijent);

                            if (racuni == null)
                            {
                                odgovor = new ServerTransferObjekat()
                                {
                                    Rezultat = 0
                                };

                            }
                            else
                            {
                                odgovor = new ServerTransferObjekat()
                                {
                                    Rezultat = 1,
                                    Objekat = racuni
                                };
                            }
                            break;
                        case Operacija.KLIJENT_PRIKAZI_KREDITE:
                            List<IDomenskiObjekat> krediti = KontrolerPL.DajKontroler().PronadjiKljentoveKredite(zahtev.Poruka as Klijent);

                            if (krediti == null)
                            {
                                odgovor = new ServerTransferObjekat()
                                {
                                    Rezultat = 0
                                };

                            }
                            else
                            {
                                odgovor = new ServerTransferObjekat()
                                {
                                    Rezultat = 1,
                                    Objekat = krediti
                                };
                            }
                            break;
                        case Operacija.KRAJ:
                            break;
                    }

                    formater.Serialize(tok, odgovor);
                }
            }
            catch (Exception ex)
            {
                KontrolerPL.DajKontroler().DiskonektujKlijenta(ulogovani);
                Console.Write(ex.StackTrace);
                Console.WriteLine("Klijent se diskonektovao!");
            }
        }
    }
}