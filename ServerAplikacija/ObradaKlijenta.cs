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
                    ServerTransferObjekat odgovor;

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
                            }
                            
                            formater.Serialize(tok, odgovor);
                            break;
                        case Operacija.KRAJ:
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.StackTrace);
                Console.WriteLine("Klijent se diskonektovao!");
            }
        }
    }
}