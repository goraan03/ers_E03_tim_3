using Common.Modeli;
using System.Text;

namespace Domain.Servisi
{
    public interface IPripremaStatistikeServis
    {
        public StringBuilder PripremaIspis(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno);
    }
}
