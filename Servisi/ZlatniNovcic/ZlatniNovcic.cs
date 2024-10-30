using Common.Servisi;
using Common.Modeli;

namespace Servisi.ZlatniNovcic
{
    public class ZlatniNovcic : IZlatniNovcic
    {

        private Heroji Moj_heroj;

        public ZlatniNovcic(Heroji heroj) 
        {
            Moj_heroj = heroj;
        }

        public void EliminacijaEntiteta(int entitet)
        {
            Random random = new Random();
            int dodati_novcici = random.Next(20, 91);
            Moj_heroj.StanjeNovcica += dodati_novcici;
        }

        public void EliminacijaHeroja(Heroji protivnik)
        {
            Moj_heroj.StanjeNovcica += 300;
        }
    }
}
