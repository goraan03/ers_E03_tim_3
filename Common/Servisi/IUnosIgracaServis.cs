using Common.Modeli;

namespace Domain.Servisi
{
    public interface IUnosIgracaServis
    {
        public bool UnosIgraca(string nik, string naziv, out Igrac? IzabranIgrac);
    }
}