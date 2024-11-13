using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.IspisRepozitorijum;

namespace Servisi.TabelarniPrikaz
{
    public class TabelarniPrikaz : ITabelarniPrikaz
    {
        public void ispisTabele(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno)
        {
            var statistikaIspis = new IspisRepozitorijum();

            statistikaIspis.Ispis(TimPlavi, TimCrveni, m, ukPotroseno, Console.WriteLine);
        }
    }
}
