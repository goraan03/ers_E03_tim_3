using Common.Modeli;
using Common.Servisi;
using System.Text;
using Domain.Servisi;
using Servisi.PripremaStatistikeFolder;

namespace Servisi.DatotekaPrikazFolder
{
    public class DatotekaPrikazServis : IDatotekaPrikaz
    {
        IPripremaStatistike _statistika;

        public DatotekaPrikazServis(PripremaStatistikeServis statistika)
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