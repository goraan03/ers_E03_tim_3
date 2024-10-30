using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeli
{
    public class Korisnik
    {
        public string KorisnickoIme {  get; set; } = string.Empty;
        public string Lozinka { get; set; } = string.Empty;
        public string ImePrezime { get; set; } = string.Empty;
        public Korisnik() { }

        public Korisnik(string korisnickoIme, string lozinka, string imePrezime)
        {
            KorisnickoIme = korisnickoIme;
            Lozinka = lozinka;
            ImePrezime = imePrezime;
        }
    }
}
