using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Domen.Operacije;

namespace Domen
{
    [Serializable]
    public class KlijentTransferObjekat
    {
        private Operacija operacija;
        private object poruka;

        public object Poruka
        {
            get { return poruka; }
            set { poruka = value; }
        }

        public Operacija Operacija
        {
            get { return operacija; }
            set { operacija = value; }
        }
    }
}
