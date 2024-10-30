using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Servisi;

namespace Common.Modeli
{
    public class Entitet
    {
        public int Poeni { get; set; }
        public Entitet() { }

        public Entitet(int poeni)
        {
            Poeni = poeni;
        }
    }
}
