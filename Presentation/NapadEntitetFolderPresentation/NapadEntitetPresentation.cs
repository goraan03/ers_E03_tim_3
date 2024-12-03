using Common.Modeli;
using Common.Servisi;

namespace Presentation.NapadEntitetFolderPresentation
{
    public class NapadEntitetPresentation
    {
        private readonly INapadNaEntitet _napadNaEntitet;

        public NapadEntitetPresentation(INapadNaEntitet napadNaEntitet)
        {
            _napadNaEntitet = napadNaEntitet;
        }

        public void NapadniEntitet(List<Igrac> TimPlavi, List<Igrac> TimCrveni, List<Entitet> listaEntiteta)
        {
            _napadNaEntitet.NapadniEntitet(TimPlavi, TimCrveni, listaEntiteta);
        }
    }
}
