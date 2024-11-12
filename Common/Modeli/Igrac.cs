namespace Common.Modeli
{
    public class Igrac
    {
        public string Naziv { get; set; }
        public Heroj heroj { get; set; } = new Heroj();
        public Igrac() { }

        public Igrac(string naziv, Heroj heroj)
        {
            Naziv = naziv;
            this.heroj = heroj;
        }
    }
}
