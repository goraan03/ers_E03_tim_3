using Common.Modeli;
using Common.Servisi;

namespace Presentation.NapadEntitetFolderPresentation
{
    public class NapadEntitetPresentation
    {
        private readonly INapadNaEntitetServis _napadNaEntitet;

        public NapadEntitetPresentation(INapadNaEntitetServis napadNaEntitet)
        {
            _napadNaEntitet = napadNaEntitet;
        }

        public void NapadniEntitet(List<Igrac> TimPlavi, List<Igrac> TimCrveni, List<Entitet> listaEntiteta)
        {
            _napadNaEntitet.NapadniEntitet(TimPlavi, TimCrveni, listaEntiteta);
        }
    }
}
