using Common.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Servisi
{
    public interface INapadNaEntitet
    {
        public void NapadniEntitet(List<Igrac>TimPlavi, List<Igrac> TimCrveni, List<Entitet> ent);
    }
}
