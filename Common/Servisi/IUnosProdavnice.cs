using Common.Modeli;

namespace Common.Servisi
{
    public interface IUnosProdavnice
    {
        bool unosProdavnice(int id, out Prodavnica? izabranaProdavnica);
    }
}
