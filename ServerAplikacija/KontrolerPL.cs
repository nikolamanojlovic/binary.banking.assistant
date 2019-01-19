using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAplikacija
{
    public class KontrolerPL
    {
        public static KontrolerPL kontroler;
        private Form forma;
        private List<Osoba> ulgovani;

        private KontrolerPL()
        {

        }

        public static KontrolerPL DajKontroler()
        {
            if (kontroler == null)
            {
                return new KontrolerPL();
            }
            return kontroler;
        }
        
        public Form Forma
        {
            get { return forma; }
            set { forma = value; }
        }

        public List<Osoba> Ulogovani
        {
            get { return ulgovani; }
            set { ulgovani = value; }
        }
    }
}
