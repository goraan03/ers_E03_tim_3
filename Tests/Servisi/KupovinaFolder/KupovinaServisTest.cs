using Common.Modeli;
using Domain.Rezultati;
using NUnit.Framework;
using Servisi.KupovinaFolder;

namespace Tests.Servisi.KupovinaFolder
{
    [TestFixture]
    public class KupovinaServisTests
    {
        private KupovinaServis servis;

        [SetUp]
        public void Setup()
        {
            servis = new KupovinaServis();
        }

        [Test]
        public void ObaviKupovinu_KupujeOruzjeINapitke_IspravneVrednosti()
        {
            var heroj = new Heroj
            {
                JacinaNapada = 10,
                ZivotniPoeni = 20,
                StanjeNovcica = 100
            };

            var igrac = new Igrac
            {
                Naziv = "Marko",
                heroj = heroj
            };

            var oruzje = new List<Oruzje>
            {
                new Oruzje { Naziv = "Mac", Cena = 30, Napad = 5, Kolicina = 1 },
                new Oruzje { Naziv = "Luk", Cena = 40, Napad = 7, Kolicina = 0 }
            };

            var napitci = new List<Napici>
            {
                new Napici { Naziv = "Zeleni napitak", Cena = 20, Napad = 10, Kolicina = 2 }
            };

            var prodavnica = new Prodavnica
            {
                Oruzje = oruzje,
                Napicis = napitci
            };

            KupovinaRezultat rezultat = servis.ObaviKupovinu(igrac, prodavnica);

            Assert.That(oruzje[0].Kolicina, Is.EqualTo(0));
            Assert.That(oruzje[1].Kolicina, Is.EqualTo(0));

            Assert.That(napitci[0].Kolicina, Is.EqualTo(1));

            Assert.That(heroj.JacinaNapada, Is.EqualTo(10 + 5));
            Assert.That(heroj.ZivotniPoeni, Is.EqualTo(20 + 10));

            int ukupnaCena = 30 + 20;
            Assert.That(heroj.StanjeNovcica, Is.EqualTo(100 - ukupnaCena));

            Assert.That(rezultat.Uspeh, Is.True);
            Assert.That(rezultat.UkupnaCena, Is.EqualTo(ukupnaCena));
        }

        [Test]
        public void ObaviKupovinu_NemaDovoljnoKolicine_NistaNeMenja()
        {
            var heroj = new Heroj
            {
                JacinaNapada = 10,
                ZivotniPoeni = 20,
                StanjeNovcica = 100
            };

            var igrac = new Igrac
            {
                Naziv = "Petar",
                heroj = heroj
            };

            var prodavnica = new Prodavnica
            {
                Oruzje = new List<Oruzje>
                {
                    new Oruzje { Naziv = "Mac", Cena = 30, Napad = 5, Kolicina = 0 }
                },
                Napicis = new List<Napici>
                {
                    new Napici { Naziv = "Crveni napitak", Cena = 20, Napad = 10, Kolicina = 0 }
                }
            };

            KupovinaRezultat rezultat = servis.ObaviKupovinu(igrac, prodavnica);

            Assert.That(heroj.JacinaNapada, Is.EqualTo(10));
            Assert.That(heroj.ZivotniPoeni, Is.EqualTo(20));
            Assert.That(heroj.StanjeNovcica, Is.EqualTo(100));

            Assert.That(rezultat.Uspeh, Is.True);
            Assert.That(rezultat.UkupnaCena, Is.EqualTo(0));
        }
    }
}
