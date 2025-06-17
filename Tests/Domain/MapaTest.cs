using Common.Enumeracije;
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
    public class MapaTest
    {
        [Test]
        [TestCase("Crash Site", Tip_Mape.ZIMSKA, 8, "Partizan", "Zvezda", 30)]
        [TestCase("Cosmic Ruins", Tip_Mape.LETNJA, 10, "Team Blue", "Team Red", 30)]
        [TestCase("Crash Site", Tip_Mape.LETNJA, 6, "Plavi Tim", "Crveni Tim", 25)]
        public void KonstruktorMapaOK(string nazivMape, Tip_Mape tipMape, int maxIgraca, string plaviTim, string crveniTim, int pomocniEntiteti)
        {
            Mapa mapa = new Mapa(nazivMape, tipMape, maxIgraca, plaviTim, crveniTim, pomocniEntiteti);

            Assert.That(mapa, Is.Not.Null);
            Assert.That(mapa.NazivMape, Is.EqualTo(nazivMape));
            Assert.That(mapa.TipMape, Is.EqualTo(tipMape));
            Assert.That(mapa.MaxIgraca, Is.EqualTo(maxIgraca));
            Assert.That(mapa.PlaviTim, Is.EqualTo(plaviTim));
            Assert.That(mapa.CrveniTim, Is.EqualTo(crveniTim));
            Assert.That(mapa.PomocniEntiteti, Is.EqualTo(pomocniEntiteti));
        }
    }
}
