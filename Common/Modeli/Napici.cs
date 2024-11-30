namespace Common.Modeli
{
    public class Napici
    {
        public string Naziv { get; set; } = string.Empty;
        public int Cena { get; set; }
        public int Napad { get; set; }

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
