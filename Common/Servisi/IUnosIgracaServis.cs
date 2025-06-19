using Common.Modeli;
using Domain.Rezultati;

namespace Domain.Servisi
{
    public interface IUnosIgracaServis
    {
        public UnosIgracaRezultat UnosIgraca(string nik, string naziv);
    }
}