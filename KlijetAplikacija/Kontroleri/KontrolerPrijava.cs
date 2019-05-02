using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerPrijava
    {
        private const String NEODGOVARAJUCI_KREDENCIJALI = "Kredencijali nisu odgovarajući, pokušajte ponovo!";

        public void PrijaviKlijenta(String mejl, String sifra, Prijava prijavaForma)
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.ULOGUJ_KLIJENTA,
                    Poruka = new KeyValuePair<String, String>(mejl, sifra)
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
                ServerTransferObjekat odgovor = Komunikacija.DajKomunikaciju().ProcitajOdgovor();

                if (odgovor.Rezultat == 0)
                {
                    prijavaForma.PrikaziGreskaPoruku(NEODGOVARAJUCI_KREDENCIJALI);
                    return;
                }
                else if (odgovor.Objekat is Admin)
                {
                    Komunikacija.DajKomunikaciju().PostaviSesiju(odgovor.Objekat as Admin);
                    GlavnaFormaAdmin glavnaFormaAdmin = new GlavnaFormaAdmin()
                    {
                        FormBorderStyle = FormBorderStyle.FixedSingle,
                        StartPosition = FormStartPosition.CenterScreen,
                        Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                    Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                    Komunikacija.DajKomunikaciju().VratiSesiju().Prezime
                               })
                    };
                    glavnaFormaAdmin.Show();
                }
                else if (odgovor.Objekat is Klijent)
                {
                    Komunikacija.DajKomunikaciju().PostaviSesiju(odgovor.Objekat as Klijent);
                    GlavnaFormaKlijent glavnaFormaKlijent = new GlavnaFormaKlijent()
                    {
                        FormBorderStyle = FormBorderStyle.FixedSingle,
                        StartPosition = FormStartPosition.CenterScreen,
                        Text = String.Format(Konstante.GUI.DOBRODOSLI, new String[] {
                                    Komunikacija.DajKomunikaciju().VratiSesiju().Ime,
                                    Komunikacija.DajKomunikaciju().VratiSesiju().Prezime
                               })
                    };
                    glavnaFormaKlijent.Show();
                }
                prijavaForma.Hide();
            }
            catch (Exception ex)
            {
                prijavaForma.PrikaziGreskaPoruku(Konstante.Server.SERVER_NIJE_DOSTUPAN);
            }
        }
    }
}
