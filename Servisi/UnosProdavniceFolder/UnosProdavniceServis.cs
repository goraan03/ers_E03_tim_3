using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.ProdavniceRepozitorijum;

namespace Servisi.UnosProdavniceFolder
{
    public class UnosProdavniceServis : IUnosProdavniceServis
    {
        IProdavniceRepozitorijum _prodavniceRepozitorijum = new ProdavniceRepozitorijum();
        public UnosProdavniceServis() { }
        public bool UnosProdavnice(int id, out Prodavnica? izabranaProdavnica)
        {
            izabranaProdavnica = _prodavniceRepozitorijum.SpisakProdavnica().FirstOrDefault(p => p.ID == id);
            return izabranaProdavnica != null;
        }
    }
}
