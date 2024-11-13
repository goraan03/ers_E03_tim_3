using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.IspisRepozitorijum;

namespace Servisi.DatotekaPrikaz
{
    public class DatotekaPrikaz : IDatotekaPrikaz
    {
        public void IspisFajl(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno)
        {
            var statistikaIspis = new IspisRepozitorijum();

            using StreamWriter sw = new StreamWriter("statistika.txt", append: false);

            statistikaIspis.Ispis(TimPlavi, TimCrveni, m, ukPotroseno, sw.WriteLine);
        }
    }
}
