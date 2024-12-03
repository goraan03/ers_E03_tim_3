using Common.Modeli;
using System.Text;

namespace Domain.Servisi
{
    public interface IPripremaStatistike
    {
        public StringBuilder PripremaIspis(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno);
    }
}
