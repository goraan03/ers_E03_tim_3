using Common.Modeli;

namespace Common.Servisi
{
    public interface IUnosMapeServis
    {
        public bool UnosNaziva(string naziv, out Mapa? IzabranaMapa);
    }
}
