using Common.Modeli;
using NUnit.Framework;
using Servisi.NapadNaEntitetFolder;
using System.Collections.Generic;

namespace Tests.Servisi.NapadNaEntitetFolder
{
    [TestFixture]
    public class NapadNaEntitetServisTest
    {
        [Test]
        public void NapadniEntitet_ObaIgracaNapadaju_DobijajuNovciceIEntitetiSeUklanjaju()
        {
            var igracPlavi = new Igrac("Plavi", new Heroj { ZivotniPoeni = 100, StanjeNovcica = 0 });
            var igracCrveni = new Igrac("Crveni", new Heroj { ZivotniPoeni = 100, StanjeNovcica = 0 });

            var plaviTim = new List<Igrac> { igracPlavi };
            var crveniTim = new List<Igrac> { igracCrveni };

            var ent1 = new Entitet(); ent1.Poeni = 30;
            var ent2 = new Entitet(); ent2.Poeni = 40;
            var ent3 = new Entitet(); ent3.Poeni = 20;
            var entiteti = new List<Entitet> { ent1, ent2, ent3 };

            var servis = new NapadNaEntitetServis();
            int preNapada = entiteti.Count;

            servis.NapadniEntitet(plaviTim, crveniTim, entiteti);

            Assert.That(igracPlavi.heroj.StanjeNovcica, Is.GreaterThan(0));
            Assert.That(igracCrveni.heroj.StanjeNovcica, Is.GreaterThan(0));
            Assert.That(entiteti.Count, Is.EqualTo(preNapada - 2));
        }

        [Test]
        public void NapadniEntitet_EntitetiNePostoje_NistaSeNeMenja()
        {
            var igracPlavi = new Igrac("Plavi", new Heroj { ZivotniPoeni = 100, StanjeNovcica = 0 });
            var igracCrveni = new Igrac("Crveni", new Heroj { ZivotniPoeni = 100, StanjeNovcica = 0 });

            var plaviTim = new List<Igrac> { igracPlavi };
            var crveniTim = new List<Igrac> { igracCrveni };
            var entiteti = new List<Entitet>();

            var servis = new NapadNaEntitetServis();

            servis.NapadniEntitet(plaviTim, crveniTim, entiteti);

            Assert.That(igracPlavi.heroj.StanjeNovcica, Is.EqualTo(0));
            Assert.That(igracCrveni.heroj.StanjeNovcica, Is.EqualTo(0));
            Assert.That(entiteti.Count, Is.EqualTo(0));
        }

        [Test]
        public void NapadniEntitet_JedanIgracBezZivota_SamoDrugiDobijaPoene()
        {
            var igracPlavi = new Igrac("Plavi", new Heroj { ZivotniPoeni = 0, StanjeNovcica = 0 });
            var igracCrveni = new Igrac("Crveni", new Heroj { ZivotniPoeni = 100, StanjeNovcica = 0 });

            var plaviTim = new List<Igrac> { igracPlavi };
            var crveniTim = new List<Igrac> { igracCrveni };

            var ent1 = new Entitet(); ent1.Poeni = 50;
            var ent2 = new Entitet(); ent2.Poeni = 50;
            var entiteti = new List<Entitet> { ent1, ent2 };

            var servis = new NapadNaEntitetServis();
            int preNapada = entiteti.Count;

            servis.NapadniEntitet(plaviTim, crveniTim, entiteti);

            Assert.That(igracPlavi.heroj.StanjeNovcica, Is.EqualTo(0));
            Assert.That(igracCrveni.heroj.StanjeNovcica, Is.GreaterThan(0));
            Assert.That(entiteti.Count, Is.EqualTo(preNapada - 1));
        }
    }
}
