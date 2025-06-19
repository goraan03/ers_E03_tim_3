using Common.Modeli;
using Domain.Repozitorijum.HerojRepozitorijum;
using Domain.Servisi;

namespace Servisi.UnosIgracaFolder
{
    public class UnosIgracaServis : IUnosIgracaServis
    {
        IHerojRepozitorijum _herojRepozitorijum = new HerojRepozitorijum();
        private readonly HashSet<string> ListaIzabranihHeroja = new HashSet<string>();

        static UnosIgracaServis() {}

        public bool UnosIgraca(string nik, string naziv, out Igrac? IzabranIgrac)
        {
            if (ListaIzabranihHeroja.Contains(naziv))
            {
                //Console.WriteLine($"Heroj '{naziv}' je vec izabran. Pokusajte ponovo.\n");
                IzabranIgrac = null;
                return false;
            }

            Heroj? heroj = _herojRepozitorijum.SpisakHeroja().FirstOrDefault(h => h.NazivHeroja.Equals(naziv));
            if (heroj == null)
            {
                //Console.WriteLine($"Heroj '{naziv}' ne postoji! Pokusajte ponovo.\n");
                IzabranIgrac = null;
                return false;
            }

            ListaIzabranihHeroja.Add(naziv);
            IzabranIgrac = new Igrac(nik, heroj);
            return true;
        }
    }
}