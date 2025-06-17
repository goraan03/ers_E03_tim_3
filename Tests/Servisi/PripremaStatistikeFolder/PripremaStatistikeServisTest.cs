using Common.Modeli;
using Common.Servisi;
using Moq;
using NUnit.Framework;
using Servisi.PripremaStatistikeFolder;
using System.Text;

namespace Tests.Servisi.PripremaStatistikeFolder
{
    [TestFixture]
    public class PripremaStatistikeServisTest
    {
        private Mock<IDatotekaPrikaz> _mockDatoteka;
        private Mock<ITabelarniPrikaz> _mockTabelarni;
        private PripremaStatistikeServis _servis;

        [SetUp]
        public void Setup()
        {
            _mockDatoteka = new Mock<IDatotekaPrikaz>();
            _mockTabelarni = new Mock<ITabelarniPrikaz>();

            _servis = new PripremaStatistikeServis(_mockDatoteka.Object, _mockTabelarni.Object);
        }

        [Test]
        public void PripremaIspis_VracaIspravanFormatSaPodacima()
        {
            // Arrange
            var plaviTim = new List<Igrac>
            {
                new Igrac("Plavi1", new Heroj("HerojP1", 100, 30, 200)),
                new Igrac("Plavi2", new Heroj("HerojP2", 90, 25, 150))
            };

            var crveniTim = new List<Igrac>
            {
                new Igrac("Crveni1", new Heroj("HerojC1", 85, 28, 300)),
                new Igrac("Crveni2", new Heroj("HerojC2", 75, 20, 100))
            };

            var mapa = new Mapa("Cosmic Ruins", Common.Enumeracije.Tip_Mape.LETNJA, 10, "PLAVI TIM", "CRVENI TIM", 30);
            int ukupnoPotroseno = 999;

            // Act
            StringBuilder rezultat = _servis.PripremaIspis(plaviTim, crveniTim, mapa, ukupnoPotroseno);

            // Assert
            string ispis = rezultat.ToString();
            Assert.That(ispis.Contains("Ukupan potrosen novac: 999"));
            Assert.That(ispis.Contains("Mapa: Cosmic Ruins"));
            Assert.That(ispis.Contains("PLAVI TIM"));
            Assert.That(ispis.Contains("CRVENI TIM"));
            Assert.That(ispis.Contains("Plavi1"));
            Assert.That(ispis.Contains("Plavi2"));
            Assert.That(ispis.Contains("Crveni1"));
            Assert.That(ispis.Contains("Crveni2"));
            Assert.That(ispis.Contains("HerojP1"));
            Assert.That(ispis.Contains("HerojP2"));
            Assert.That(ispis.Contains("HerojC1"));
            Assert.That(ispis.Contains("HerojC2"));
            Assert.That(ispis.Contains("200"));
        }
    }
}
