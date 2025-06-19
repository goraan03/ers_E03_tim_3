using Common.Modeli;
using Common.Servisi;

namespace Servisi.GenEntitetFolder
{
    public class GenEntitetServis : IGenEntitetServis
    {
        public Entitet genEnt;
        public GenEntitetServis() { }
        public bool DodajEntitete(out Entitet? ent)
        {
            genEnt = new Entitet();
            ent = genEnt;
            return true;
        }
    }
}
