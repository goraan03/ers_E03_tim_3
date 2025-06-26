using Common.Modeli;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class NapiciTest
    {
        [Test]
        [TestCase("Health Potion", 50, 40, 10)]
        [TestCase("Mana Potion", 40, 25, 8)]
        [TestCase("Energy Drink", 30, 23, 5)]
        [TestCase("Shield Potion", 60, 35, 4)]
        public void KonstruktorNapiciOK(string naziv, int cena, int napad, int kolicina)
        {
            Napici napitak = new Napici(naziv, cena, napad, kolicina);

            Assert.That(napitak, Is.Not.Null);
            Assert.That(napitak.Naziv, Is.EqualTo(naziv));
            Assert.That(napitak.Cena, Is.EqualTo(cena));
            Assert.That(napitak.Napad, Is.EqualTo(napad));
            Assert.That(napitak.Kolicina, Is.EqualTo(kolicina));
        }
    }
}
