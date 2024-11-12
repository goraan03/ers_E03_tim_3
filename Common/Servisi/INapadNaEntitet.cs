using Common.Modeli;

namespace Common.Servisi
{
    public interface INapadNaEntitet
    {
        public void NapadniEntitet(List<Igrac> TimPlavi, List<Igrac> TimCrveni, List<Entitet> ent);
    }
}
