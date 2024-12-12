using Common.Modeli;

namespace Common.Servisi
{
    public interface IUnosMape
    {
        public bool UnosNaziva(string naziv, out Mapa? IzabranaMapa);
    }
}
