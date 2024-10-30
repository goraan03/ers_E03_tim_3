using Common.Modeli;
using Common.Servisi;
using Servisi.ZlatniNovcic;
using Servisi.Autentifikacija;
using Servisi.UnosMape;

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

                //servisi
                IAutentifikacija autentifikacija = new Autentifikacija();
                IUnosMape unosMape = new UnosMape();

                //autentifikacija
                Console.WriteLine("================ PRIJAVA NALOGA ================");

                while (true)
                {
                    Console.Write("\nKorisnicko Ime: ");
                    korisnickoIme = Console.ReadLine() ?? "";

                    if (!autentifikacija.Prijava(korisnickoIme.Trim(), "", out prijavljen))
                    {
                        continue;
                    }

                    break;
                }

                while(true)
                {
                    Console.Write("Lozinka: ");
                    lozinka = Console.ReadLine() ?? "";

                    if (autentifikacija.Prijava(korisnickoIme.Trim(), lozinka.Trim(), out prijavljen))
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
                Console.WriteLine("\n================ Unos entiteta ================\n");

                
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

                    //unos naziva plavog i crvenog tima
                    Console.Write("Unesite naziv plavog tima: ");
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
