using Common.Modeli;

namespace Common.Servisi
{
    public interface IUnosMape
    {
        public bool unosNaziva(string naziv, out Mapa? IzabranaMapa);
    }
}
