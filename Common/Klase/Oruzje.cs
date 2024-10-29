using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Klase
{
    public class Oruzje
    {
        public string Naziv { get; set; } = string.Empty;
        public int Cena { get; set; }
        public int Napad { get; set; }
        public int Kolicina { get; set; }

        public Oruzje() { }

        public Oruzje(string naziv, int cena, int napad, int kolicina)
        {
            Naziv = naziv;
            Cena = cena;
            Napad = napad;
            Kolicina = kolicina;
        }
    }
}
