using Common.Modeli;

namespace Domain.Servisi
{
    public interface IUnosIgraca
    {
        public bool UnosIgraca(string nik, string naziv, out Igrac? IzabranIgrac);
    }
}