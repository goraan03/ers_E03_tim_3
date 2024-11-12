using Common.Enumeracije;
using Common.Modeli;
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
                new Mapa("Cosmic Ruins", Tip_Mape.LETNJA, 10, "", "", 35),
                new Mapa("Crash Site", Tip_Mape.ZIMSKA, 8, "", "", 45)
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
