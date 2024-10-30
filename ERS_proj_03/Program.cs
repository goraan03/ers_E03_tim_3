using Common.Modeli;
using Common.Servisi;
using Servisi.ZlatniNovcic;
using Servisi.Autentifikacija;
using Servisi.UnosMape;
using Servisi.UnosProdavnice;
using Servisi.UnosCrvenih;
using Servisi.UnosPlavih;

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

                //promenljive za unos timova
                int brPlaviTim;
                int brCrveniTim;
                int brPlavi = 0;
                int brCrveni = 0;
                List<Igrac> ListaPlavih = new List<Igrac> ();
                List<Igrac> ListaCrvenih = new List<Igrac>();
                Igrac? izabraniIgrac;

                //servisi
                IAutentifikacija autentifikacija = new Autentifikacija();
                IUnosMape unosMape = new UnosMape();
                IUnosProdavnice unosProdavnice = new UnosProdavnice();
                IUnosCrvenih unosCrvenih = new UnosCrvenih();
                IUnosPlavih unosPlavih = new UnosPlavih();


                //autentifikacija
                Console.WriteLine("================ PRIJAVA NALOGA ================");

                while (true)
                {
                    Console.Write("\nKorisnicko Ime: ");
                    korisnickoIme = Console.ReadLine() ?? "";

                    Console.Write("Lozinka: ");
                    lozinka = Console.ReadLine() ?? "";

                    if (!autentifikacija.Prijava(korisnickoIme.Trim(), lozinka, out prijavljen))
                    {
                        continue;
                    }
                    break;
                }

                while(true)
                {
                    if (autentifikacija.Prijava(korisnickoIme.Trim(), lozinka.Trim(), out prijavljen))
                    {
                        Console.WriteLine("Uspesna prijava! Dobrodosli, " + prijavljen?.ImePrezime);
                        break;
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(lozinka))
                        {
                            Console.WriteLine("Lozinka ne moze biti prazna. Pokusajte ponovo!\n");
                        }
                        else
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

                    //unos igraca u crveni i plavi tim
                    while(true)
                    {
                        Console.Write("Unesite broj igraca za plavi tim: ");
                        brPlaviTim = int.Parse(Console.ReadLine());
                        Console.Write("Unesite broj igraca za crveni tim: ");
                        brCrveniTim = int.Parse(Console.ReadLine());
                        if(brPlaviTim + brCrveniTim > IzabranaMapa.MaxIgraca)
                        {
                            Console.WriteLine("\nPrevise igraca. Odaberite drugi broj.\n");
                            continue;
                        }
                        break;
                    }
                    
                    //unos plavog tima
                    Console.WriteLine("\nUnesite nazive igraca plavog tima:\n");
                    for(int i=0;i<brPlaviTim;i++)
                    {
                        Console.Write("Unesite naziv igraca: ");
                        string naziv;
                        naziv = Console.ReadLine() ?? "";
                        string nazivHeroja;
                        while(true)
                        {
                            Console.Write("Unesite naziv heroja: ");
                            nazivHeroja = Console.ReadLine() ?? "";
                            if (!unosPlavih.unosPlavih(naziv, nazivHeroja, out izabraniIgrac))
                            {
                                ListaPlavih.Add(izabraniIgrac);
                                continue;
                            }
                        break;
                        }
                    }


                    //unos crvenog tima
                    Console.WriteLine("\nUnesite nazive igraca crvenog tima:\n");
                    for (int i = 0; i < brCrveniTim; i++)
                    {
                        Console.Write("Unesite naziv igraca: ");
                        string naziv;
                        naziv = Console.ReadLine() ?? "";
                        string nazivHeroja;
                        while (true)
                        {
                            Console.Write("Unesite naziv heroja: ");
                            nazivHeroja = Console.ReadLine() ?? "";
                            if (!unosCrvenih.unosCrvenih(naziv, nazivHeroja, out izabraniIgrac))
                            {
                                ListaCrvenih.Add(izabraniIgrac);
                                continue;
                            }
                            break;
                        }
                    }

                    Console.WriteLine("\nPlavi tim:\n");

                    foreach (Igrac i in ListaPlavih)
                    {
                        Console.WriteLine("Igrac: " +  i.Naziv);
                        Console.WriteLine("Heroj: " + i.heroj.NazivHeroja);
                    }

                    Console.WriteLine("\nCrveni tim:\n");

                    foreach (Igrac i in ListaCrvenih)
                    {
                        Console.WriteLine("Igrac: " + i.Naziv);
                        Console.WriteLine("Heroj: " + i.heroj.NazivHeroja);
                    }


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