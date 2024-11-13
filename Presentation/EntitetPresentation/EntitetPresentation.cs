using Common.Modeli;
using Common.Servisi;

namespace Presentation
{
    public class EntitetPresentation
    {
        private readonly IGenEntitet _genEntitetServis;

        public EntitetPresentation(IGenEntitet genEntitetServis)
        {
            _genEntitetServis = genEntitetServis;
        }

        public List<Entitet> UnesiEntitete(int brojEntiteta)
        {
            List<Entitet> listaEntiteta = new List<Entitet>();

            for (int i = 0; i < brojEntiteta; i++)
            {
                if (_genEntitetServis.dodajEntitete(out Entitet? entitet))
                {
                    listaEntiteta.Add(entitet!);
                }
            }

            return listaEntiteta;
        }
    }
}
