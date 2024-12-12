using Common.Modeli;

namespace Common.Servisi
{
    public interface IUnosProdavnice
    {
        bool UnosProdavnice(int id, out Prodavnica? izabranaProdavnica);
    }
}
