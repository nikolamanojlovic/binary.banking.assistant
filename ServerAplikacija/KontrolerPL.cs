using Domen;
using Sesija;
using SistemskeOperacije;
using System;
using System.Collections.Generic;
using System.Linq;
using static ServerAplikacija.ServerForma;

namespace ServerAplikacija
{
    public class KontrolerPL
    {
        private const String PRIJAVA = "Pokušaj prijave klijenta {0}.";
        private const String USPESNA_PRIJAVA = "Klijent {0} je uspešno prijavljen.";
        private const String NEUSPESNA_PRIJAVA = "Klijent {0} je neuspešno prijavljen.";
        private const String ODJAVA = "Klijent {0} se odjavio!";

        private readonly String KRITERIJUM_JMBG = " jmbg = '{0}' ";
        private readonly String KRITERIJUM_PRIJAVE = Konstante.TabelaKlijent.POLJE_MEJL + " = '{0}' " + Konstante.SQL.AND + Konstante.TabelaKlijent.POLJE_SIFRA + " = '{1}' ";
        private readonly String KRITERIJUM_KREDIT = Konstante.TabelaKlijent.PK_KLIJENT_ID + " = '{0}' ";
        private readonly String KRITERIJUM_RACUN = "( " + Konstante.TabelaTransakcija.POLJE_POSILJALAC_RACUN + " = '{0}' " + Konstante.SQL.OR_BEZ_UBACIVANJA +
                                                   Konstante.TabelaTransakcija.POLJE_PRIMALAC_RACUN + " = '{1}' )";

        private readonly String KRITERIJUM_UPLATE = Konstante.TabelaTransakcija.POLJE_PRIMALAC_RACUN + " = '{0}'";
        private readonly String KRITERIJUM_ISPLATE = Konstante.TabelaTransakcija.POLJE_POSILJALAC_RACUN + " = '{0}' ";

        private readonly int BANKA_ID = -1;

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
            klijentSO.IzvrsiSO(new Klijent(), String.Format(KRITERIJUM_PRIJAVE, new String[] { mejl, sifra }));

