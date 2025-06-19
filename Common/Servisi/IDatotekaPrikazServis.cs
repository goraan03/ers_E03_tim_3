using Common.Modeli;

namespace Common.Servisi
{
    public interface IDatotekaPrikazServis
    {
        public void IspisFajl(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno);
    }
}
