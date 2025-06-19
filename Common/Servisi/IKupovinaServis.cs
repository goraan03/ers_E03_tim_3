using Common.Modeli;

namespace Common.Servisi
{
    public interface IKupovinaServis
    {
        public void ObaviKupovinu(Igrac igr, Prodavnica prod, out int ukupnaCena);
    }
}
