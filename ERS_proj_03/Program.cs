using Common.Modeli;
using Common.Servisi;
using Servisi.ZlatniNovcic;
using Servisi.Autentifikacija;
using Servisi.UnosMape;
using Servisi.UnosProdavnice;
using Servisi.UnosCrvenih;
using Servisi.UnosPlavih;
using Servisi.GenEntitet;
using Servisi.NapadNaEntitet;
using Servisi.Kupovina;

namespace ERS_proj_03
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                //promenljive za autentifikaciju
                string? korisnickoIme = "", lozinka = "";
                Korisnik? prijavljen;

                //promenljive za unos entiteta
                int brEntitet = 0;
                Entitet? GenerisaniEnt;
                List<Entitet> listaEntiteta = new List<Entitet>();

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
                List<Igrac> ListaPlavih = new List<Igrac>();
                List<Igrac> ListaCrvenih = new List<Igrac>();
                Igrac? izabraniIgrac;

                //promenljive za simulaciju bitke
                int k = 0;
                int l = 0;

                //servisi
                IAutentifikacija autentifikacija = new Autentifikacija();
                IUnosMape unosMape = new UnosMape();
                IUnosProdavnice unosProdavnice = new UnosProdavnice();
                IUnosCrvenih unosCrvenih = new UnosCrvenih();
                IUnosPlavih unosPlavih = new UnosPlavih();
                IGenEntitet genEntiteta = new GenEntitet();
                INapadNaIgraca napadniIgraca = new NapadNaIgraca();
                INapadNaEntitet napadniEntitet = new NapadNaEntitet();
                IKupovina kupovinaArtikala = new Kupovina();


                //autentifikacija
                Console.WriteLine("================= PRIJAVA NALOGA ==================");

                while (true)
                {
                    Console.Write("\nKorisnicko Ime: ");
                    korisnickoIme = Console.ReadLine() ?? "";

                    Console.Write("Lozinka: ");
                    lozinka = UnosLozinke();

                    if (!autentifikacija.Prijava(korisnickoIme.Trim(), lozinka, out prijavljen))
                    {
                        continue;
                    }
                    break;
                }

                while (true)
                {
                    if (autentifikacija.Prijava(korisnickoIme.Trim(), lozinka.Trim(), out prijavljen))
                    {
                        Console.WriteLine("Uspesna prijava! Dobrodosli, " + prijavljen?.ImePrezime);
                        break;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(lozinka))
                        {
                            Console.WriteLine("Lozinka ne moze biti prazna. Pokusajte ponovo!\n");
                        }
                        else
                            Console.WriteLine("Netacna lozinka! Pokusajte ponovo.\n");
                    }
                }

                static string UnosLozinke()
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

                //unos entiteta
                Console.WriteLine("\n================= Unos entiteta ===================\n");

                Console.Write("Unesite broj entiteta: ");
                brEntitet = int.Parse(Console.ReadLine());

                //unos mape
                Console.WriteLine("\n=================== Unos mape =====================\n");
                while (true)
                {
                    Console.Write("Unesite naziv mape: ");
                    nazivMape = Console.ReadLine() ?? "";

                    if (!unosMape.unosNaziva(nazivMape.Trim(), out IzabranaMapa))
                    {
                        continue;
                    }
                    break;
                }

                //provera broja entiteta na mapi
                if (brEntitet > IzabranaMapa.PomocniEntiteti)
                {
                    brEntitet = IzabranaMapa.PomocniEntiteti;
                }

                //generisanje broja poena za entitete
                while (true)
                {
                    for (int i = 0; i < brEntitet; i++)
                    {
                        genEntiteta.dodajEntitete(out GenerisaniEnt);
                        listaEntiteta.Add(GenerisaniEnt);
                    }
                    break;
                }

                Console.WriteLine("\nPoeni za entitete:\n");
                int j = 1;
                foreach (Entitet ent in listaEntiteta)
                {
                    Console.WriteLine("Entitet broj " + j + ": " + ent.Poeni);
                    j++;
                }

                //unos prodavnice
                Console.WriteLine("\n================ Unos prodavnice =================\n");
                Console.Write("Unesite ID prodavnice: ");
                while (!int.TryParse(Console.ReadLine(), out idProdavnice) || !unosProdavnice.unosProdavnice(idProdavnice, out izabranaProdavnica))
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
                Console.WriteLine("\n================== Unos timova ===================\n");
                Console.Write("Unesite naziv plavog tima: ");
                plaviTim = Console.ReadLine() ?? "";

                Console.Write("Unesite naziv crvenog tima: ");
                crveniTim = Console.ReadLine() ?? "";

                IzabranaMapa.PlaviTim = plaviTim;
                IzabranaMapa.CrveniTim = crveniTim;

                //ispis svih dostupnih heroja
                Console.WriteLine("\nDostupni heroji:\n");
                unosCrvenih.ispisHeroja();

                //unos igraca u crveni i plavi tim
                while (true)
                {
                    Console.Write("\nUnesite broj igraca za plavi tim: ");
                    brPlaviTim = int.Parse(Console.ReadLine());
                    Console.Write("Unesite broj igraca za crveni tim: ");
                    brCrveniTim = int.Parse(Console.ReadLine());
                    if (brPlaviTim + brCrveniTim > IzabranaMapa.MaxIgraca)
                    {
                        Console.WriteLine("\nPrevise igraca. Odaberite drugi broj.\n");
                        continue;
                    }
                    break;
                }

                //unos plavog tima
                Console.WriteLine("\nUnesite nazive igraca i heroje plavog tima:\n");
                for (int i = 0; i < brPlaviTim; i++)
                {
                    Console.Write("Unesite naziv " + (i + 1) + ". igraca: ");
                    string naziv;
                    naziv = Console.ReadLine() ?? "";
                    string nazivHeroja;
                    while (true)
                    {
                        Console.Write("Izaberite heroja: ");
                        nazivHeroja = Console.ReadLine() ?? "";
                        if (!unosPlavih.unosPlavih(naziv, nazivHeroja, out izabraniIgrac))
                        {
                            continue;
                        }
                        ListaPlavih.Add(izabraniIgrac);
                        break;
                    }
                }

                //unos crvenog tima
                Console.WriteLine("\nUnesite nazive igraca i heroje crvenog tima:\n");
                for (int i = 0; i < brCrveniTim; i++)
                {
                    Console.Write("Unesite naziv " + (i + 1) + ". igraca: ");
                    string naziv;
                    naziv = Console.ReadLine() ?? "";
                    string nazivHeroja;
                    while (true)
                    {
                        Console.Write("Izaberite heroja: ");
                        nazivHeroja = Console.ReadLine() ?? "";
                        if (!unosCrvenih.unosCrvenih(naziv, nazivHeroja, out izabraniIgrac))
                        {
                            continue;
                        }
                        ListaCrvenih.Add(izabraniIgrac);
                        break;
                    }
                }

                Console.WriteLine("\nPlavi tim:\n");

                int brP = 1;
                foreach (Igrac i in ListaPlavih)
                {
                    Console.Write(brP + ". Igrac: Naziv: " + i.Naziv);
                    Console.WriteLine(", Heroj: " + i.heroj.NazivHeroja);
                    brP++;
                }

                Console.WriteLine("\nCrveni tim:\n");

                int brC = 1;
                foreach (Igrac i in ListaCrvenih)
                {
                    Console.Write(brC + ". Igrac: Naziv: " + i.Naziv);
                    Console.WriteLine(", Heroj: " + i.heroj.NazivHeroja);
                    brC++;
                }

                //trajanje bitke
                Console.WriteLine("\n=============== Zapocinjanje bitke ================\n");
                Random rand = new Random();
                int trajanjeBitke = rand.Next(10, 46);

                Console.WriteLine($"Bitka izmedju plavog i crvenog tima zapocinje na mapi {nazivMape} i traje {trajanjeBitke} sekundi.\n");
                Thread.Sleep(trajanjeBitke * 1000);

                //simulacija napada na Entitet
                do
                {
                    napadniEntitet.NapadniEntitet(ListaPlavih, ListaCrvenih, listaEntiteta);
                    kupovinaArtikala.KupovinaProvera(ListaPlavih, ListaCrvenih, izabranaProdavnica);
                    l++;
                } while (l < brEntitet);

                //simulacija napada na igraca
                do
                {
                    napadniIgraca.NapadniIgraca(ListaPlavih, ListaCrvenih);
                    kupovinaArtikala.KupovinaProvera(ListaPlavih, ListaCrvenih, izabranaProdavnica);
                    k++;
                } while (k < 75);

                foreach (Igrac igr1 in ListaPlavih)
                {
                    if (igr1.heroj.ZivotniPoeni <= 0)
                    {
                        igr1.heroj.ZivotniPoeni = 0;
                        Console.WriteLine(igr1.heroj.NazivHeroja + " je eliminisan.");
                    }
                }

                foreach (Igrac igr2 in ListaCrvenih)
                {
                    if (igr2.heroj.ZivotniPoeni <= 0)
                    {
                        igr2.heroj.ZivotniPoeni = 0;
                        Console.WriteLine(igr2.heroj.NazivHeroja + " je eliminisan.");
                    }
                }

                Console.WriteLine("\nPlavi tim:\n");

                int brP1 = 1;
                foreach (Igrac i in ListaPlavih)
                {
                    Console.Write(brP1 + ". Igrac: Naziv: " + i.Naziv);
                    Console.WriteLine(", Heroj: " + i.heroj.NazivHeroja + " HP: " + i.heroj.ZivotniPoeni + " ATT: " + i.heroj.JacinaNapada + " COINS: " + i.heroj.StanjeNovcica);
                    brP1++;
                }

                Console.WriteLine("\nCrveni tim:\n");

                int brC1 = 1;
                foreach (Igrac i in ListaCrvenih)
                {
                    Console.Write(brC1 + ". Igrac: Naziv: " + i.Naziv);
                    Console.WriteLine(", Heroj: " + i.heroj.NazivHeroja + " HP: " + i.heroj.ZivotniPoeni + " ATT: " + i.heroj.JacinaNapada + " COINS: " + i.heroj.StanjeNovcica);
                    brC1++;
                }

                break;
            }
        }    
    }
}