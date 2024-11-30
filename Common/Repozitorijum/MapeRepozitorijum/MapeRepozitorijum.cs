using Common.Enumeracije;
using Common.Modeli;
using Domain.RepozitorijumInterfejsi.IMapeRepozitorijum;

namespace Domain.Repozitorijum.MapeRepozitorijum
{
    public class MapeRepozitorijum : IMapeRepozitorijum
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
