using Common.Modeli;
using Domain.Servisi;
using Moq;
using NUnit.Framework;
using Servisi.DatotekaPrikazFolder;
using System.Text;

namespace Tests.Servisi.DatotekaPrikazFolder
{
    [TestFixture]
    public class DatotekaPrikazServisTest
    {
        [Test]
        public void IspisFajl_PisanjeUFajl_TrebaDaUpiseOcekivaniSadrzaj()
        {
            var plaviTim = new List<Igrac> { new Igrac("Plavi1", new Heroj("HerojPlavi", 100, 50, 300)) };
            var crveniTim = new List<Igrac> { new Igrac("Crveni1", new Heroj("HerojCrveni", 90, 40, 200)) };
            var mapa = new Mapa("TestMapa", Common.Enumeracije.Tip_Mape.LETNJA, 5, "Plavi", "Crveni", 10);
            int ukPotroseno = 1234;

            var expectedOutput = new StringBuilder();
            expectedOutput.AppendLine("Test sadrzaj iz mocka");

            var mockStatistika = new Mock<IPripremaStatistike>();
            mockStatistika
                .Setup(p => p.PripremaIspis(plaviTim, crveniTim, mapa, ukPotroseno))
                .Returns(expectedOutput);

            var servis = new DatotekaPrikazServis(mockStatistika.Object);

            string filePath = "statistika.txt";
            if (File.Exists(filePath))
                File.Delete(filePath);

            servis.IspisFajl(plaviTim, crveniTim, mapa, ukPotroseno);

            Assert.That(File.Exists(filePath), Is.True);
            string sadrzaj = File.ReadAllText(filePath);
            Assert.That(sadrzaj.Contains("Test sadrzaj iz mocka"));

            File.Delete(filePath);
        }
    }
}
