using Common.Modeli;

namespace Domain.Repozitorijum.OruzjeRepozitorijum
{
    public class OruzjeRepozitorijum
    {
        private static readonly List<Oruzje> svo_Oruzje;

        static OruzjeRepozitorijum()
        {
            svo_Oruzje = new List<Oruzje>
            {
                new Oruzje("Mace", 100, 20, 5),
                new Oruzje("Sword", 150, 30, 3),
                new Oruzje("Bow", 120, 25, 7),
                new Oruzje("Dagger", 80, 15, 10)
            };
        }

        public List<Oruzje> SpisakOruzja()
        {
            return svo_Oruzje;
        }
    }
}
