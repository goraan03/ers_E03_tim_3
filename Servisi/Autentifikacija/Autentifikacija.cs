using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.KorisniciRepozitorijum;

namespace Servisi.Autentifikacija
{
    public class Autentifikacija : IAutentifikacija
    {
        private readonly KorisniciRepozitorijum _korisniciRepozitorijum;
        private List<Korisnik> ListaKorisnika;

        public Autentifikacija(KorisniciRepozitorijum korisniciRepozitorijum)
        {
            this._korisniciRepozitorijum = korisniciRepozitorijum;
            ListaKorisnika = _korisniciRepozitorijum.SpisakKorisnika();
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