using Common.Modeli;
using Common.Servisi;
using Servisi.ZlatniNovcic;
using Servisi.Autentifikacija;
using Servisi.UnosMape;
using Servisi.UnosProdavnice;
using Servisi.UnosProdavnice;

namespace ERS_proj_03
{
    public class Program
    {
        public static void Main()
        {
            while(true)
            {
                //promenljive za autentifikaciju
                string? korisnickoIme = "", lozinka = "";
                Korisnik? prijavljen;

                //promenljive za unos mape
                string? nazivMape = "";
                Mapa? IzabranaMapa;
                string plaviTim = "";
                string crveniTim = "";

                //promenljive za unos prodavnice
                int idProdavnice;
                Prodavnica? izabranaProdavnica;

                //servisi
                IAutentifikacija autentifikacija = new Autentifikacija();
                IUnosMape unosMape = new UnosMape();
                IUnosProdavnice unosProdavnice = new UnosProdavnice();

                //autentifikacija
                Console.WriteLine("================ PRIJAVA NALOGA ================");

                while (true)
                {
                    Console.Write("\nKorisnicko Ime: ");
                    korisnickoIme = Console.ReadLine() ?? "";

                    if (!autentifikacija.prijava(korisnickoIme.Trim(), "", out prijavljen))
                    {
                        continue;
                    }

                    break;
                }

                while(true)
                {
                    Console.Write("Lozinka: ");
                    lozinka = Console.ReadLine() ?? "";

                    if (autentifikacija.prijava(korisnickoIme.Trim(), lozinka.Trim(), out prijavljen))
                    {
                        Console.WriteLine("Uspesna prijava! Dobrodosli, " + prijavljen?.ImePrezime);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Netacna lozinka! Pokusajte ponovo.\n");
                    }
                }

                //unos entiteta
                Console.WriteLine("\n================ Unos entiteta ==================\n");

                
                while(true)
                {
                    //unos mape
                    Console.Write("Unesite naziv mape: ");
                    nazivMape = Console.ReadLine() ?? "";

                    if(!unosMape.unosNaziva(nazivMape.Trim(), out IzabranaMapa))
                    {
                        continue;
                    }

                    //unos prodavnice
                    Console.Write("Unesite ID prodavnice: ");
                    while(!int.TryParse(Console.ReadLine(), out idProdavnice) || !unosProdavnice.unosProdavnice(idProdavnice, out izabranaProdavnica))
                    {
                        Console.WriteLine("Nepostojeca prodavnica! Pokusajte ponovo!\n");
                    }
                    Console.WriteLine("\nIzabrali ste prodavnicu:");
                    Console.WriteLine("ID: " + izabranaProdavnica.ID);
                    Console.WriteLine("Vrednost: " + unosProdavnice.IzracunajUkupnuVrednost(izabranaProdavnica)); // Ukupna vrednost
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


                    //unos naziva plavog i crvenog tima
                    Console.Write("\nUnesite naziv plavog tima: ");
                    plaviTim = Console.ReadLine() ?? "";

                    Console.Write("Unesite naziv crvenog tima: ");
                    crveniTim = Console.ReadLine() ?? "";

                    IzabranaMapa.PlaviTim = plaviTim;
                    IzabranaMapa.CrveniTim = crveniTim;

                    //ispis unetih podataka
                    Console.WriteLine("\nUnos uspešan! Mapa: " + IzabranaMapa.NazivMape);
                    Console.WriteLine("Plavi tim: " + IzabranaMapa.PlaviTim + "\nCrveni tim: " + IzabranaMapa.CrveniTim);
                    break;
                }
                break;
            }
        }
    }
}
