using Common.Modeli;

namespace Presentation.ImenaTimovaFolderPresentation
{
    public class ImenaTimovaPresentation
    {
        public void UnesiTimove(out string plaviTim, out string crveniTim, Mapa izabranaMapa)
        {
            plaviTim = string.Empty;
            crveniTim = string.Empty;

            // Unos plavog tima
            Console.WriteLine("\n================== Unos timova ====================\n");
            Console.Write("Unesite naziv plavog tima: ");
            plaviTim = Console.ReadLine() ?? "";

            // Unos crvenog tima
            Console.Write("Unesite naziv crvenog tima: ");
            crveniTim = Console.ReadLine() ?? "";

            while (crveniTim.Equals(plaviTim))
            {
                Console.Write("Taj naziv je vec zauzet. Pokusajte ponovo: \n");
                crveniTim = Console.ReadLine() ?? "";
            }

            izabranaMapa.PlaviTim = plaviTim;
            izabranaMapa.CrveniTim = crveniTim;
        }
    }
}
