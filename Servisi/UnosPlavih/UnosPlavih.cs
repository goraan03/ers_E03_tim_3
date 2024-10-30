using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeli;
using Common.Servisi;

namespace Servisi.UnosPlavih
{
    public class UnosPlavih : IUnosPlavih
    {
        private static readonly List<Heroj> ListaHeroja;

        static UnosPlavih()
        {
            ListaHeroja = new List<Heroj>
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
        public bool unosPlavih(string nik, string naziv, out Igrac? IzabranIgrac)
        {
            Heroj? heroj = ListaHeroja.FirstOrDefault(h => h.NazivHeroja.Equals(naziv));
            if (heroj == null)
            {
                Console.WriteLine("Nepostojeci heroj! Pokusajte ponovo.\n");
                IzabranIgrac = null;
                return false;
            }
            IzabranIgrac = new Igrac(nik, heroj);
            return true;
        }
    }
}
