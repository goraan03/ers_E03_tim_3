using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
