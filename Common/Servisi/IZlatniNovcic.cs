using Common.Modeli;

namespace Common.Servisi
{
    public interface IZlatniNovcic
    {
        void EliminacijaHeroja(Heroji protivnik);
        void EliminacijaEntiteta(int entitet);
    }
}
