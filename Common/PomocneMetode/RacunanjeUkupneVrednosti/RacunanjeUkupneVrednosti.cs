using Common.Modeli;

namespace Domain.PomocneMetode.RacunanjeUkupneVrednosti
{
    public class RacunanjeUkupneVrednosti
    {
        public static int IzracunajUkupnuVrednost(IEnumerable<Oruzje> oruzje, IEnumerable<Napici> napici)
        {
            int ukupnaVrednostOruzja = oruzje.Sum(o => o.Cena * o.Kolicina);
            int ukupnaVrednostNapitaka = napici.Sum(n => n.Cena * n.Kolicina);
            return ukupnaVrednostOruzja + ukupnaVrednostNapitaka;
        }
    }
}
