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
        public const String RACUN = "racun";
        public const String UPLATE = "uplate";
        public const String ISPLATE = "isplate";
        public const String UPLATE_KREDITA = "uplate_kredita";
        public const String ISPLATE_KREDITA = "isplate_kredita";
        
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

                    switch (zahtev.Operacija)
                    {
                        case Operacija.ULOGUJ_KLIJENTA:
                            KeyValuePair<String, String> kredencijali = (KeyValuePair<String, String>)zahtev.Poruka;
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
                                ulogovani = klijent as Osoba;
                            }

                            break;
                        case Operacija.KLIJENT_PRIKAZI_RACUNE:
                            List<IDomenskiObjekat> racuni = KontrolerPL.DajKontroler().PronadjiKljentoveRacune(ulogovani as Klijent);

                            if (racuni == null || racuni.Count == 0)
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
                        case Operacija.KLIJENT_PRIKAZI_RACUNE_KRITERIJUM:
                            List<IDomenskiObjekat> racuniKriterijum = KontrolerPL.DajKontroler().PronadjiKlijenteIRacuneSaKritrijumom(ulogovani as Klijent, Convert.ToString(zahtev.Poruka));

                            if (racuniKriterijum == null || racuniKriterijum.Count == 0)
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
                                    Objekat = racuniKriterijum
                                };
                            }
                            break;
                        case Operacija.KLIJENT_PRIKAZI_KREDITE:
                            List<IDomenskiObjekat> krediti = KontrolerPL.DajKontroler().PronadjiKljentoveKredite(ulogovani as Klijent);

                            if (krediti == null || krediti.Count == 0)
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
                        case Operacija.KLIJENT_PRIKAZI_TRANSAKCIJE_ZA_RACUN:
                            Dictionary<String, String> uslovi = (Dictionary<String, String>)zahtev.Poruka;
                            List<IDomenskiObjekat> transakcije = KontrolerPL.DajKontroler()
                                                                .PronadjiKlijentoveTransakcijeZaRacun(ulogovani as Klijent, uslovi[RACUN], uslovi[UPLATE],
                                                                                                      uslovi[ISPLATE], uslovi[UPLATE_KREDITA], uslovi[ISPLATE_KREDITA]);

                            if (transakcije == null)
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
                                    Objekat = transakcije
                                };
                            }
                            break;
                        case Operacija.ADMIN_VRATI_ID:
                            String id = KontrolerPL.DajKontroler().VratiNoviID(zahtev.Poruka);

                            if (id == null)
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
                                    Objekat = id
                                };
                            }
                            break;
                        case Operacija.ADMIN_VRATI_ID_RACUNA:
                            String idRacuna = KontrolerPL.DajKontroler().VratiNoviIDRacunaZaKlijenta((Klijent) zahtev.Poruka);

                            if (idRacuna == null)
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
                                    Objekat = idRacuna
                                };
                            }
                            break;
                        case Operacija.ADMIN_VRATI_ID_KREDITA:
                            String idKredita = KontrolerPL.DajKontroler().VratiNoviIDKreditaZaKlijenta((Klijent)zahtev.Poruka);

                            if (idKredita == null)
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
                                    Objekat = idKredita
                                };
                            }
                            break;
                        case Operacija.ADMIN_SACUVAJ_KORISNIKA:
                            bool uspeh = KontrolerPL.DajKontroler().SacuvajNovogKorisnika((IDomenskiObjekat)zahtev.Poruka);

                            if (!uspeh)
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
                                    Rezultat = 1
                                };
                            }
                            break;
                        case Operacija.ADMIN_VRATI_KORISNIKE:
                            List<IDomenskiObjekat> korisnici = KontrolerPL.DajKontroler().PronadjiKlijenteIRacune();

                            if (korisnici == null || korisnici.Count == 0)
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
                                    Objekat = korisnici
                                };
                            }
                            break;
                        case Operacija.ADMIN_VRATI_TIPOVE_KREDITA:
                            List<IDomenskiObjekat> tipovi = KontrolerPL.DajKontroler().PronadjiTipoveKredita();

                            if (tipovi == null || tipovi.Count == 0)
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
                                    Objekat = tipovi
                                };
                            }
                            break;
                        case Operacija.ADMIN_OBRISI_KORISNIKA:
                            bool obrisan = KontrolerPL.DajKontroler().ObrisiKorisnika((Klijent) zahtev.Poruka);

                            if (!obrisan)
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
                                };
                            }
                            break;
                        case Operacija.ADMIN_IZMENI_KORISNIKA:
                            bool izmenjen = KontrolerPL.DajKontroler().IzmeniKorisnika((Klijent)zahtev.Poruka);

                            if (!izmenjen)
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
                                };
                            }
                            break;
                        case Operacija.ADMIN_SACUVAJ_RACUNE_KORISNIKA:
                            KeyValuePair<Klijent, List<Racun>> vrednosti = (KeyValuePair<Klijent, List<Racun>>)zahtev.Poruka;
                            bool sacuvano = KontrolerPL.DajKontroler().SacuvajRacuneKorisnika(vrednosti.Key, vrednosti.Value);

                            if (!sacuvano)
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
                                };
                            }
                            break;
                        case Operacija.ADMIN_SACUVAJ_KREDIT:
                            bool sacuvanKredit = KontrolerPL.DajKontroler().SacuvajKredit((IDomenskiObjekat)zahtev.Poruka);

                            if (!sacuvanKredit)
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
                                    Rezultat = 1
                                };
                            }
                            break;
                        case Operacija.ADMIN_VRATI_KORISNIKA:
                            IDomenskiObjekat posiljalac = KontrolerPL.DajKontroler().PronadjiKlijenta(Convert.ToString(zahtev.Poruka));

                            if (posiljalac == null)
                            {
                                odgovor = new ServerTransferObjekat()
                                {
                                    Rezultat = 0
                                };

                            }
                            else
                            {
                                List<IDomenskiObjekat> klijentoviRacuni = KontrolerPL.DajKontroler().PronadjiKljentoveRacune((Klijent)posiljalac);
                                ((Klijent)posiljalac).Racuni = klijentoviRacuni != null ? klijentoviRacuni.ConvertAll(x => (Racun)x) : null;
                                odgovor = new ServerTransferObjekat()
                                {
                                    Rezultat = 1,
                                    Objekat = posiljalac
                                };
                            }
                            break;
                        case Operacija.ADMIN_SACUVAJ_TRANSAKCIJU:
                            KeyValuePair<Transakcija, KeyValuePair<long, long>> vrednost = (KeyValuePair<Transakcija, KeyValuePair<long, long>>)zahtev.Poruka;
                            bool uspehTransakcija = KontrolerPL.DajKontroler().SacuvajTransakcije(vrednost.Key, Convert.ToString(vrednost.Value.Key), Convert.ToString(vrednost.Value.Value));

                            if (!uspehTransakcija)
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
                                };
                            }
                            break;
                        case Operacija.KRAJ:
                            KontrolerPL.DajKontroler().DiskonektujKlijenta(ulogovani);
                            kraj = true;
                            break;
                    }

                    if ( !kraj )
                    {
                        formater.Serialize(tok, odgovor);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klijent se diskonektovao!");
            }
        }
    }
}