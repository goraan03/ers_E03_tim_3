using Common.Modeli;
using Common.Servisi;

namespace Presentation.AutentifikacijaFolderPresentation
{
    public class AutentifikacijaPresentation
    {
        private readonly IAutentifikacija _autentifikacija;

        public AutentifikacijaPresentation(IAutentifikacija autentifikacija)
        {
            _autentifikacija = autentifikacija;
        }

        public Korisnik? Prijava()
        {
            string korisnickoIme, lozinka;
            Korisnik? prijavljen = null;
            Console.WriteLine("================= PRIJAVA NALOGA ==================");

            while (true)
            {
                Console.Write("\nKorisnicko Ime: ");
                korisnickoIme = Console.ReadLine()?.Trim() ?? "";

                Console.Write("Lozinka: ");
                lozinka = UnosLozinke();

                if (_autentifikacija.Prijava(korisnickoIme, lozinka, out prijavljen))
                {
                    Console.WriteLine("\nUspesna prijava!");
                    break;
                }
            }

            if (prijavljen != null)
            {
                Console.WriteLine($"Dobrodošli, {prijavljen.ImePrezime}!");
            }

            return prijavljen;
        }

        private static string UnosLozinke()
        {
            var sb = new System.Text.StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true); // true sakriva unos sa ekrana
                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    sb.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    Console.Write("\b \b"); // Brise poslednji karakter sa ekrana
                }
            } while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return sb.ToString();
        }
    }
}
