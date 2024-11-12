using Common.Modeli;
using Common.Servisi;

namespace Servisi.GenEntitet
{
    public class GenEntitet : IGenEntitet
    {
        public Entitet genEnt;
        public GenEntitet() { }
        public bool dodajEntitete(out Entitet? ent)
        {
            genEnt = new Entitet();
            ent = genEnt;
            return true;
        }
    }
}
