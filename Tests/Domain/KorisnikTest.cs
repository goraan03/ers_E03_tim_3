using Common.Modeli;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Domain
{
    [TestFixture]
    public class KorisnikTest
    {
        [Test]
        [TestCase("goran03", "LozinkaGoran", "Goran Grcic")]
        [TestCase("miroslav03", "LozinkaMiroslav", "Miroslav Dispiter")]

        public void KonstruktorKorisnikOK(string korisnickoIme, string lozinka, string imePrezime)
        {
            Korisnik korisnik = new(korisnickoIme, lozinka, imePrezime);

            Assert.That(korisnik, Is.Not.Null);
            Assert.That(korisnik.KorisnickoIme, Is.EqualTo(korisnickoIme));
            Assert.That(korisnik.Lozinka, Is.EqualTo(lozinka));
            Assert.That(korisnik.ImePrezime, Is.EqualTo(imePrezime));

            // ne znam dal treba dodati za prazne i null vrednosti? + jel treba konstruktor bez parametara?
        }
    }
}
