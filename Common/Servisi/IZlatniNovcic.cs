using Common.Modeli;

namespace Common.Servisi
{
    public interface IZlatniNovcic
    {
        void EliminacijaHeroja(Heroj protivnik);
        void EliminacijaEntiteta(Entitet entitet);
    }
}