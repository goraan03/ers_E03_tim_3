using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Klase;
using Common.Servisi;

namespace Servisi.UnosMape
{
    public class UnosMape : IUnosMape
    {
        private static readonly List<Mapa> ListaMapa;

        static UnosMape()
        {
            ListaMapa = new List<Mapa>
            {
                new Mapa("Cosmic Ruins", "letnja", 10, "", "", 14),
                new Mapa("Crash Site", "zimska", 8, "", "", 10)
            };

        }
        public bool unosNaziva(string naziv, out Mapa? IzabranaMapa)
        {
            Mapa? mapa = ListaMapa.FirstOrDefault(m => m.NazivMape.Equals(naziv));
            if (mapa == null)
            {
                Console.WriteLine("Nepostojeca mapa! Pokusajte ponovo.\n");
                IzabranaMapa = null;
                return false;
            }
            IzabranaMapa = mapa;
            return true;
        }
    }
}
