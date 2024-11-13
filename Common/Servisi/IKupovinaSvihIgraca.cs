using Common.Modeli;

namespace Domain.Servisi
{
    public interface IKupovinaSvihIgraca
    {
        void KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod, out int ukPotroseno);
        public int getTotal();
    }
}
