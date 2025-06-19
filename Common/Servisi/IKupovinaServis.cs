using Common.Modeli;
using Domain.Rezultati;

namespace Common.Servisi
{
    public interface IKupovinaServis
    {
        public KupovinaRezultat ObaviKupovinu(Igrac igr, Prodavnica prod);
    }
}
