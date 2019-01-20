using Domen;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        private List<Osoba> ulgovani;

        #region Singlton, Get, Set
        private KontrolerPL()
        {

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
            get { return ulgovani; }
            set { ulgovani = value; }
        }
        #endregion

        public IDomenskiObjekat PronadjiKlijenta(string mejl, string sifra)
        {
            OsveziLog(String.Format(PRIJAVA, mejl));
            VratiKlijentaSO klijentSO = new VratiKlijentaSO();
            klijentSO.IzvrsiSO(new Klijent() { Mejl = mejl, Sifra = sifra });

            if (klijentSO.Rezultat != null)
            {
                OsveziLog(String.Format(USPESNA_PRIJAVA, mejl));
                Ulogovani.Add(klijentSO.Rezultat as Osoba);
                return klijentSO.Rezultat as IDomenskiObjekat;
            } else
            {
                VratiAdminaSO adminSO = new VratiAdminaSO();
                adminSO.IzvrsiSO(new Admin() { Mejl = mejl, Sifra = sifra });

                if (adminSO.Rezultat == null)
                {
                    OsveziLog(String.Format(NEUSPESNA_PRIJAVA, mejl));
                }
                else
                {
                    OsveziLog(String.Format(USPESNA_PRIJAVA, mejl));
                    Ulogovani.Add(klijentSO.Rezultat as Osoba);
                }
                return adminSO.Rezultat as IDomenskiObjekat;
            }
        }

        public void OsveziLog(string poruka)
        {
            Forma.Invoke(new OsveziLogCallback(Forma.OsveziLog), poruka);
        }
    }
}
