using Common.Modeli;
using NUnit.Framework;
using Servisi.KupovinaFolder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tests.Servisi.KupovinaFolder
{
    [TestFixture]
    public class KupovinaServisTests
    {
        private KupovinaServis _kupovinaServis;
        private Igrac _igrac;
        private Prodavnica _prodavnica;
        private List<Oruzje> _oruzja;
        private List<Napici> _napici;

        [SetUp]
        public void Setup()
        {
            _kupovinaServis = new KupovinaServis();

            var heroj = new Heroj("Ahri", 900, 100, 300);
            _igrac = new Igrac("miroslav", heroj);

            _oruzja = new List<Oruzje>
            {
                new Oruzje { Naziv = "Mac", Napad = 20, Cena = 50, Kolicina = 1 },
                new Oruzje { Naziv = "Luk", Napad = 15, Cena = 30, Kolicina = 0 }
            };

            _napici = new List<Napici>
            {
                new Napici { Naziv = "Potion", Napad = 10, Cena = 20, Kolicina = 2 }
            };

            _prodavnica = new Prodavnica
            {
                Oruzje = _oruzja,
                Napicis = _napici
            };
        }

        [Test]
        public void ObaviKupovinu_RadiIspravnoSaIEnumerable()
        {
            _kupovinaServis.ObaviKupovinu(_igrac, _prodavnica, out int ukupnaCena);

            Assert.That(ukupnaCena, Is.EqualTo(70));

            Assert.That(_igrac.heroj.JacinaNapada, Is.EqualTo(100 + 20));
            Assert.That(_igrac.heroj.ZivotniPoeni, Is.EqualTo(900 + 10));
            Assert.That(_igrac.heroj.StanjeNovcica, Is.EqualTo(300 - 70));

            Assert.That(_oruzja.First(o => o.Naziv == "Mac").Kolicina, Is.EqualTo(0));
            Assert.That(_napici.First(n => n.Naziv == "Potion").Kolicina, Is.EqualTo(1));
        }

        [Test]
        public void ObaviKupovinu_SaPraznimProdavnicama_VracaUkupnoNula()
        {
            _prodavnica = new Prodavnica
            {
                Oruzje = new List<Oruzje>(), 
                Napicis = new List<Napici>()
            };

            _kupovinaServis.ObaviKupovinu(_igrac, _prodavnica, out int ukupnaCena);

            Assert.That(ukupnaCena, Is.EqualTo(0));
            Assert.That(_igrac.heroj.JacinaNapada, Is.EqualTo(100));
            Assert.That(_igrac.heroj.ZivotniPoeni, Is.EqualTo(900));
            Assert.That(_igrac.heroj.StanjeNovcica, Is.EqualTo(300));
        }

        [Test]
        public void ObaviKupovinu_ConsoleOutputSadrziKupovine()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            _kupovinaServis.ObaviKupovinu(_igrac, _prodavnica, out _);

            var output = sw.ToString();
            Assert.That(output, Does.Contain("kupio oruzje: Mac"));
            Assert.That(output, Does.Contain("kupio napitak: Potion"));
        }
    }
}
