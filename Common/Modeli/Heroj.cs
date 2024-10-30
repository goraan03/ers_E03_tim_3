using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeli
{
    public class Heroj
    {
        public string NazivHeroja { get; set; } = string.Empty;

        public int ZivotniPoeni { get; set; } 

        public int JacinaNapada { get; set; }

        public int StanjeNovcica { get; set; }

        public Heroj() { }

        public Heroj(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int stanjeNovcica)
        {
            NazivHeroja = nazivHeroja;
            ZivotniPoeni = zivotniPoeni;
            JacinaNapada = jacinaNapada;
            StanjeNovcica = stanjeNovcica;
        }
    }
}
