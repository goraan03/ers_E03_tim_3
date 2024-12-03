using Common.Modeli;

namespace Domain.Repozitorijum.ProdavniceRepozitorijum
{
    public class ProdavniceRepozitorijum : IProdavniceRepozitorijum
    {
        private static readonly List<Prodavnica> sve_Prodavnice;

        static ProdavniceRepozitorijum()
        {
            sve_Prodavnice = new List<Prodavnica>
            {
                new Prodavnica(1, new List<Oruzje>
                {
                    new Oruzje("Mace", 100, 20, 5),
                    new Oruzje("Sword", 150, 30, 3)
                },
                new List<Napici>
                {
                    new Napici("Health Potion", 50, 40, 10),
                    new Napici("Mana Potion", 40, 25, 8)
                }),

                new Prodavnica(2, new List<Oruzje>
                {
                    new Oruzje("Bow", 120, 25, 7),
                    new Oruzje("Dagger", 80, 15, 10)
                },
                new List<Napici>
                {
                    new Napici("Energy Drink", 30, 23, 5),
                    new Napici("Shield Potion", 60, 35, 4)
                })
            };
        }

        public List<Prodavnica> SpisakProdavnica()
        {
            return sve_Prodavnice;
        }

        public Prodavnica? GetProdavnicaID(int id)
        {
            return sve_Prodavnice.FirstOrDefault(p => p.ID == id);
        }
    }
}
