using Common.Modeli;
using Domain.Repozitorijum.HerojRepozitorijum;
using Moq;
using NUnit.Framework;
using Servisi.UnosIgracaFolder;

namespace Tests.Servisi.UnosIgracaFolder
{
    [TestFixture]
    public class UnosIgracaServisTest
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

            _unosIgracaServis = new UnosIgracaServis(_herojRepozitorijumMock.Object);
        }

        [Test]
        public void UnosIgraca_IspravanUnos_VracaUspesanRezultat()
        {
            var rezultat = _unosIgracaServis.UnosIgraca("igrac1", "Ezreal");

            Assert.That(rezultat.Uspeh, Is.True);
            Assert.That(rezultat.Igrac, Is.Not.Null);
            Assert.That(rezultat.Igrac?.Naziv, Is.EqualTo("igrac1"));
            Assert.That(rezultat.Igrac?.heroj.NazivHeroja, Is.EqualTo("Ezreal"));
        }

        [Test]
        public void UnosIgraca_HerojNePostoji_VracaNeuspeh()
        {
            var rezultat = _unosIgracaServis.UnosIgraca("igrac2", "Zilean");

            Assert.That(rezultat.Uspeh, Is.False);
            Assert.That(rezultat.Igrac, Is.Null);
            Assert.That(rezultat.Poruka, Is.EqualTo("Heroj 'Zilean' ne postoji."));
        }

        [Test]
        public void UnosIgraca_HerojVecIzabran_VracaNeuspeh()
        {
            var prviPokusaj = _unosIgracaServis.UnosIgraca("igrac1", "Ahri");
            Assert.That(prviPokusaj.Uspeh, Is.True);
            Assert.That(prviPokusaj.Igrac, Is.Not.Null);

            var drugiPokusaj = _unosIgracaServis.UnosIgraca("igrac2", "Ahri");
            Assert.That(drugiPokusaj.Uspeh, Is.False);
            Assert.That(drugiPokusaj.Igrac, Is.Null);
            Assert.That(drugiPokusaj.Poruka, Is.EqualTo("Heroj 'Ahri' je vec izabran."));
        }
    }
}
