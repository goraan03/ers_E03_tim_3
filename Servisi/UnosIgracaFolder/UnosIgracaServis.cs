using Common.Modeli;
using Domain.Repozitorijum.HerojRepozitorijum;
using Domain.Servisi;

namespace Servisi.UnosIgracaFolder
{
    public class UnosIgracaServis : IUnosIgraca
    {
        private static readonly List<Heroj> ListaHeroja;
        private readonly HashSet<string> ListaIzabranihHeroja = new HashSet<string>();
        private static readonly HerojRepozitorijum Heroji = new HerojRepozitorijum();

        static UnosIgracaServis()
        {
            ListaHeroja = Heroji.SpisakHeroja();
        }

        public bool UnosIgraca(string nik, string naziv, out Igrac? IzabranIgrac)
        {
            if (ListaIzabranihHeroja.Contains(naziv))
            {
                Console.WriteLine($"Heroj '{naziv}' je već izabran. Pokušajte ponovo.\n");
                IzabranIgrac = null;
                return false;
            }

            Heroj? heroj = ListaHeroja.FirstOrDefault(h => h.NazivHeroja.Equals(naziv));
            if (heroj == null)
            {
                Console.WriteLine($"Heroj '{naziv}' ne postoji! Pokušajte ponovo.\n");
                IzabranIgrac = null;
                return false;
            }

            ListaIzabranihHeroja.Add(naziv);
            IzabranIgrac = new Igrac(nik, heroj);
            return true;
        }
    }
}