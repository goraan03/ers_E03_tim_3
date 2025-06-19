using Common.Modeli;
using Common.Servisi;
using System.Text;
using Domain.Servisi;

namespace Servisi.TabelarniPrikazFolder
{
    public class TabelarniPrikazServis : ITabelarniPrikazServis
    {
        private readonly IPripremaStatistikeServis _statistika;

        public TabelarniPrikazServis(IPripremaStatistikeServis statistika)
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
