namespace Common.Modeli
{
    public class Korisnik
    {
        public string KorisnickoIme { get; set; } = string.Empty;
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
