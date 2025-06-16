using Common.Modeli;
using Domain.Repozitorijum.HerojRepozitorijum;
using Moq;
using NUnit.Framework;
using Servisi.IspisHerojaFolder;
using System.Text;

namespace Tests.Servisi.IspisHerojaFolder
{
    [TestFixture]
    public class IspisHerojaServisTests
    {
        private Mock<IHerojRepozitorijum> _herojRepozitorijumMock;
        private IspisHerojaServis _ispisHerojaServis;

        [SetUp]
        public void Setup()
        {
            _herojRepozitorijumMock = new Mock<IHerojRepozitorijum>();
            _ispisHerojaServis = new IspisHerojaServis();
        }

        [Test]
        public void IspisujeSveHerojeIzRepozitorijuma_Tacno()
        {
            // Arrange
            var heroji = new List<Heroj>
            {
                new Heroj("Malphite", 1250, 120, 0),
                new Heroj("Zac", 1100, 95, 0),
                new Heroj("Ahri", 900, 135, 0),
                new Heroj("Ezreal", 870, 175, 0),
                new Heroj("Nami", 780, 120, 0),
                new Heroj("Orn", 1350, 110, 0),
                new Heroj("Elise", 950, 120, 0),
                new Heroj("Yasuo", 900, 160, 0),
                new Heroj("Jhin", 860, 180, 0),
                new Heroj("Blitzcrank", 950, 90, 0)
            };

            _herojRepozitorijumMock.Setup(x => x.SpisakHeroja()).Returns(heroji);

            var rezultat = new StringBuilder();
            for (int i = 0; i < heroji.Count; i++)
            {
                var h = heroji[i];
                rezultat.AppendLine($"Heroj broj {i + 1}: Naziv: {h.NazivHeroja}, Zivotni Poeni: {h.ZivotniPoeni}, Jacina Napada: {h.JacinaNapada}");
            }

            using var sw = new StringWriter();
            Console.SetOut(sw);

            var listaHeroja = _herojRepozitorijumMock.Object.SpisakHeroja();
            _ispisHerojaServis.IspisHeroja(listaHeroja);

            Assert.That(sw.ToString(), Is.EqualTo(rezultat.ToString()));
        }

        [Test]
        public void IspisujePraznuListuHeroja_NeIspisujeNista()
        {
            _herojRepozitorijumMock.Setup(x => x.SpisakHeroja()).Returns(new List<Heroj>());

            using var sw = new StringWriter();
            Console.SetOut(sw);

            var listaHeroja = _herojRepozitorijumMock.Object.SpisakHeroja();
            _ispisHerojaServis.IspisHeroja(listaHeroja);

            Assert.That(sw.ToString(), Is.Empty);
        }
    }
}
