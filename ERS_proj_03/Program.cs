using Common.Modeli;
using Domain.Servisi;
using Domain.Repozitorijum.HerojRepozitorijum;
using Domain.Repozitorijum.KorisniciRepozitorijum;
using Domain.Repozitorijum.MapeRepozitorijum;
using Domain.Repozitorijum.ProdavniceRepozitorijum;
using Servisi.Autentifikacija;
using Servisi.DatotekaPrikaz;
using Servisi.GenEntitet;
using Servisi.IspisHeroja;
using Servisi.KupovinaSvihIgracca;
using Servisi.NapadNaEntitet;
using Servisi.TabelarniPrikaz;
using Servisi.UnosCrvenih;
using Servisi.UnosMape;
using Servisi.UnosPlavih;
using Servisi.UnosProdavnice;
using Servisi.ZlatniNovcic;
using Common.Servisi;
using Presentation;

namespace ERS_proj_03
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                //promenljive za autentifikaciju
                KorisniciRepozitorijum korisniciRepozitorijum = new KorisniciRepozitorijum();
                var autentifikacija = new Autentifikacija(korisniciRepozitorijum);
                var autentifikacijaPresentation = new AutentifikacijaPresentation(autentifikacija);

                //promenljive za unos entiteta
                int brEntitet = 0;
                List<Entitet> listaEntiteta = new List<Entitet>();

                //promenljive za unos mape
                string plaviTim = "";
                string crveniTim = "";
                MapeRepozitorijum mapeRepozitorijum = new MapeRepozitorijum();

                //promenljive za unos prodavnice
                Prodavnica? izabranaProdavnica;
                var prodavniceRepozitorijum = new ProdavniceRepozitorijum();

                //promenljiva za sabiranje ukupnih potrosenih novcica
                int potroseno1 = 0;
                int potroseno2 = 0;
                int ukupnoPotroseno = 0;

                //promenljive za kupovinu
                var kupovinaSvihIgraca = new KupovinaSvihIgraca();

                //promenljive za unos timova
                List<Igrac> ListaPlavih = new List<Igrac>();
                List<Igrac> ListaCrvenih = new List<Igrac>();
                Igrac? izabraniIgrac;
                HerojRepozitorijum herojRepozitorijum = new HerojRepozitorijum();

                //promenljive za simulaciju bitke
                int k = 0;
                int l = 0;
                HashSet<string> eliminisaniPlavi = new HashSet<string>();
                HashSet<string> eliminisaniCrveni = new HashSet<string>();

                //servisi
                IUnosCrvenih unosCrvenih = new UnosCrvenih();
                IUnosPlavih unosPlavih = new UnosPlavih();
                INapadNaIgraca napadniIgraca = new NapadNaIgraca();
                INapadNaEntitet napadniEntitet = new NapadNaEntitet();
                //IKupovina kupovinaArtikala = new Kupovina();
                ITabelarniPrikaz tabelaStatistika = new TabelarniPrikaz();
                IDatotekaPrikaz datotekaPrikaz = new DatotekaPrikaz();
                IIspisHeroja ispisHeroja = new IspisHeroja();

                //autentifikacija
                Console.WriteLine("================= PRIJAVA NALOGA ==================");

                Korisnik? prijavljen = autentifikacijaPresentation.Prijava();
                if (prijavljen != null)
                {
                    Console.WriteLine($"Dobrodošli, {prijavljen.ImePrezime}!");
                }

                //unos entiteta
                Console.WriteLine("\n================= Unos entiteta ===================\n");

                while (true)
                {
                    try
                    {
                        Console.Write("Unesite broj entiteta: ");
                        brEntitet = int.Parse(Console.ReadLine());
                        break;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Doslo je do greske: " + e.Message);
                    }
                }

                //unos mape
                var mapaPresentation = new MapaPresentation(new UnosMape(new MapeRepozitorijum()));
                Mapa? IzabranaMapa = mapaPresentation.UnesiMapu();

                //provera broja entiteta na mapi i generisanje
                if (brEntitet > IzabranaMapa.PomocniEntiteti)
                {
                    brEntitet = IzabranaMapa.PomocniEntiteti;
                    EntitetPresentation entitetPresentation = new EntitetPresentation(new GenEntitet());
                    listaEntiteta = entitetPresentation.UnesiEntitete(brEntitet);
                }

                //unos prodavnice
                var prodavnicaPresentation = new ProdavnicaPresentation(new UnosProdavnice(new ProdavniceRepozitorijum()));
                izabranaProdavnica = prodavnicaPresentation.UnesiProdavnicu();

                //unos naziva plavog i crvenog tima
                var imenaTimovaPresentation = new ImenaTimovaPresentation();
                imenaTimovaPresentation.UnesiTimove(out string PlaviTim, out string CrveniTim, IzabranaMapa);


                //unos broja igraca u crveni i plavi tim
                var brojIgracaPresentation = new BrojIgracaPresentation();

                // Pozivanje metode za unos broja igrača
                brojIgracaPresentation.UnesiBrojIgraca(out int brPlaviTim, out int brCrveniTim, IzabranaMapa);


                //ispis svih dostupnih heroja
                Console.WriteLine("\nDostupni heroji:\n");
                ispisHeroja.ispisHeroja(herojRepozitorijum.SpisakHeroja());

                //unos timova
                var unosTimPresentation = new UnosTimPresentation();

                //unos plavog tima
                HashSet<string> naziviIgracaPlavi = new HashSet<string>();
                unosTimPresentation.UnesiIgraceITim("Plavi", brPlaviTim, naziviIgracaPlavi, ListaPlavih, unosPlavih);

                //unos crvenog tima
                HashSet<string> naziviIgracaCrveni = new HashSet<string>();
                unosTimPresentation.UnesiIgraceITim("Crveni", brCrveniTim, naziviIgracaCrveni, ListaCrvenih, unosCrvenih);

                //trajanje bitke
                var trajanjeBitkePresentation = new TrajanjeBitkePresentation();
                int trajanjeBitke = trajanjeBitkePresentation.ZapocniBitku(IzabranaMapa);

                //simulacija napada na Entitet
                do
                {
                    napadniEntitet.NapadniEntitet(ListaPlavih, ListaCrvenih, listaEntiteta);
                    kupovinaSvihIgraca.KupovinaSvih(ListaPlavih, ListaCrvenih, izabranaProdavnica, out potroseno1); // Kupovina za sve igrače
                    l++;
                } while (l < brEntitet);

                //simulacija napada na igraca
                do
                {
                    napadniIgraca.NapadniIgraca(ListaPlavih, ListaCrvenih);
                    kupovinaSvihIgraca.KupovinaSvih(ListaPlavih, ListaCrvenih, izabranaProdavnica, out potroseno2);
                    k++;

                    foreach (Igrac igr1 in ListaPlavih)
                    {
                        if (igr1.heroj.ZivotniPoeni <= 0 && !eliminisaniPlavi.Contains(igr1.Naziv))
                        {
                            eliminisaniPlavi.Add(igr1.Naziv);
                            igr1.heroj.ZivotniPoeni = 0;
                            Console.WriteLine(igr1.Naziv + " iz tima " + plaviTim + " je eliminisan.");
                        }
                    }

                    foreach (Igrac igr1 in ListaCrvenih)
                    {
                        if (igr1.heroj.ZivotniPoeni <= 0 && !eliminisaniCrveni.Contains(igr1.Naziv))
                        {
                            eliminisaniCrveni.Add(igr1.Naziv);
                            igr1.heroj.ZivotniPoeni = 0;
                            Console.WriteLine(igr1.Naziv + " iz tima " + crveniTim + " je eliminisan.");
                        }
                    }
                } while (k < (trajanjeBitke * 2)); //ukoliko se desi da bude 10s bitka, da ne bude bas samo 10 napada


                ukupnoPotroseno = potroseno1 + potroseno2;

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

                // izbor za prikaz statistike

                int izbor = 0;

                while (true)
                {
                    Console.WriteLine("\n================ Izbor prikaza statistike =================\n");
                    Console.Write("Dostupne opcije za ispis: \n1. Tabelarni ispis u konzoli\n2. Ispis u tekstualnoj datoteci\n");
                    Console.Write("Vas izbor: ");

                    string unos = Console.ReadLine();

                    Console.WriteLine();

                    if (int.TryParse(unos, out izbor) && (izbor == 1 || izbor == 2))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nevalidan unos. Molimo unesite 1 ili 2.");
                    }
                }

                if (izbor == 1)
                {
                    // Logika za ispis u tabelarnoj formi u konzoli
                    tabelaStatistika.ispisTabele(ListaPlavih, ListaCrvenih, IzabranaMapa, kupovinaSvihIgraca.getTotal());
                }
                else if (izbor == 2)
                {
                    // Logika za ispis u tekstualnoj datoteci
                    datotekaPrikaz.IspisFajl(ListaPlavih, ListaCrvenih, IzabranaMapa, kupovinaSvihIgraca.getTotal());
                    Console.WriteLine("Statistika je upisana u datoteku 'statistika.txt'.");
                }
                break;
            }
        }
    }
}