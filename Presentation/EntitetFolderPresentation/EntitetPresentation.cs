using Common.Modeli;
using Common.Servisi;

namespace Presentation.EntitetFolderPresentation
{
    public class EntitetPresentation
    {
        private readonly IGenEntitetServis _genEntitetServis;

        public EntitetPresentation(IGenEntitetServis genEntitetServis)
        {
            _genEntitetServis = genEntitetServis;
        }

        public List<Entitet> UnesiEntitete(int brojEntiteta)
        {
            List<Entitet> listaEntiteta = new List<Entitet>();

            for (int i = 0; i < brojEntiteta; i++)
            {
                if (_genEntitetServis.DodajEntitete(out Entitet? entitet))
                {
                    listaEntiteta.Add(entitet!);
                }
            }
            return listaEntiteta;
        }
    }
}
