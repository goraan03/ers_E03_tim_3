using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeli
{
    public class Napici
    {
        private int napad;

        public string Naziv { get; set; } = string.Empty;
        public int Cena { get; set; }
        public int Napad
        {
            get { return napad; }
            set
            {
                if (value < 15 || value > 40)
                    throw new ArgumentOutOfRangeException("Napad mora biti između 15 i 40.");
                napad = value;
            }
        }

        public int Kolicina { get; set; }

        public Napici() { }

        public Napici(string naziv, int cena, int napad, int kolicina)
        {
            Naziv = naziv;
            Cena = cena;
            Napad = napad;
            Kolicina = kolicina;
        }
    }
}
