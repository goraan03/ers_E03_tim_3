using Common.Modeli;

namespace Common.Servisi
{
    public interface ITabelarniPrikazServis
    {
        public void ispisTabele(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno);
    }
}
