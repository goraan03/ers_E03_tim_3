using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.ProdavniceRepozitorijum;

namespace Servisi.UnosProdavnice
{
    public class UnosProdavnice : IUnosProdavnice
    {
        private readonly ProdavniceRepozitorijum _prodavniceRepozitorijum;
        public UnosProdavnice(ProdavniceRepozitorijum prodavniceRepozitorijum)
        {
            _prodavniceRepozitorijum = prodavniceRepozitorijum;
        }
        public bool unosProdavnice(int id, out Prodavnica? izabranaProdavnica)
        {
            izabranaProdavnica = _prodavniceRepozitorijum.GetProdavnicaID(id);
            return izabranaProdavnica != null;
        }
    }
}
