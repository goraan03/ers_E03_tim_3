using Common.Modeli;
using Domain.Servisi;
using Servisi.KupovinaSvihIgracaFolder;

namespace Presentation.KupovinaSvihIgracaFolderPresentation
{
    public class KupovinaSvihIgracaPresentation
    {
        private readonly IKupovinaSvihIgracaServis _kupovinaSvihIgraca;
        public KupovinaSvihIgracaPresentation(IKupovinaSvihIgracaServis kupovinaSvihIgraca)
        {
            _kupovinaSvihIgraca = kupovinaSvihIgraca;
        }

        public void KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prodavnica, out int ukPotroseno)
        {
            _kupovinaSvihIgraca.KupovinaSvih(PlaviTim, CrveniTim, prodavnica, out ukPotroseno);
        }
    }
}
