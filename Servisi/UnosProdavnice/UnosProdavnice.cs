using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enumeracije;
using Common.Modeli;
using Common.Servisi;

namespace Servisi.UnosProdavnice
{
    public class UnosProdavnice : IUnosProdavnice
    {
        private static readonly List<Prodavnica> ListaProdavnica;
        static UnosProdavnice()
        {
            ListaProdavnica = new List<Prodavnica>
    {
        new Prodavnica(1, new List<Oruzje>
            {
                new Oruzje("Mace", 100, 20, 5),
                new Oruzje("Sword", 150, 30, 3)
            },
            new List<Napici>
            {
                new Napici("Health Potion", 50, 20, 10),
                new Napici("Mana Potion", 40, 15, 8)
            }),

        new Prodavnica(2, new List<Oruzje>
            {
                new Oruzje("Bow", 120, 25, 7),
                new Oruzje("Dagger", 80, 15, 10)
            },
            new List<Napici>
            {
                new Napici("Energy Drink", 30, 18, 5),
                new Napici("Shield Potion", 60, 25, 4)
            })
    };

        }
        public bool unosProdavnice(int id, out Prodavnica? izabranaProdavnica)
        {
            izabranaProdavnica = ListaProdavnica.FirstOrDefault(p => p.ID == id);
            return izabranaProdavnica != null;
        }

        public int IzracunajUkupnuVrednost(Prodavnica prodavnica)
        {
            return prodavnica.IzracunajUkupnuVrednost();
        }
    }
}
