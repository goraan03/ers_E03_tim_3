using Common.Modeli;
using Common.Servisi;
using System.Text;
using Domain.Servisi;
using Servisi.PripremaStatistikeFolder;

namespace Servisi.TabelarniPrikazFolder
{
    public class TabelarniPrikazServis : ITabelarniPrikaz
    {
        IPripremaStatistike _statistika;

        public TabelarniPrikazServis(PripremaStatistikeServis statistika)
        {
            _statistika = statistika;
        }
        public void ispisTabele(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno)
        {
            StringBuilder pripremljeno = _statistika.PripremaIspis(TimPlavi, TimCrveni, m, ukPotroseno);
            Console.WriteLine(pripremljeno);
        }
    }
}