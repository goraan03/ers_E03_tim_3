using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Klase;

namespace Common.Servisi
{
    public interface IUnosMape
    {
        public bool unosNaziva(string naziv, out Mapa? IzabranaMapa);
    }
}
