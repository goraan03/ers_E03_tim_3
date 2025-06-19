using Common.Modeli;
using Domain.Servisi;
using KupovinaService = Servisi.KupovinaFolder.KupovinaServis;

namespace Servisi.KupovinaSvihIgracaFolder
{
    public class KupovinaSvihIgracaServis : IKupovinaSvihIgracaServis
    {
        private int totalPotroseno = 0;

        public int KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod)
        {
            int ukPotroseno = 0;

            var kupovinaService = new KupovinaService();

            // Kupovina za Plavi tim
            foreach (Igrac igrac in PlaviTim)
            {
                if (igrac.heroj.StanjeNovcica >= 500)
                {
                    var rezultat = kupovinaService.ObaviKupovinu(igrac, prod);
                    ukPotroseno += rezultat.UkupnaCena;
                }
            }

            // Kupovina za Crveni tim
            foreach (Igrac igrac in CrveniTim)
            {
                if (igrac.heroj.StanjeNovcica >= 500)
                {
                    var rezultat = kupovinaService.ObaviKupovinu(igrac, prod);
                    ukPotroseno += rezultat.UkupnaCena;
                }
            }

            totalPotroseno += ukPotroseno;
            return ukPotroseno;
        }

        public int getTotal()
        {
            return totalPotroseno;
        }
    }
}