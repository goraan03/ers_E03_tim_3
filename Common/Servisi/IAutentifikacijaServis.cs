using Common.Modeli;

namespace Common.Servisi
{
    public interface IAutentifikacijaServis
    {
        public bool Prijava(string korisnickoIme, string lozinka, out Korisnik? prijavljen);
    }
}
