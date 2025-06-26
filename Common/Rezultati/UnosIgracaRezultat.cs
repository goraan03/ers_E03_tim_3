using Common.Modeli;

namespace Domain.Rezultati
{
    public class UnosIgracaRezultat
    {
        public bool Uspeh { get; }
        public Igrac? Igrac { get; }
        public string? Poruka { get; }

        private UnosIgracaRezultat(bool uspeh, Igrac? igrac, string? poruka)
        {
            Uspeh = uspeh;
            Igrac = igrac;
            Poruka = poruka;
        }

        public static UnosIgracaRezultat Uspesno(Igrac igrac)
            => new UnosIgracaRezultat(true, igrac, null);

        public static UnosIgracaRezultat Neuspesno(string poruka)
            => new UnosIgracaRezultat(false, null, poruka);
    }
}
