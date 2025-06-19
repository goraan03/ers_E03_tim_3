using Common.Modeli;
using Domain.Repozitorijum.HerojRepozitorijum;
using Domain.Repozitorijum.KorisniciRepozitorijum;
using Domain.Repozitorijum.MapeRepozitorijum;
using Domain.Servisi;
using Presentation.EntitetFolderPresentation;
using Presentation.AutentifikacijaFolderPresentation;
using Presentation.BrojEntitetaFolderPresentation;
using Presentation.BrojIgracaFolderPresentation;
using Presentation.ImenaTimovaFolderPresentation;
using Presentation.IzborStatistikaFolderPresentation;
using Presentation.KupovinaSvihIgracaFolderPresentation;
using Presentation.MapaFolderPresentation;
using Presentation.NapadEntitetFolderPresentation;
using Presentation.NapadIgracaFolderPresentation;
using Presentation.ProdavnicaFolderPresentation;
using Presentation.TrajanjeBitkeFolderPresentation;
using Presentation.UnosTimFolderPresentation;
using Servisi.AutentifikacijaFolder;
using Servisi.DatotekaPrikazFolder;
using Servisi.GenEntitetFolder;
using Servisi.IspisHerojaFolder;
using Servisi.KupovinaSvihIgracaFolder;
using Servisi.NapadNaEntitetFolder;
using Servisi.TabelarniPrikazFolder;
using Servisi.UnosMapeFolder;
using Servisi.UnosProdavniceFolder;
using Servisi.NapadNaIgracaFolder;
using Servisi.PripremaStatistikeFolder;
using Servisi.UnosIgracaFolder;

namespace ERS_proj_03
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                // Servisi
                IIspisHerojaServis ispisHeroja = new IspisHerojaServis();

                // Autentifikacija
                KorisniciRepozitorijum korisniciRepozitorijum = new KorisniciRepozitorijum();
                var autentifikacija = new AutentifikacijaServis();
                var autentifikacijaPresentation = new AutentifikacijaPresentation(autentifikacija);
                Korisnik? prijavljen = autentifikacijaPresentation.Prijava();           // Prijavljen korisnik

                // Unos entiteta
                var brojEntitetaPresentation = new BrojEntitetaPresentation();
                int brEntitet = brojEntitetaPresentation.UnesiBrojEntiteta();           // Broj entiteta
                List<Entitet> listaEntiteta = new List<Entitet>();

                // Unos mape
                MapeRepozitorijum mapeRepozitorijum = new MapeRepozitorijum();
                var mapaPresentation = new MapaPresentation(new UnosMapeServis());
                Mapa? IzabranaMapa = mapaPresentation.UnesiMapu();                      // Izabrana mapa
                
                // Provera broja entiteta na mapi i generisanje
                if (brEntitet > IzabranaMapa.PomocniEntiteti)
                {
                    brEntitet = IzabranaMapa.PomocniEntiteti;
                    EntitetPresentation entitetPresentation = new EntitetPresentation(new GenEntitetServis());      
                    listaEntiteta = entitetPresentation.UnesiEntitete(brEntitet);                                   // lista entiteta
                }

                //unos prodavnice
                Prodavnica? izabranaProdavnica;
                var prodavnicaPresentation = new ProdavnicaPresentation(new UnosProdavniceServis());
                izabranaProdavnica = prodavnicaPresentation.UnesiProdavnicu();                              // Izabrana prodavnica

                //unos naziva plavog i crvenog tima
                HerojRepozitorijum herojRepozitorijum = new HerojRepozitorijum();
                var imenaTimovaPresentation = new ImenaTimovaPresentation();
                imenaTimovaPresentation.UnesiTimove(out string PlaviTim, out string CrveniTim, IzabranaMapa);

                //unos broja igraca u crveni i plavi tim
                var brojIgracaPresentation = new BrojIgracaPresentation();

                // Pozivanje metode za unos broja igraca
                brojIgracaPresentation.UnesiBrojIgraca(out int brPlaviTim, out int brCrveniTim, IzabranaMapa);

                //ispis svih dostupnih heroja
                Console.WriteLine("\nDostupni heroji:\n");
                ispisHeroja.IspisHeroja(herojRepozitorijum.SpisakHeroja());

                // Inicijalizacija timova
                List<Igrac> ListaPlavih = new List<Igrac>();
                List<Igrac> ListaCrvenih = new List<Igrac>();
                var unosIgracaServis = new UnosIgracaServis(herojRepozitorijum);
                var unosTimPresentation = new UnosTimPresentation();

                // Unos plavog i crvenog tima
                HashSet<string> naziviIgracaPlavi = new HashSet<string>();
                HashSet<string> naziviIgracaCrveni = new HashSet<string>();

                unosTimPresentation.UnesiIgraceITim("plavi", brPlaviTim, naziviIgracaPlavi, naziviIgracaCrveni, ListaPlavih, unosIgracaServis);
                
                unosTimPresentation.UnesiIgraceITim("crveni", brCrveniTim, naziviIgracaPlavi, naziviIgracaCrveni, ListaCrvenih, unosIgracaServis);

                //trajanje bitke
                var trajanjeBitkePresentation = new TrajanjeBitkePresentation();
                int trajanjeBitke = trajanjeBitkePresentation.ZapocniBitku(IzabranaMapa);

                //simulacija napada na Entitet
                int l = 0;
                var NapadEntitetPresentation = new NapadEntitetPresentation(new NapadNaEntitetServis());
                var kupovinaSvihIgracaPresentation = new KupovinaSvihIgracaPresentation(new KupovinaSvihIgracaServis());
                do
                {
                    NapadEntitetPresentation.NapadniEntitet(ListaPlavih, ListaCrvenih, listaEntiteta);
                    int ukPotroseno = kupovinaSvihIgracaPresentation.KupovinaSvih(ListaPlavih, ListaCrvenih, izabranaProdavnica);
                    l++;
                } while (l < brEntitet);

                //simulacija napada na igraca
                var napadIgracaPresentation = new NapadIgracaPresentation(new NapadNaIgracaServis());
                HashSet<string> eliminisaniPlavi = new HashSet<string>();
                HashSet<string> eliminisaniCrveni = new HashSet<string>();
                int ukupnoPotroseno = 0;
                napadIgracaPresentation.IzvrsiNapadNaIgrace(ListaPlavih, ListaCrvenih, trajanjeBitke, izabranaProdavnica, out eliminisaniPlavi, out eliminisaniCrveni, out ukupnoPotroseno);

                //ispis statistike
                var pripremaStatistike = new PripremaStatistikeServis(null, null);
                var tabelaStatistika = new TabelarniPrikazServis(pripremaStatistike);
                var datotekaPrikaz = new DatotekaPrikazServis(pripremaStatistike);
                pripremaStatistike = new PripremaStatistikeServis(datotekaPrikaz, tabelaStatistika);
                var izborStatistikaPresentation = new IzborStatistikaPresentation(tabelaStatistika, datotekaPrikaz);
                izborStatistikaPresentation.PrikaziStatistiku(ListaPlavih, ListaCrvenih, IzabranaMapa, ukupnoPotroseno);

                break;
            }
        }
    }
}