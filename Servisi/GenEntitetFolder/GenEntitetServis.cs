using Common.Modeli;
using Common.Servisi;

namespace Servisi.GenEntitetFolder
{
    public class GenEntitetServis : IGenEntitet
    {
        public Entitet genEnt;
        public GenEntitetServis() { }
        public bool dodajEntitete(out Entitet? ent)
        {
            genEnt = new Entitet();
            ent = genEnt;
            return true;
        }
    }
}
