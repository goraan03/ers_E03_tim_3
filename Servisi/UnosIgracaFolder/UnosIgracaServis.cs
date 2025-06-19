using Common.Modeli;
using Domain.Repozitorijum.HerojRepozitorijum;
using Domain.Rezultati;
using Domain.Servisi;

namespace Servisi.UnosIgracaFolder
{
    public class UnosIgracaServis : IUnosIgracaServis
    {
        IHerojRepozitorijum _herojRepozitorijum = new HerojRepozitorijum();
        private readonly HashSet<string> _listaIzabranihHeroja = new HashSet<string>();

        public UnosIgracaServis(IHerojRepozitorijum herojRepozitorijum)
        {
            _herojRepozitorijum = herojRepozitorijum;
        }

        public UnosIgracaRezultat UnosIgraca(string nik, string naziv)
        {
            if (_listaIzabranihHeroja.Contains(naziv))
            {
                return UnosIgracaRezultat.Neuspesno($"Heroj '{naziv}' je vec izabran.");
            }

            var heroj = _herojRepozitorijum.SpisakHeroja().FirstOrDefault(h => h.NazivHeroja.Equals(naziv));
            if (heroj == null)
            {
                return UnosIgracaRezultat.Neuspesno($"Heroj '{naziv}' ne postoji.");
            }

            _listaIzabranihHeroja.Add(naziv);
            var igrac = new Igrac(nik, heroj);
            return UnosIgracaRezultat.Uspesno(igrac);
        }
    }
}