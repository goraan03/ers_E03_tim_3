using Common.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Servisi
{
    public interface IKupovinaSvihIgraca
    {
        void KupovinaSvih(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod, out int ukPotroseno);
        public int getTotal();
    }
}
