using Common.Modeli;

namespace Common.Servisi
{
    public interface INapadNaEntitetServis
    {
        public void NapadniEntitet(List<Igrac> TimPlavi, List<Igrac> TimCrveni, List<Entitet> ent);
    }
}
