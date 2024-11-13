using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.HerojRepozitorijum;

namespace Servisi.UnosPlavih
{
    public class UnosPlavih : IUnosPlavih
    {
        private static readonly List<Heroj> ListaHeroja;
        private readonly HashSet<string> ListaIzabranihHeroja = new HashSet<string>();
        private static HerojRepozitorijum heroji = new HerojRepozitorijum();
        static UnosPlavih()
        {
            ListaHeroja = heroji.SpisakHeroja();
        }
        public bool unosPlavih(string nik, string naziv, out Igrac? IzabranIgrac)
        {
            if (ListaIzabranihHeroja.Contains(naziv))
            {
                Console.WriteLine("Ovaj heroj je vec izabran. Pokusajte ponovo.\n");
                IzabranIgrac = null;
                return false;
            }
            Heroj? heroj = ListaHeroja.FirstOrDefault(h => h.NazivHeroja.Equals(naziv));
            if (heroj == null)
            {
                Console.WriteLine("Nepostojeci heroj! Pokusajte ponovo.\n");
                IzabranIgrac = null;
                return false;
            }
            ListaIzabranihHeroja.Add(naziv);
            IzabranIgrac = new Igrac(nik, heroj);
            return true;
        }
    }
}
