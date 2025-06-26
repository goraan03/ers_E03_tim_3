namespace Domain.Rezultati
{
    public class KupovinaRezultat
    {
        public bool Uspeh { get; }
        public int UkupnaCena { get; }
        public string Poruka { get; }

        private KupovinaRezultat(bool uspeh, int ukupnaCena, string poruka = "")
        {
            Uspeh = uspeh;
            UkupnaCena = ukupnaCena;
            Poruka = poruka;
        }

        public static KupovinaRezultat Uspesno(int ukupnaCena)
            => new KupovinaRezultat(true, ukupnaCena);

        public static KupovinaRezultat Neuspesno(string poruka)
            => new KupovinaRezultat(false, 0, poruka);
    }
}
