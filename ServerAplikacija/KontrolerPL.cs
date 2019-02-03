using Domen;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using static ServerAplikacija.ServerForma;

namespace ServerAplikacija
{
    public class KontrolerPL
    {
        private const String PRIJAVA = "Pokušaj prijave klijenta {0}.";
        private const String USPESNA_PRIJAVA = "Klijent {0} je uspešno prijavljen.";
        private const String NEUSPESNA_PRIJAVA = "Klijent {0} je neuspešno prijavljen.";

        public static KontrolerPL kontroler;

        private ServerForma forma;
        private List<Osoba> ulogovani;

        #region Singlton, Get, Set
        private KontrolerPL()
        {
            ulogovani = new List<Osoba>();
        }

        public static KontrolerPL DajKontroler()
        {
            if (kontroler == null)
            {
                kontroler = new KontrolerPL();
            }
            return kontroler;
        }
        
        public ServerForma Forma
        {
            get { return forma; }
            set { forma = value; }
        }

        public List<Osoba> Ulogovani
        {
            get { return ulogovani; }
            set { ulogovani = value; }
        }
        #endregion

        public IDomenskiObjekat PronadjiKlijenta(string mejl, string sifra)
        {
            OsveziLog(String.Format(PRIJAVA, mejl));
            VratiKlijentaSO klijentSO = new VratiKlijentaSO();
            klijentSO.IzvrsiSO(new Klijent() { Mejl = mejl });

            if (klijentSO.Rezultat != null)
            {
                Klijent klijent = klijentSO.Rezultat as Klijent;
      
                if ( sifra.Equals(klijent.Sifra) )
                {
                    OsveziLog(String.Format(USPESNA_PRIJAVA, mejl));
                    Ulogovani.Add(klijent);
                    OsveziUlogovane();
                    return klijent as IDomenskiObjekat;
                }
            } else
            {
                VratiAdminaSO adminSO = new VratiAdminaSO();
                adminSO.IzvrsiSO(new Admin() { Mejl = mejl });

                if (adminSO.Rezultat != null)
                {
                    Admin admin = adminSO.Rezultat as Admin;

                    if ( sifra.Equals(admin.Sifra) )
                    {
                        OsveziLog(String.Format(USPESNA_PRIJAVA, mejl));
                        Ulogovani.Add(admin);
                        OsveziUlogovane();
                        return admin as IDomenskiObjekat;
                    }
                }
            }
            OsveziLog(String.Format(NEUSPESNA_PRIJAVA, mejl));
            return null;
        }

        public List<IDomenskiObjekat> PronadjiKljentoveRacune(Klijent klijent)
        {
            VratiRacuneSO vratiRacuneSo = new VratiRacuneSO();
            vratiRacuneSo.IzvrsiSO(klijent);
            return (List<IDomenskiObjekat>) vratiRacuneSo.Rezultat;
        }

        public List<IDomenskiObjekat> PronadjiKljentoveKredite(Klijent klijent)
        {
            VratiKrediteSO vratiKrediteSO = new VratiKrediteSO();
            vratiKrediteSO.IzvrsiSO(klijent);
            return (List<IDomenskiObjekat>) vratiKrediteSO.Rezultat;
        }

        public void OsveziLog(string poruka)
        {
            Forma.Invoke(new OsveziLogCallback(Forma.OsveziLog), poruka);
        }

        public void OsveziUlogovane()
        {
            Forma.Invoke(new OsveziUlogovaneCallback(Forma.OsveziUlogovane), ulogovani);
        }

        public void DiskonektujKlijenta(Osoba ulogovan)
        {
            ulogovani.RemoveAll(x => x.Mejl.Equals(ulogovan.Mejl));
            OsveziUlogovane();
        }
    }
}
