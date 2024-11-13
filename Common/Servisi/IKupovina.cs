using Common.Modeli;

namespace Common.Servisi
{
    public interface IKupovina
    {
        public void ObaviKupovinu(Igrac igr, Prodavnica prod, out int ukupnaCena);
    }
}
