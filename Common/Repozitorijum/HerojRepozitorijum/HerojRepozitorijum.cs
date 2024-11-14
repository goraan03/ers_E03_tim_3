using Common.Modeli;

namespace Domain.Repozitorijum.HerojRepozitorijum
{
    public class HerojRepozitorijum
    {
        private static readonly List<Heroj> svi_heroji;

        static HerojRepozitorijum()
        {
            svi_heroji = new List<Heroj>
            {
                new Heroj("Malphite", 1250, 120, 0),
                new Heroj("Zac", 1100, 95, 0),
                new Heroj("Ahri", 900, 135, 0),
                new Heroj("Ezreal", 870, 175, 0),
                new Heroj("Nami", 780, 120, 0),
                new Heroj("Orn", 1350, 110, 0),
                new Heroj("Elise", 950, 120, 0),
                new Heroj("Yasuo", 900, 160, 0),
                new Heroj("Jhin", 860, 180, 0),
                new Heroj("Blitzcrank", 950, 90, 0)
            };
        }

        public List<Heroj> SpisakHeroja()
        {
            return svi_heroji;
        }
    }
}
