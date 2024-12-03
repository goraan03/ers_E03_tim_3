using Common.Modeli;

namespace Domain.Repozitorijum.KorisniciRepozitorijum
{
    public class KorisniciRepozitorijum : IKorisniciRepozitorijum
    {
        private static readonly List<Korisnik> ListaKorisnika;
        static KorisniciRepozitorijum()
        {
            ListaKorisnika = new List<Korisnik>()
            {
                new Korisnik("goran03", "LozinkaGoran", "Goran Grcic"),
                new Korisnik("miroslav03", "LozinkaMiroslav", "Miroslav Dispiter")
            };
        }

        public List<Korisnik> SpisakKorisnika()
        {
            return ListaKorisnika;
        }
    }
}
