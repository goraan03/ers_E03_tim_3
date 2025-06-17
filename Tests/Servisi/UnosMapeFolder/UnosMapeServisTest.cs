using Common.Modeli;
using NUnit.Framework;
using Servisi.UnosMapeFolder;

namespace Tests.Servisi.UnosMapeFolder
{
    [TestFixture]
    public class UnosMapeServisTestBezMocka
    {
        private UnosMapeServis _unosMapeServis;

        [SetUp]
        public void Setup()
        {
            _unosMapeServis = new UnosMapeServis();
        }

        [Test]
        public void UnosPostojeceMape_VracaTrue()
        {
            var rezultat = _unosMapeServis.UnosNaziva("Cosmic Ruins", out Mapa? izabranaMapa);

            Assert.That(rezultat, Is.True);
            Assert.That(izabranaMapa, Is.Not.Null);
            Assert.That(izabranaMapa?.NazivMape, Is.EqualTo("Cosmic Ruins"));
        }

        [Test]
        public void UnosNepostojeceMape_VracaFalse()
        {
            var rezultat = _unosMapeServis.UnosNaziva("MapaKojaNePostoji", out Mapa? izabranaMapa);

            Assert.That(rezultat, Is.False);
            Assert.That(izabranaMapa, Is.Null);
        }

    }
}
