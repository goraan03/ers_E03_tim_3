using Common.Modeli;

namespace Common.Servisi
{
    public interface IUnosCrvenih
    {
        public bool unosCrvenih(string nik, string naziv, out Igrac? IzabranIgrac);
        public void ispisHeroja();
    }
}
