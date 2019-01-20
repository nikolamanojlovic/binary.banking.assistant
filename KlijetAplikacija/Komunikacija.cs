using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace KlijetAplikacija
{
    public class Komunikacija
    {
        public static Komunikacija komunikacija;
        private TcpClient klijent;
        private NetworkStream tok;
        private BinaryFormatter formater;

        private Komunikacija()
        {

            klijent = new TcpClient(Konstante.Server.LOCALHOST, 10000);
            tok = klijent.GetStream();
            formater = new BinaryFormatter();
        }

        public static Komunikacija DajKomunikaciju()
        {
            if ( komunikacija == null )
            {
                komunikacija = new Komunikacija();
            }
            return komunikacija;
        }

        public void PosaljiZahtev(KlijentTransferObjekat klijentTransferObjekat)
        {
            formater.Serialize(tok, klijentTransferObjekat);
        }

        public ServerTransferObjekat ProcitajOdgovor()
        {
            return formater.Deserialize(tok) as ServerTransferObjekat;
        }
    }
}
