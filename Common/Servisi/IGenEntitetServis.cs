using Common.Modeli;

namespace Common.Servisi
{
    public interface IGenEntitetServis
    {
        public bool DodajEntitete(out Entitet? ent);
    }
}
