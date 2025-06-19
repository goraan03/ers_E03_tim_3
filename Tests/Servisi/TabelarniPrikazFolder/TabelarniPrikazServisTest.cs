using Common.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Servisi.TabelarniPrikazFolder;
using System.Text;

namespace Tests.Servisi.TabelarniPrikazFolder
{
    [TestFixture]
    public class TabelarniPrikazServisTest
    {
        [Test]
        public void ispisTabele_IspisujeOcekivaniTekstNaKonzolu()
        {
            var plaviTim = new List<Igrac>
            {
                new Igrac("Plavi1", new Heroj("HerojPlavi", 100, 50, 300))
            };

            var crveniTim = new List<Igrac>
            {
                new Igrac("Crveni1", new Heroj("HerojCrveni", 90, 40, 200))
            };

            var mapa = new Mapa("TestMapa", Common.Enumeracije.Tip_Mape.LETNJA, 5, "Plavi", "Crveni", 10);
            int ukPotroseno = 1234;

            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Test output iz mocka");

            var mockPriprema = new Mock<IPripremaStatistikeServis>();
            mockPriprema
                .Setup(p => p.PripremaIspis(plaviTim, crveniTim, mapa, ukPotroseno))
                .Returns(expectedOutput);

            var servis = new TabelarniPrikazServis(mockPriprema.Object);

            using var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);


            servis.ispisTabele(plaviTim, crveniTim, mapa, ukPotroseno);

            var konzolniOutput = stringWriter.ToString();
            Assert.That(konzolniOutput.Contains("Test output iz mocka"), Is.True);
        }
    }
}
