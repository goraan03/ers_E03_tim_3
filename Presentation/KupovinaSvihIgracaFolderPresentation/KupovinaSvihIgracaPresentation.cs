using Common.Modeli;
using Domain.Servisi;

namespace Presentation.KupovinaSvihIgracaFolderPresentation
{
    public class KupovinaSvihIgracaPresentation
    {
        private readonly IKupovinaSvihIgracaServis _kupovinaSvihIgraca;

        public KupovinaSvihIgracaPresentation(IKupovinaSvihIgracaServis kupovinaSvihIgraca)
        {
            _kupovinaSvihIgraca = kupovinaSvihIgraca;
        }

        public int KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prodavnica)
        {
            return _kupovinaSvihIgraca.KupovinaSvih(PlaviTim, CrveniTim, prodavnica);
        }
    }
}
