using Common.Servisi;
using Common.Modeli;

namespace Servisi.ZlatniNovcic
{
    public class ZlatniNovcic : IZlatniNovcic
    {

        private Heroj Moj_heroj;

        public ZlatniNovcic(Heroj heroj) 
        {
            Moj_heroj = heroj;
        }

        public void EliminacijaEntiteta(Entitet entitet)
        {
            int dodati_novcici = entitet.Poeni;
            Moj_heroj.StanjeNovcica += dodati_novcici;
        }

        public void EliminacijaHeroja(Heroj protivnik)
        {
            Moj_heroj.StanjeNovcica += 300;
        }
    }
}
