using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Klase
{
    public class Mapa
    {
        public string NazivMape { get; set; }

        public string TipMape { get; set; }

        public int MaxIgraca { get; set; }

        public string PlaviTim { get; set; }

        public string CrveniTim { get; set; }

        public int PomocniEntiteti { get; set; }

        public Mapa(string nazivMape, string tipMape, int maxIgraca, string plaviTim, string crveniTim, int pomocniEntiteti)
        {
            NazivMape = nazivMape;
            TipMape = tipMape;
            MaxIgraca = maxIgraca;
            PlaviTim = plaviTim;
            CrveniTim = crveniTim;
            PomocniEntiteti = pomocniEntiteti;
        }
    }
}
