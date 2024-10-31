using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeli;
using Common.Servisi;

namespace Common.Servisi
{
    public interface IUnosCrvenih
    {
        public bool unosCrvenih(string nik, string naziv, out Igrac? IzabranIgrac);
        public void ispisHeroja();
    }
}
