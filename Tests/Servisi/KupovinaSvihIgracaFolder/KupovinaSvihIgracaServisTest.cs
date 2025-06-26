using Common.Modeli;
using NUnit.Framework;
using Servisi.KupovinaSvihIgracaFolder;

namespace Tests.Servisi.KupovinaSvihIgracaFolder
{
    [TestFixture]
    public class KupovinaSvihIgracaServisTest
    {
        private KupovinaSvihIgracaServis _servis;
        private Prodavnica _prodavnica;

        [SetUp]
        public void SetUp()
        {
            _servis = new KupovinaSvihIgracaServis();

            _prodavnica = new Prodavnica(1,
                new List<Oruzje> { new Oruzje("Mace", 100, 20, 1) },
                new List<Napici> { new Napici("Potion", 50, 10, 1) }
            );
        }

        [Test]
        public void KupovinaSvih_SamoJedanIgracImaDovoljnoNovca_VracaPravuVrednost()
        {
            var igrac1 = new Igrac("Igrac1", new Heroj { StanjeNovcica = 600 });
            var igrac2 = new Igrac("Igrac2", new Heroj { StanjeNovcica = 400 });

            var plaviTim = new List<Igrac> { igrac1 };
            var crveniTim = new List<Igrac> { igrac2 };

            int ukPotroseno = _servis.KupovinaSvih(plaviTim, crveniTim, _prodavnica);

            Assert.That(ukPotroseno, Is.EqualTo(150));
            Assert.That(_servis.getTotal(), Is.EqualTo(150));

            Assert.That(igrac1.heroj.StanjeNovcica, Is.EqualTo(600 - 150));
            Assert.That(igrac2.heroj.StanjeNovcica, Is.EqualTo(400));
        }

        [Test]
        public void KupovinaSvih_NijedanIgracNemaDovoljnoNovca_NistaSeNeDesava()
        {
            var igrac1 = new Igrac("Igrac1", new Heroj { StanjeNovcica = 100 });
            var igrac2 = new Igrac("Igrac2", new Heroj { StanjeNovcica = 300 });

            var plaviTim = new List<Igrac> { igrac1 };
            var crveniTim = new List<Igrac> { igrac2 };

            int ukPotroseno = _servis.KupovinaSvih(plaviTim, crveniTim, _prodavnica);

            Assert.That(ukPotroseno, Is.EqualTo(0));
            Assert.That(_servis.getTotal(), Is.EqualTo(0));
            Assert.That(igrac1.heroj.StanjeNovcica, Is.EqualTo(100));
            Assert.That(igrac2.heroj.StanjeNovcica, Is.EqualTo(300));
        }
    }
}
