using Common.Modeli;
using Common.Servisi;

namespace Presentation.MapaFolderPresentation
{
    public class MapaPresentation
    {
        private readonly IUnosMapeServis _unosMapeServis;

        public MapaPresentation(IUnosMapeServis unosMapeServis)
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

                if (_unosMapeServis.UnosNaziva(nazivMape.Trim(), out izabranaMapa))
                {
                    break;
                }
            }

            return izabranaMapa;
        }
    }
}
