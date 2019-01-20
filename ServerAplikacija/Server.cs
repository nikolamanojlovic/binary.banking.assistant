using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ServerAplikacija
{
    public class Server
    {
        private Socket serverSoket;
        private bool kraj = false;

        public void StartServer()
        {
            serverSoket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSoket.Bind(new IPEndPoint(IPAddress.Parse(Konstante.Server.LOCALHOST), 10000));
            OsluskivanjeKlijenta();
        }

        private void OsluskivanjeKlijenta()
        {
            try
            {
                serverSoket.Listen(5);
                while (!kraj)
                {
                    Socket klijentSoket = serverSoket.Accept();
                    NetworkStream klijentskiTok = new NetworkStream(klijentSoket);
                    ObradaKlijenta obradaKlijenta = new ObradaKlijenta(klijentskiTok);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Osluskivanje zaustavljeno!");
            }
        }

        public void StopServer()
        {
            try
            {
                kraj = true;
                serverSoket.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Server zaustavljen!");
            }
        }
    }
}
