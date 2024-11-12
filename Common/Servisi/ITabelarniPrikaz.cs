using Common.Modeli;

namespace Common.Servisi
{
    public interface ITabelarniPrikaz
    {
        public void ispisTabele(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno);
    }
}
