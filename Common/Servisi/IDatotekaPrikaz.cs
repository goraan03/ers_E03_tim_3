using Common.Modeli;

namespace Common.Servisi
{
    public interface IDatotekaPrikaz
    {
        public void IspisFajl(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno);
    }
}
