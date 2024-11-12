using Common.Modeli;
using Common.Servisi;

namespace Servisi.Autentifikacija
{
    public class Autentifikacija : IAutentifikacija
    {
        private static readonly List<Korisnik> ListaKorisnika;

        static Autentifikacija()
        {
            ListaKorisnika = new List<Korisnik>
            {
                new Korisnik("goran03", "LozinkaGoran", "Goran Grcic"),
                new Korisnik("u", "u", "Miroslav Dispiter")
            };
        }
        public bool Prijava(string korisnickoIme, string lozinka, out Korisnik? prijavljen)
        {
            Korisnik? korisnik = ListaKorisnika.FirstOrDefault(k => k.KorisnickoIme.Equals(korisnickoIme));
            if (korisnik == null)
            {
                Console.WriteLine("Nepostojece korisnicko ime!\n");
                prijavljen = null;
                return false;
            }

            if (string.IsNullOrEmpty(lozinka))
            {
                prijavljen = null;
                return false;
            }

            if (!korisnik.Lozinka.Equals(lozinka))
            {
                Console.WriteLine("Lozinka je netacna!\n");
                prijavljen = null;
                return false;
            }
            prijavljen = korisnik;
            return true;
        }
    }
}