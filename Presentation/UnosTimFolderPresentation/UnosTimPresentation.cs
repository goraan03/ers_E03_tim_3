using Common.Modeli;
using Domain.Servisi;

namespace Presentation.UnosTimFolderPresentation
{
    public class UnosTimPresentation
    {
        public void UnesiIgraceITim(string timNaziv, int brojIgraca, HashSet<string> naziviIgracaPlavi, HashSet<string> naziviIgracaCrveni,  List<Igrac> listaTimova, IUnosIgracaServis unosIgracaServis)
        {
            Console.WriteLine($"\nUnesite nazive igrača i heroje za {timNaziv} tim:\n");

            for (int i = 0; i < brojIgraca; i++)
            {
                string naziv;
                while (true)
                {
                    Console.Write($"Unesite naziv {i + 1}. igrača: ");
                    naziv = Console.ReadLine() ?? "";

                    if (naziviIgracaPlavi.Contains(naziv) || naziviIgracaCrveni.Contains(naziv))
                    {
                        Console.WriteLine("Ovaj naziv igrača je već zauzet! Unesite drugi naziv.\n");
                        continue;
                    }
                    naziviIgracaPlavi.Add(naziv);
                    break;
                }

                string nazivHeroja;
                while (true)
                {
                    Console.Write("Izaberite heroja: ");
                    nazivHeroja = Console.ReadLine() ?? "";

                    if (!unosIgracaServis.UnosIgraca(naziv, nazivHeroja, out Igrac? izabraniIgrac))
                    {
                        continue;
                    }

                    listaTimova.Add(izabraniIgrac);
                    break;
                }
            }
        }
    }
}