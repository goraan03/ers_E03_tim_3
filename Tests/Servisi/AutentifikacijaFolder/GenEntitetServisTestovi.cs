using Common.Modeli;
using NUnit.Framework;
using Servisi.GenEntitetFolder;

namespace Tests.Servisi.AutentifikacijaFolder
{
    [TestFixture]
    public class GenEntitetServisTestovi
    {
        private GenEntitetServis _genEntitetServis;

        [SetUp]
        public void Setup()
        {
            _genEntitetServis = new GenEntitetServis();
        }

        [Test]
        public void DodajEntitete_VracaTrue()
        {
            Entitet? generisaniEntitet;

            var rezultat = _genEntitetServis.DodajEntitete(out generisaniEntitet);

            Assert.That(rezultat, Is.True, "Metod dodajEntitete treba da vrati true.");
            Assert.That(generisaniEntitet, Is.Not.Null, "Entitet ne sme biti null.");
            Assert.That(generisaniEntitet?.Poeni, Is.InRange(0, 100), "Poeni treba da budu u opsegu 0-100.");
        }

        [Test]
        public void DodajEntitete_ProveravaInicijalizacijuPoena()
        {
            // Arrange
            Entitet? generisaniEntitet;

            // Act
            _genEntitetServis.DodajEntitete(out generisaniEntitet);

            // Assert
            Assert.That(generisaniEntitet?.Poeni, Is.GreaterThanOrEqualTo(0), "Poeni treba da budu >= 0.");
        }

        [Test]
        public void DodajEntitete_PozivaMetodVisePuta_VracaRazliciteEntitete()
        {
            // Arrange
            Entitet? prviEntitet;
            Entitet? drugiEntitet;

            // Act
            _genEntitetServis.DodajEntitete(out prviEntitet);
            _genEntitetServis.DodajEntitete(out drugiEntitet);

            // Assert
            Assert.That(prviEntitet, Is.Not.SameAs(drugiEntitet), "Svaki poziv metode treba da generiše novi entitet.");
        }
    }
}
