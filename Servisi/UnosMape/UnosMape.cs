using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.MapeRepozitorijum;

namespace Servisi.UnosMape
{
    public class UnosMape : IUnosMape
    {
        private List<Mapa> ListaMapa;
        private readonly MapeRepozitorijum _mapeRepozitorijum;
        public UnosMape(MapeRepozitorijum mapeRepozitorijum)
        {
            this._mapeRepozitorijum = mapeRepozitorijum;
            ListaMapa = _mapeRepozitorijum.SpisakMapa();
        }
        public bool unosNaziva(string naziv, out Mapa? IzabranaMapa)
        {
            Mapa? mapa = ListaMapa.FirstOrDefault(m => m.NazivMape.Equals(naziv));
            if (mapa == null)
            {
                Console.WriteLine("Nepostojeca mapa! Pokusajte ponovo.\n");
                IzabranaMapa = null;
                return false;
            }
            IzabranaMapa = mapa;
            return true;
        }
    }
}
