using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen
{
    [Serializable]
    public class ServerTransferObjekat
    {
        private int rezultat;
        private object objekat;
        private Exception izuzetak;

        public Exception Izuzetak
        {
            get { return izuzetak; }
            set { izuzetak = value; }
        }

        public object Objekat
        {
            get { return objekat; }
            set { objekat = value; }
        }

        public int Rezultat
        {
            get { return rezultat; }
            set { rezultat = value; }
        }
    }
}
