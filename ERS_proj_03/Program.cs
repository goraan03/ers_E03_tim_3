using Common.Modeli;
using Common.Servisi;
using Domain.Repozitorijum.HerojRepozitorijum;
using Domain.Repozitorijum.KorisniciRepozitorijum;
using Domain.Repozitorijum.MapeRepozitorijum;
using Domain.Repozitorijum.ProdavniceRepozitorijum;
using Domain.Servisi;
using Presentation;
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

namespace ERS_proj_03
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                //servisi
                IUnosCrvenih unosCrvenih = new UnosCrvenih();
                IUnosPlavih unosPlavih = new UnosPlavih();
                IIspisHeroja ispisHeroja = new IspisHeroja();

                //autentifikacija
                KorisniciRepozitorijum korisniciRepozitorijum = new KorisniciRepozitorijum();
                var autentifikacija = new Autentifikacija(korisniciRepozitorijum);
                var autentifikacijaPresentation = new AutentifikacijaPresentation(autentifikacija);
                Korisnik? prijavljen = autentifikacijaPresentation.Prijava();

                //unos entiteta
                var brojEntitetaPresentation = new BrojEntitetaPresentation();
                int brEntitet = brojEntitetaPresentation.UnesiBrojEntiteta();
                List<Entitet> listaEntiteta = new List<Entitet>();

                //unos mape
                MapeRepozitorijum mapeRepozitorijum = new MapeRepozitorijum();
                var mapaPresentation = new MapaPresentation(new UnosMape(mapeRepozitorijum));
                Mapa? IzabranaMapa = mapaPresentation.UnesiMapu();
                

                //provera broja entiteta na mapi i generisanje
                if (brEntitet > IzabranaMapa.PomocniEntiteti)
                {
                    brEntitet = IzabranaMapa.PomocniEntiteti;
                    EntitetPresentation entitetPresentation = new EntitetPresentation(new GenEntitet());
                    listaEntiteta = entitetPresentation.UnesiEntitete(brEntitet);
                }

                //unos prodavnice
                Prodavnica? izabranaProdavnica;
                var prodavniceRepozitorijum = new ProdavniceRepozitorijum();
                var prodavnicaPresentation = new ProdavnicaPresentation(new UnosProdavnice(new ProdavniceRepozitorijum()));
                izabranaProdavnica = prodavnicaPresentation.UnesiProdavnicu();

                //unos naziva plavog i crvenog tima
                
                HerojRepozitorijum herojRepozitorijum = new HerojRepozitorijum();
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
                List<Igrac> ListaPlavih = new List<Igrac>();
                List<Igrac> ListaCrvenih = new List<Igrac>();
                var unosTimPresentation = new UnosTimPresentation();

                //unos plavog tima
                HashSet<string> naziviIgracaPlavi = new HashSet<string>();
                unosTimPresentation.UnesiIgraceITim("plavi", brPlaviTim, naziviIgracaPlavi, ListaPlavih, unosPlavih);

                //unos crvenog tima
                HashSet<string> naziviIgracaCrveni = new HashSet<string>();
                unosTimPresentation.UnesiIgraceITim("crveni", brCrveniTim, naziviIgracaCrveni, ListaCrvenih, unosCrvenih);

                //trajanje bitke
                var trajanjeBitkePresentation = new TrajanjeBitkePresentation();
                int trajanjeBitke = trajanjeBitkePresentation.ZapocniBitku(IzabranaMapa);

                //simulacija napada na Entitet
                int l = 0;
                var NapadEntitetPresentation = new NapadEntitetPresentation(new NapadNaEntitet());
                var kupovinaSvihIgracaPresentation = new KupovinaSvihIgracaPresentation(new KupovinaSvihIgraca());
                do
                {
                    NapadEntitetPresentation.NapadniEntitet(ListaPlavih, ListaCrvenih, listaEntiteta);
                    kupovinaSvihIgracaPresentation.KupovinaSvih(ListaPlavih, ListaCrvenih, izabranaProdavnica, out int ukPotroseno);
                    l++;
                } while (l < brEntitet);

                //simulacija napada na igraca
                var napadIgracaPresentation = new NapadIgracaPresentation(new NapadNaIgraca());

                // Pozivanje metode IzvrsiNapadNaIgrace da obavi napad, eliminaciju i kupovinu
                HashSet<string> eliminisaniPlavi = new HashSet<string>();
                HashSet<string> eliminisaniCrveni = new HashSet<string>();
                int ukupnoPotroseno = 0;
                napadIgracaPresentation.IzvrsiNapadNaIgrace(ListaPlavih, ListaCrvenih, trajanjeBitke, izabranaProdavnica, out eliminisaniPlavi, out eliminisaniCrveni, out ukupnoPotroseno);

                // izbor za prikaz statistike
                var tabelaStatistika = new TabelarniPrikaz();
                var datotekaPrikaz = new DatotekaPrikaz();
                var izborStatistikaPresentation = new IzborStatistikaPresentation(tabelaStatistika, datotekaPrikaz);
                izborStatistikaPresentation.PrikaziStatistiku(ListaPlavih, ListaCrvenih, IzabranaMapa, ukupnoPotroseno);
                break;
            }
        }
    }
}