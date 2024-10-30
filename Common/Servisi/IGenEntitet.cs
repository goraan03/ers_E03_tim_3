using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeli;

namespace Common.Servisi
{
    public interface IGenEntitet
    {
        public bool dodajEntitete(out Entitet? ent);
    }
}
