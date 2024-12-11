using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.KorisniciRepozitorijum;
using Moq;
using NUnit.Framework;
using Servisi.AutentifikacijaFolder;

namespace Tests.Servisi.AutentifikacijaFolder
{
    [TestFixture]
    public class AutentifikacijaServisTests
    {
        public Mock<IKorisniciRepozitorijum> _korisniciRepozitorijumMock;

        private AutentifikacijaServis _autentifikacijaServis;

        [SetUp]
        public void Setup()
        {
            _korisniciRepozitorijumMock = new Mock<IKorisniciRepozitorijum>();
            _autentifikacijaServis = new AutentifikacijaServis();
        }

        [Test]
        [TestCase("goran03", "LozinkaGoran")]
        public void PrijavaSaIspravnimPodacima_VracaTrue(string korisnickoIme, string lozinka)
        {
            var korisnik = new Korisnik(korisnickoIme, lozinka, "Goran Grcic");
            _korisniciRepozitorijumMock.Setup(x => x.SpisakKorisnika()).Returns(new List<Korisnik> { korisnik });

            var rezultat = _autentifikacijaServis.Prijava(korisnickoIme, lozinka, out var prijavljen);

            Assert.That(rezultat, Is.True);
            Assert.That(prijavljen, Is.Not.Null);
            Assert.That(prijavljen?.KorisnickoIme, Is.EqualTo(korisnickoIme));
            Assert.That(prijavljen?.Lozinka, Is.EqualTo(lozinka));
        }

        [Test]
        [TestCase("nepostojeci", "Lozinka123")]
        public void PrijavaSaNepostojecomKorisnickimImenom_VracaFalse(string korisnickoIme, string lozinka)
        {
            _korisniciRepozitorijumMock.Setup(x => x.SpisakKorisnika()).Returns(new List<Korisnik>());

            var rezultat = _autentifikacijaServis.Prijava(korisnickoIme, lozinka, out var prijavljen);

            Assert.That(rezultat, Is.False);
            Assert.That(prijavljen, Is.Null);
        }

        [Test]
        [TestCase("goran03", "PogresnaLozinka")]
        public void PrijavaSaPogresnomLozinkom_VracaFalse(string korisnickoIme, string lozinka)
        {
            var korisnik = new Korisnik("goran03", "LozinkaGoran", "Goran Grcic");
            _korisniciRepozitorijumMock.Setup(x => x.SpisakKorisnika()).Returns(new List<Korisnik> { korisnik });

            var rezultat = _autentifikacijaServis.Prijava(korisnickoIme, lozinka, out var prijavljen);

            Assert.That(rezultat, Is.False);
            Assert.That(prijavljen, Is.Null);
        }
    }
}
