using Common.Modeli;
using Domain.Servisi;
using KupovinaService = Servisi.KupovinaFolder.KupovinaServis;

namespace Servisi.KupovinaSvihIgracaFolder
{
    public class KupovinaSvihIgracaServis : IKupovinaSvihIgraca
    {
        private int totalPotroseno = 0;

        public void KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod, out int ukPotroseno)
        {
            ukPotroseno = 0;

            var kupovinaService = new KupovinaService();

            // Kupovina za Plavi tim
            foreach (Igrac igrac in PlaviTim)
            {
                if (igrac.heroj.StanjeNovcica >= 500)
                {
                    kupovinaService.ObaviKupovinu(igrac, prod, out int ukupnaCena);
                    ukPotroseno += ukupnaCena;
                }
            }

            // Kupovina za Crveni tim
            foreach (Igrac igrac in CrveniTim)
            {
                if (igrac.heroj.StanjeNovcica >= 500)
                {
                    kupovinaService.ObaviKupovinu(igrac, prod, out int ukupnaCena);
                    ukPotroseno += ukupnaCena;
                }
            }

            totalPotroseno += ukPotroseno;
        }

        public int getTotal()
        {
            return totalPotroseno;
        }
    }
}
