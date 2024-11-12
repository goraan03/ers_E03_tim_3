using Common.Modeli;

namespace Common.Servisi
{
    public interface IUnosPlavih
    {
        public bool unosPlavih(string nik, string naziv, out Igrac? IzabranIgrac);
    }
}
