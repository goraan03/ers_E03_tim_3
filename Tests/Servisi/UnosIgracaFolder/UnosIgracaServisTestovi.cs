using Common.Modeli;
using Domain.Repozitorijum.HerojRepozitorijum;
using Moq;
using NUnit.Framework;
using Servisi.UnosIgracaFolder;

namespace Tests.Servisi.UnosIgracaFolder
{
    [TestFixture]
    public class UnosIgracaServisTestovi
    {
        private Mock<IHerojRepozitorijum> _herojRepozitorijumMock;
        private UnosIgracaServis _unosIgracaServis;

        private List<Heroj> _herojiMockLista;

        [SetUp]
        public void Setup()
        {
            _herojiMockLista = new List<Heroj>
            {
                new Heroj("Ezreal", 870, 175, 0),
                new Heroj("Ahri", 900, 135, 0)
            };

            _herojRepozitorijumMock = new Mock<IHerojRepozitorijum>();
            _herojRepozitorijumMock.Setup(x => x.SpisakHeroja()).Returns(_herojiMockLista);
        }

        [Test]
        public void UnosIgraca_IspravanUnos_VracaTrue()
        {
            var rezultat = _unosIgracaServis.UnosIgraca("igrac1", "Ezreal", out Igrac? igrac);

            Assert.That(rezultat, Is.True);
            Assert.That(igrac, Is.Not.Null);
            Assert.That(igrac?.Naziv, Is.EqualTo("igrac1"));
            Assert.That(igrac?.heroj.NazivHeroja, Is.EqualTo("Ezreal"));
        }

        [Test]
        public void UnosIgraca_HerojNePostoji_VracaFalse()
        {
            var rezultat = _unosIgracaServis.UnosIgraca("igrac2", "Zilean", out Igrac? igrac);

            Assert.That(rezultat, Is.False);
            Assert.That(igrac, Is.Null);
        }

        [Test]
        public void UnosIgraca_HerojVecIzabran_VracaFalse()
        {
            var prviPokusaj = _unosIgracaServis.UnosIgraca("igrac1", "Ahri", out Igrac? igrac1);
            Assert.That(prviPokusaj, Is.True);
            Assert.That(igrac1, Is.Not.Null);

            var drugiPokusaj = _unosIgracaServis.UnosIgraca("igrac2", "Ahri", out Igrac? igrac2);
            Assert.That(drugiPokusaj, Is.False);
            Assert.That(igrac2, Is.Null);
        }
    }
}