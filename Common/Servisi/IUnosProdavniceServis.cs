using Common.Modeli;

namespace Common.Servisi
{
    public interface IUnosProdavniceServis
    {
        bool UnosProdavnice(int id, out Prodavnica? izabranaProdavnica);
    }
}
