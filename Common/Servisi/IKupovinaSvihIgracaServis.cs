using Common.Modeli;

namespace Domain.Servisi
{
    public interface IKupovinaSvihIgracaServis
    {
        public int KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod);
        public int getTotal();
    }
}
