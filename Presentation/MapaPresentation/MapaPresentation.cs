using Common.Modeli;
using Common.Servisi;

namespace Presentation
{
    public class MapaPresentation
    {
        private readonly IUnosMape _unosMapeServis;

        public MapaPresentation(IUnosMape unosMapeServis)
        {
            _unosMapeServis = unosMapeServis;
        }

        public Mapa? UnesiMapu()
        {
            Mapa? izabranaMapa = null;

            Console.WriteLine("\n=================== Unos mape =====================\n");

            while (true)
            {
                Console.Write("Unesite naziv mape: ");
                string nazivMape = Console.ReadLine() ?? "";

                if (_unosMapeServis.unosNaziva(nazivMape.Trim(), out izabranaMapa))
                {
                    break;
                }
            }

            return izabranaMapa;
        }
    }
}
