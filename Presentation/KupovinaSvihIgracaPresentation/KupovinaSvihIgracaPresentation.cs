using Common.Modeli;
using Domain.Servisi;
using Servisi.KupovinaSvihIgracca;

namespace Presentation
{
    public class KupovinaSvihIgracaPresentation
    {
        private readonly IKupovinaSvihIgraca _kupovinaSvihIgraca;
        public KupovinaSvihIgracaPresentation(IKupovinaSvihIgraca kupovinaSvihIgraca)
        {
            _kupovinaSvihIgraca = kupovinaSvihIgraca;
        }

        public void KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prodavnica, out int ukPotroseno)
        {
            _kupovinaSvihIgraca.KupovinaSvih(PlaviTim, CrveniTim, prodavnica, out ukPotroseno);
        }
    }
}
