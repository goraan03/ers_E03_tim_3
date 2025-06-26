using Common.Modeli;
using Common.Servisi;
using Domain.Servisi;
using System.Text;

namespace Servisi.DatotekaPrikazFolder
{
    public class DatotekaPrikazServis : IDatotekaPrikazServis
    {
        IPripremaStatistikeServis _statistika;

        public DatotekaPrikazServis(IPripremaStatistikeServis statistika)
        {
            _statistika = statistika;
        }

        public void IspisFajl(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno)
        {
            StringBuilder pripremljeno = _statistika.PripremaIspis(TimPlavi, TimCrveni, m, ukPotroseno);
            using StreamWriter sw = new StreamWriter("statistika.txt", append: false);
            sw.WriteLine(pripremljeno);
        }
    }
}