using Common.Modeli;
using NUnit.Framework;
using Servisi.GenEntitetFolder;

namespace Tests.Servisi.GenEntitetFolder
{
    [TestFixture]
    public class GenEntitetServisTest
    {
        private GenEntitetServis _genEntitetServis;

        [SetUp]
        public void Setup()
        {
            _genEntitetServis = new GenEntitetServis();
        }

        [Test]
        public void GeneriseEntitete_VracaTrue_EntitetNijeNull()
        {
            var rezultat = _genEntitetServis.DodajEntitete(out Entitet? entitet);

            Assert.That(rezultat, Is.True);
            Assert.That(entitet, Is.Not.Null);
        }

        [Test]
        public void GeneriseEntitete_ImaValidnePoene()
        {
            var rezultat = _genEntitetServis.DodajEntitete(out Entitet? entitet);

            Assert.That(rezultat, Is.True);
            Assert.That(entitet, Is.Not.Null);
            Assert.That(entitet?.Poeni, Is.GreaterThan(0));
        }

    }
}
