using Common.Modeli;
using Servisi.KupovinaSvihIgracca;

namespace Presentation
{
    public class KupovinaSvihIgracaPresentation
    {
        private readonly KupovinaSvihIgraca _kupovinaSvihIgraca;
        public KupovinaSvihIgracaPresentation(KupovinaSvihIgraca kupovinaSvihIgraca)
        {
            _kupovinaSvihIgraca = kupovinaSvihIgraca;
        }

        public void KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prodavnica, out int ukPotroseno)
        {
            _kupovinaSvihIgraca.KupovinaSvih(PlaviTim, CrveniTim, prodavnica, out ukPotroseno);
        }
    }
}
