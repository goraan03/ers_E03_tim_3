using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.MapeRepozitorijum;

namespace Servisi.UnosMapeFolder
{
    public class UnosMapeServis : IUnosMape
    {
        IMapeRepozitorijum _mapeRepozitorijum = new MapeRepozitorijum();
        public UnosMapeServis()
        {}
        public bool unosNaziva(string naziv, out Mapa? IzabranaMapa)
        {
            Mapa? mapa = _mapeRepozitorijum.SpisakMapa().FirstOrDefault(m => m.NazivMape.Equals(naziv));
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
