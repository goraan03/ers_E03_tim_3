using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.KorisniciRepozitorijum;

namespace Servisi.AutentifikacijaFolder
{
    public class AutentifikacijaServis : IAutentifikacija
    {
        IKorisniciRepozitorijum _korisniciRepozitorijum = new KorisniciRepozitorijum();

        public AutentifikacijaServis() {}
        public bool Prijava(string korisnickoIme, string lozinka, out Korisnik? prijavljen)
        {
            Korisnik? korisnik = _korisniciRepozitorijum.SpisakKorisnika().FirstOrDefault(k => k.KorisnickoIme.Equals(korisnickoIme));
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