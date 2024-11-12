namespace Common.Modeli
{
    public class Prodavnica
    {
        public int ID { get; set; }
        public IEnumerable<Oruzje> Oruzje { get; set; }
        public IEnumerable<Napici> Napicis { get; set; }
        public int Vrednost => IzracunajUkupnuVrednost();

        public Prodavnica() { }

        public Prodavnica(int iD, IEnumerable<Oruzje> oruzje, IEnumerable<Napici> napici)
        {
            ID = iD;
            Oruzje = oruzje;
            Napicis = napici;
        }

        public int IzracunajUkupnuVrednost()
        {
            int ukupnaVrednostOruzja = Oruzje.Sum(o => o.Cena * o.Kolicina);
            int ukupnaVrednostNapitaka = Napicis.Sum(n => n.Cena * n.Kolicina);
            return ukupnaVrednostOruzja + ukupnaVrednostNapitaka;
        }
    }
}