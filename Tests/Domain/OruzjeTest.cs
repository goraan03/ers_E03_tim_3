using Common.Modeli;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class OruzjeTest
    {
        [Test]
        [TestCase("Sword", 150, 30, 3)]
        [TestCase("Dagger", 80, 15, 10)]
        [TestCase("Bow", 120, 25, 7)]
        public void KonstruktorOruzjeOK(string naziv, int cena, int napad, int kolicina)
        {
            Oruzje oruzje = new Oruzje(naziv, cena, napad, kolicina);

            Assert.That(oruzje, Is.Not.Null);
            Assert.That(oruzje.Naziv, Is.EqualTo(naziv));
            Assert.That(oruzje.Cena, Is.EqualTo(cena));
            Assert.That(oruzje.Napad, Is.EqualTo(napad));
            Assert.That(oruzje.Kolicina, Is.EqualTo(kolicina));
        }
    }
}
