using Common.Modeli;

namespace Presentation
{
    public class BrojIgracaPresentation
    {
        public void UnesiBrojIgraca(out int brPlaviTim, out int brCrveniTim, Mapa izabranaMapa)
        {
            brPlaviTim = 0;
            brCrveniTim = 0;

            while (true)
            {
                try
                {
                    Console.Write("\nUnesite broj igraca za plavi tim: ");
                    brPlaviTim = int.Parse(Console.ReadLine());

                    Console.Write("Unesite broj igraca za crveni tim: ");
                    brCrveniTim = int.Parse(Console.ReadLine());

                    if (brPlaviTim + brCrveniTim > izabranaMapa.MaxIgraca)
                    {
                        Console.WriteLine("\nPrevise igraca. Odaberite drugi broj.\n");
                        continue;
                    }

                    // Dodeljujemo broj igrača u mapu
                    izabranaMapa.MaxIgraca = brPlaviTim + brCrveniTim; // Možeš i ovako, ako želiš da dodeliš ukupno broj igrača.

                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Doslo je do greske: " + e.Message);
                }
            }
        }
    }
}
