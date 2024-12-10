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

    public class HerojTestovi
    {
        [Test]
        [TestCase("Malphite", 1250, 120, 0)]
        [TestCase("Zac", 1100, 95, 0)]
        [TestCase("Ahri", 900, 135, 0)]
        [TestCase("Ezreal", 870, 175, 0)]
        [TestCase("Nami", 780, 120, 0)]
        [TestCase("Orn", 1350, 110, 0)]
        [TestCase("Elise", 950, 120, 0)]
        [TestCase("Yasuo", 900, 160, 0)]
        [TestCase("Jhin", 860, 180, 0)]
        [TestCase("Blitzcrank", 950, 90, 0)]

        public void KonstruktorHerojOK(string nazivHeroja, int zivotniPoeni, int jacinaNapada, int stanjeNovcica)
        {
            Heroj heroj = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, stanjeNovcica);

            Assert.That(heroj, Is.Not.Null);
            Assert.That(heroj.NazivHeroja, Is.EqualTo(nazivHeroja));
            Assert.That(heroj.ZivotniPoeni, Is.EqualTo(zivotniPoeni));
            Assert.That(heroj.JacinaNapada, Is.EqualTo(jacinaNapada));
            Assert.That(heroj.StanjeNovcica, Is.EqualTo(stanjeNovcica));
        }
    }
}
