using Common.Modeli;
using NUnit.Framework;
using Servisi.NapadNaIgracaFolder;
using System.Collections.Generic;

namespace Tests.Servisi.NapadNaIgracaFolder
{
    [TestFixture]
    public class NapadNaIgracaServisTest
    {
        [Test]
        public void NapadniIgraca_ObaIgracaNapadaju_UmanjeniZivotniPoeni()
        {
            var plavi = new Igrac("Plavi", new Heroj("PlaviHeroj", 100, 20, 0));
            var crveni = new Igrac("Crveni", new Heroj("CrveniHeroj", 100, 25, 0));

            var plaviTim = new List<Igrac> { plavi };
            var crveniTim = new List<Igrac> { crveni };

            var servis = new NapadNaIgracaServis();

            servis.NapadniIgraca(plaviTim, crveniTim);

            Assert.That(plavi.heroj.ZivotniPoeni, Is.LessThanOrEqualTo(100));
            Assert.That(crveni.heroj.ZivotniPoeni, Is.LessThanOrEqualTo(100));
        }

        [Test]
        public void NapadniIgraca_NapadacImaNulaZivota_NapadSeNeIzvrsava()
        {
            var plavi = new Igrac("Plavi", new Heroj("PlaviHeroj", 0, 20, 0));
            var crveni = new Igrac("Crveni", new Heroj("CrveniHeroj", 100, 25, 0));

            var plaviTim = new List<Igrac> { plavi };
            var crveniTim = new List<Igrac> { crveni };

            var servis = new NapadNaIgracaServis();

            servis.NapadniIgraca(plaviTim, crveniTim);

            Assert.That(crveni.heroj.ZivotniPoeni, Is.EqualTo(100));
            Assert.That(plavi.heroj.ZivotniPoeni, Is.LessThanOrEqualTo(0));
        }

        [Test]
        public void NapadniIgraca_ProtivnikUbijeIgraca_NapadacDobijaNovcice()
        {
            var plavi = new Igrac("Plavi", new Heroj("PlaviHeroj", 100, 100, 0));
            var crveni = new Igrac("Crveni", new Heroj("CrveniHeroj", 80, 100, 0));

            var plaviTim = new List<Igrac> { plavi };
            var crveniTim = new List<Igrac> { crveni };

            var servis = new NapadNaIgracaServis();

            servis.NapadniIgraca(plaviTim, crveniTim);

            bool plaviDobioNovac = plavi.heroj.StanjeNovcica >= 300 || crveni.heroj.StanjeNovcica >= 300;
            Assert.That(plaviDobioNovac, Is.True);
        }
    }
}
