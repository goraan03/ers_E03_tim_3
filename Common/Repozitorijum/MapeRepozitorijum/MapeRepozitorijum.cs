using Common.Enumeracije;
using Common.Modeli;

namespace Domain.Repozitorijum.MapeRepozitorijum
{
    public class MapeRepozitorijum
    {
        private static readonly List<Mapa> ListaMapa;
        static MapeRepozitorijum()
        {
            ListaMapa = new List<Mapa>()
            {
                new Mapa("Cosmic Ruins", Tip_Mape.LETNJA, 10, "", "", 35),
                new Mapa("Crash Site", Tip_Mape.ZIMSKA, 8, "", "", 45)
            };
        }
        public List<Mapa> SpisakMapa()
        {
            return ListaMapa;
        }
    }
}
