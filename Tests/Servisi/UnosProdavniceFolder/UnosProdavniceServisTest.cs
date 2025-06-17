using Common.Modeli;
using NUnit.Framework;
using Servisi.UnosProdavniceFolder;

namespace Tests.Servisi.UnosProdavniceFolder
{
    [TestFixture]
    public class UnosProdavniceServisTest
    {
        private UnosProdavniceServis _servis;

        [SetUp]
        public void SetUp()
        {
            _servis = new UnosProdavniceServis();
        }

        [Test]
        public void UnosPostojeceProdavnice_VracaTrueIVracaProdavnicu()
        {
            int validanId = 1;

            bool rezultat = _servis.UnosProdavnice(validanId, out Prodavnica? prodavnica);

            Assert.That(rezultat, Is.True);
            Assert.That(prodavnica, Is.Not.Null);
            Assert.That(prodavnica?.ID, Is.EqualTo(validanId));
        }

        [Test]
        public void UnosNepostojeceProdavnice_VracaFalseIVracaNull()
        {
            int nepostojeciId = 999;

            bool rezultat = _servis.UnosProdavnice(nepostojeciId, out Prodavnica? prodavnica);

            Assert.That(rezultat, Is.False);
            Assert.That(prodavnica, Is.Null);
        }
    }
}
