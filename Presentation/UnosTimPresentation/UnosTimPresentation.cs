using Common.Modeli;
using Common.Servisi;

namespace Presentation
{
    public class UnosTimPresentation
    {
        public void UnesiIgraceITim(string timNaziv, int brojIgraca, HashSet<string> naziviIgraca, List<Igrac> listaTimova, object unosInterfejs)
        {
            Console.WriteLine($"\nUnesite nazive igraca i heroje za {timNaziv} tim:\n");

            for (int i = 0; i < brojIgraca; i++)
            {
                string naziv;
                while (true)
                {
                    Console.Write("Unesite naziv " + (i + 1) + ". igraca: ");
                    naziv = Console.ReadLine() ?? "";

                    if (naziviIgraca.Contains(naziv))
                    {
                        Console.WriteLine("Ovaj naziv igraca je vec zauzet! Unesite drugi naziv.\n");
                        continue;
                    }
                    naziviIgraca.Add(naziv);
                    break;
                }

                string nazivHeroja;
                while (true)
                {
                    Console.Write("Izaberite heroja: ");
                    nazivHeroja = Console.ReadLine() ?? "";

                    // Koristimo odgovarajući interfejs za unos heroja
                    if (unosInterfejs is IUnosPlavih unosPlavih)
                    {
                        if (!unosPlavih.unosPlavih(naziv, nazivHeroja, out Igrac izabraniIgrac))
                        {
                            continue;
                        }
                        listaTimova.Add(izabraniIgrac);
                        break;
                    }
                    else if (unosInterfejs is IUnosCrvenih unosCrvenih)
                    {
                        if (!unosCrvenih.unosCrvenih(naziv, nazivHeroja, out Igrac izabraniIgrac))
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
}
