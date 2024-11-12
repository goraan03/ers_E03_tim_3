using Common.Modeli;

namespace Common.Servisi
{
    public interface IKupovina
    {
        void KupovinaProvera(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod, out int ukPotroseno);

        void Kupi(Igrac igr, Prodavnica prod, out int ukupnaCena);

        public int getTotal();
    }
}
