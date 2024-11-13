using Common.Modeli;
using Common.Servisi;
using Domain.PomocneMetode.RacunanjeUkupneVrednosti;

namespace Presentation
{
    public class ProdavnicaPresentation
    {
        private readonly IUnosProdavnice _unosProdavniceServis;

        public ProdavnicaPresentation(IUnosProdavnice unosProdavniceServis)
        {
            _unosProdavniceServis = unosProdavniceServis;
        }

        public Prodavnica? UnesiProdavnicu()
        {
            Prodavnica? izabranaProdavnica = null;
            int idProdavnice;

            Console.WriteLine("\n================ Unos prodavnice ==================\n");
            Console.Write("Unesite ID prodavnice: ");

            // Petlja za unos i validaciju ID prodavnice
            while (!int.TryParse(Console.ReadLine(), out idProdavnice) ||
                   !_unosProdavniceServis.unosProdavnice(idProdavnice, out izabranaProdavnica))
            {
                Console.WriteLine("Nepostojeca prodavnica! Pokusajte ponovo!\n");
                Console.Write("Unesite ID prodavnice: ");
            }

            // Prikaz podataka o prodavnici
            Console.WriteLine("\nIzabrali ste prodavnicu:");
            Console.WriteLine("ID: " + izabranaProdavnica.ID);
            Console.WriteLine("Vrednost: " + RacunanjeUkupneVrednosti.IzracunajUkupnuVrednost(
                izabranaProdavnica.Oruzje, izabranaProdavnica.Napicis));

            Console.WriteLine("Oružja:");
            foreach (var oruzje in izabranaProdavnica.Oruzje)
            {
                Console.WriteLine($"- {oruzje.Naziv}, Cena: {oruzje.Cena}, Napad: {oruzje.Napad}, Količina: {oruzje.Kolicina}");
            }

            Console.WriteLine("Napici:");
            foreach (var napitak in izabranaProdavnica.Napicis)
            {
                Console.WriteLine($"- {napitak.Naziv}, Cena: {napitak.Cena}, Napad: {napitak.Napad}, Količina: {napitak.Kolicina}");
            }

            return izabranaProdavnica;
        }
    }
}
