using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeli;
using NUnit.Framework;

namespace Tests.Domain
{
    [TestFixture]
    public class IgracTest
    {
        [Test]
        [TestCase("d1p0", "Malphite", 1250, 120, 0)]
        [TestCase("randomlija", "Ahri", 900, 135, 0)]
        [TestCase("playerr0002", "Yasuo", 900, 160, 0)]
        public void KonstruktorIgracOK(string nazivIgraca, string nazivHeroja, int zivotniPoeni, int jacinaNapada, int stanjeNovcica)
        {
            Heroj heroj = new Heroj(nazivHeroja, zivotniPoeni, jacinaNapada, stanjeNovcica);

            Igrac igrac = new Igrac(nazivIgraca, heroj);

            Assert.That(igrac, Is.Not.Null);
            Assert.That(igrac.Naziv, Is.EqualTo(nazivIgraca));
            Assert.That(igrac.heroj, Is.Not.Null);
            Assert.That(igrac.heroj.NazivHeroja, Is.EqualTo(nazivHeroja));
            Assert.That(igrac.heroj.ZivotniPoeni, Is.EqualTo(zivotniPoeni));
            Assert.That(igrac.heroj.JacinaNapada, Is.EqualTo(jacinaNapada));
            Assert.That(igrac.heroj.StanjeNovcica, Is.EqualTo(stanjeNovcica));
        }
    }
}
