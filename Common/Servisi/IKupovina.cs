using Common.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Servisi
{
    public interface IKupovina
    {
        void KupovinaProvera(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod);

        void Kupi(Igrac igr, Prodavnica prod);
    }
}
