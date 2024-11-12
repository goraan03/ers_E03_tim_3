using Common.Modeli;

namespace Common.Servisi
{
    public interface IAutentifikacija
    {
        public bool Prijava(string korisnickoIme, string lozinka, out Korisnik? prijavljen);
    }
}
