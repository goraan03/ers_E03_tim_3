using Common.Modeli;

namespace Domain.Repozitorijum.NapiciRepozitorijum
{
    public class NapiciRepozitorijum
    {
        private static readonly List<Napici> svi_Napici;

        static NapiciRepozitorijum()
        {
            svi_Napici = new List<Napici>
            {
                new Napici("Health Potion", 50, 40, 10),
                new Napici("Mana Potion", 40, 25, 8),
                new Napici("Energy Drink", 30, 23, 5),
                new Napici("Shield Potion", 60, 35, 4)
            };
        }

        public List<Napici> SpisakNapitaka()
        {
            return svi_Napici;
        }
    }
}
