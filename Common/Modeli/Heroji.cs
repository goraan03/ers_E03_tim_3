using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeli
{
    public class Heroji
    {
        public string NazivHeroja { get; set; }
        public int ZivotniPoeni { get; set; } 

        public int JacinaNapada { get; set; }

        public int StanjeNovcica { get; set; }

        public Heroji(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int stanjeNovcica)
        {
            NazivHeroja = nazivHeroja;
            ZivotniPoeni = zivotniPoeni;
            JacinaNapada = jacinaNapada;
            StanjeNovcica = stanjeNovcica;
        }
    }
}
