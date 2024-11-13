using Domain.PomocneMetode.RacunanjeUkupneVrednosti;

namespace Common.Modeli
{
    public class Prodavnica
    {
        public int ID { get; set; }
        public IEnumerable<Oruzje> Oruzje { get; set; }
        public IEnumerable<Napici> Napicis { get; set; }
        public int Vrednost => RacunanjeUkupneVrednosti.IzracunajUkupnuVrednost(Oruzje, Napicis);

        public Prodavnica() { }

        public Prodavnica(int iD, IEnumerable<Oruzje> oruzje, IEnumerable<Napici> napici)
        {
            ID = iD;
            Oruzje = oruzje;
            Napicis = napici;
        }
    }
}