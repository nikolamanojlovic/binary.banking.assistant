using System;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ServerAplikacija
{
    public class ObradaKlijenta
    {
        private NetworkStream tok;
        private BinaryFormatter formater;
        bool kraj;

        public ObradaKlijenta(NetworkStream tok)
        {
            this.tok = tok;
            formater = new BinaryFormatter();
            PokreniKlijenta();
        }

        private void PokreniKlijenta()
        {
            kraj = false;
            ThreadStart ts = ObradaZahteva;
            Thread kljentovaNit = new Thread(ts);
            kljentovaNit.Start();
        }

        private void ObradaZahteva()
        {
            try
            {
                while (!kraj)
                {
                   
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Klijent se diskonektovao!");
            }
        }
    }
}