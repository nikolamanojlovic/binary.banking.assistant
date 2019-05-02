using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace KlijetAplikacija.Kontroleri
{
    public class KontrolerGlavneForme
    {
        public void Odjava()
        {
            try
            {
                KlijentTransferObjekat zahtev = new KlijentTransferObjekat()
                {
                    Operacija = Operacija.KRAJ
                };

                Komunikacija.DajKomunikaciju().PosaljiZahtev(zahtev);
            }
            catch (Exception ex)
            {
                return;
            }
        }
    }
}