            if (klijentSO.Rezultat != null)
            {
                Klijent klijent = klijentSO.Rezultat as Klijent;

                if (sifra.Equals(klijent.Sifra))
                {
                    OsveziLog(String.Format(USPESNA_PRIJAVA, mejl));
                    Ulogovani.Add(klijent);
                    OsveziUlogovane();
                    return klijent as IDomenskiObjekat;
                }
            } else
            {
                VratiAdminaSO adminSO = new VratiAdminaSO();
                adminSO.IzvrsiSO(new Admin(), String.Format(KRITERIJUM_PRIJAVE, new String[] { mejl, sifra }));

                if (adminSO.Rezultat != null)
                {
                    Admin admin = adminSO.Rezultat as Admin;

                    if (sifra.Equals(admin.Sifra))
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

        public List<IDomenskiObjekat> PronadjiKlijenteIRacuneSaKritrijumom(Klijent klijent, string v)
        {
            VratiRacuneSO vratiRacuneSo = new VratiRacuneSO();
            vratiRacuneSo.IzvrsiSO(klijent, kriterijum: v);
            return (List<IDomenskiObjekat>)vratiRacuneSo.Rezultat;
        }

        public IDomenskiObjekat PronadjiKlijenta(string jmbg)
        {
            VratiKlijentaSO klijentSO = new VratiKlijentaSO();
            klijentSO.IzvrsiSO(new Klijent(), String.Format(KRITERIJUM_JMBG, jmbg));
            return (IDomenskiObjekat) klijentSO.Rezultat;
        }

        public List<IDomenskiObjekat> PronadjiKljentoveRacune(Klijent klijent)
        {
            VratiRacuneSO vratiRacuneSo = new VratiRacuneSO();
            vratiRacuneSo.IzvrsiSO(klijent);
            return (List<IDomenskiObjekat>)vratiRacuneSo.Rezultat;
        }

        public List<IDomenskiObjekat> PronadjiKljentoveKredite(Klijent klijent)
        {
            VratiKrediteSO vratiKrediteSO = new VratiKrediteSO();
            vratiKrediteSO.IzvrsiSO(klijent);
            return (List<IDomenskiObjekat>)vratiKrediteSO.Rezultat;
        }

        public List<IDomenskiObjekat> PronadjiKlijentoveTransakcijeZaRacun(Klijent klijent, String racun, String uplate, String isplate, String uplateKredita, String isplateKredita)
        {
            VratiTransakcijeZaRacunSaKriterijumomSO vratiTransakcijeZaRacunSaKriterijumomSO = new VratiTransakcijeZaRacunSaKriterijumomSO();

            String kriterijum = "";

            if (Boolean.TrueString.Equals(uplate) && Boolean.FalseString.Equals(isplate) )
            {
                kriterijum = String.Format(KRITERIJUM_UPLATE, racun);
            }
            else if (Boolean.FalseString.Equals(uplate) && Boolean.TrueString.Equals(isplate))
            {
                kriterijum = String.Format(KRITERIJUM_ISPLATE, racun); ;
            }
            else
            {
                kriterijum = String.Format(KRITERIJUM_RACUN, new String[] { racun, racun } );
            }

            vratiTransakcijeZaRacunSaKriterijumomSO.IzvrsiSO(new Transakcija(), kriterijum: kriterijum, sifraJakog: Convert.ToString(klijent.ID));
            return ((List<IDomenskiObjekat>)vratiTransakcijeZaRacunSaKriterijumomSO.Rezultat);
        }

        public List<IDomenskiObjekat> PronadjiKlijenteIRacune()
        {
            VratiSveKlijenteSO vratiSveKlijenteSO = new VratiSveKlijenteSO();
            vratiSveKlijenteSO.IzvrsiSO(new Klijent());
            List<IDomenskiObjekat> lista = ((List<IDomenskiObjekat>) vratiSveKlijenteSO.Rezultat);


            if (lista == null || lista.Count == 0)
            {
                return null;
            }

            List<Klijent> klijenti = lista.ConvertAll(x => (Klijent)x);
            klijenti.RemoveAll(x => x.ID == -1);

            foreach ( Klijent k in klijenti )
            {
                VratiRacuneSO vratiRacuneSO = new VratiRacuneSO();
                vratiRacuneSO.IzvrsiSO(k);

                List<IDomenskiObjekat> racuni = (List<IDomenskiObjekat>) vratiRacuneSO.Rezultat;

                if (racuni == null || racuni.Count == 0)
                {
                    k.Racuni = null;
                }
                else
                {
                    k.Racuni = racuni.ConvertAll(x => (Racun)x);
                }
            }

            return klijenti.ConvertAll(x => (IDomenskiObjekat) x);
        }

        public List<IDomenskiObjekat> PronadjiTipoveKredita()
        {
            VratiTipoveKreditaSO vratiTipoveKreditaSO = new VratiTipoveKreditaSO();
            vratiTipoveKreditaSO.IzvrsiSO(new TipKredita());
            return (List<IDomenskiObjekat>) vratiTipoveKreditaSO.Rezultat;
        }

        public string VratiNoviIDKreditaZaKlijenta(Klijent klijent)
        {
            VratiIDNovogKreditaSO vratiIDNovogKreditaSO = new VratiIDNovogKreditaSO();
            vratiIDNovogKreditaSO.IzvrsiSO(new AktiviraniKredit(), sifraJakog: Convert.ToString(klijent.ID));
            return Convert.ToString(vratiIDNovogKreditaSO.Rezultat);
        }

        public string VratiNoviIDRacunaZaKlijenta(Klijent klijent)
        {
            VratiIDNovogRacunaSO vratiIDNovogRacuna = new VratiIDNovogRacunaSO();
            vratiIDNovogRacuna.IzvrsiSO(new Racun(), sifraJakog: Convert.ToString(klijent.ID));
            return Convert.ToString(vratiIDNovogRacuna.Rezultat);
        }

        public string VratiNoviID(object korisnik)
        {
            VratiIDSO vratiIDSO = new VratiIDSO();
            vratiIDSO.IzvrsiSO((IDomenskiObjekat)korisnik);
            return Convert.ToString(vratiIDSO.Rezultat);
        }

        public bool IzmeniKorisnika(Klijent klijent)
        {
            IzmeniKlijentaSO izmeniKlijentaSO = new IzmeniKlijentaSO();
            izmeniKlijentaSO.IzvrsiSO(klijent);
            return (bool) izmeniKlijentaSO.Rezultat;
        }

        public bool ObrisiKorisnika(Klijent klijent)
        {
            try
            {
                ObrisiKlijentaSO obrisiKlijentaSO = new ObrisiKlijentaSO();
                return obrisiKlijentaSO.IzvrsiSO(klijent, sifraJakog: Convert.ToString(klijent.ID));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SacuvajNovogKorisnika(IDomenskiObjekat korisnik)
        {
            SacuvajKlijentaSO sacuvajKorisnikaSO = new SacuvajKlijentaSO();
            sacuvajKorisnikaSO.IzvrsiSO(korisnik);
            return (bool) sacuvajKorisnikaSO.Rezultat;
        }

        public bool SacuvajRacuneKorisnika(Klijent klijent, List<Racun> racuni)
        {
            SacuvajKlijentoveRacuneSO sacuvajKlijentoveRacuneSO = new SacuvajKlijentoveRacuneSO();
            sacuvajKlijentoveRacuneSO.IzvrsiStavkeSO(racuni.ConvertAll(x => (IDomenskiObjekat)x), sifraJakog: Convert.ToString(klijent.ID));
            return (bool) sacuvajKlijentoveRacuneSO.Rezultat;
        }

        public bool SacuvajKredit(IDomenskiObjekat kredit)
        {
            SacuvajKreditSO sacuvajKreditSO = new SacuvajKreditSO();
            return sacuvajKreditSO.IzvrsiSO(kredit);
        }

        public void DiskonektujKlijenta(Osoba ulogovan)
        {
            ulogovani.RemoveAll(x => x.Mejl.Equals(ulogovan.Mejl));
            OsveziLog(String.Format(ODJAVA, ulogovan.Mejl));
            OsveziUlogovane();
        }

        public void OsveziUlogovane()
        {
            if ( ulogovani != null )
            {
                Forma.Invoke(new OsveziUlogovaneCallback(Forma.OsveziUlogovane), ulogovani);
            }
        }

        public void OsveziLog(string poruka)
        {
            Forma.Invoke(new OsveziLogCallback(Forma.OsveziLog), poruka);
        }

        public bool SacuvajTransakcije(Transakcija transakcija, string pos, string prim)
        {
            SacuvajTransakcijuSO sacuvajTransakcijuSO = new SacuvajTransakcijuSO();
            return sacuvajTransakcijuSO.IzvrsiSO(transakcija, pos, prim);
        }
    }
}
