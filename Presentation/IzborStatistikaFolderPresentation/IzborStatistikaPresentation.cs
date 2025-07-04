﻿using Common.Modeli;
using Common.Servisi;

namespace Presentation.IzborStatistikaFolderPresentation
{
    public class IzborStatistikaPresentation
    {
        private readonly ITabelarniPrikazServis _tabelaStatistika;
        private readonly IDatotekaPrikazServis _datotekaPrikaz;

        public IzborStatistikaPresentation(ITabelarniPrikazServis tabelaStatistika, IDatotekaPrikazServis datotekaPrikaz)
        {
            _tabelaStatistika = tabelaStatistika;
            _datotekaPrikaz = datotekaPrikaz;
        }
        public void PrikaziStatistiku(List<Igrac> ListaPlavih, List<Igrac> ListaCrvenih, Mapa IzabranaMapa, int ukupnoPotroseno)
        {
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
                _tabelaStatistika.ispisTabele(ListaPlavih, ListaCrvenih, IzabranaMapa, ukupnoPotroseno);
            }
            else if (izbor == 2)
            {
                _datotekaPrikaz.IspisFajl(ListaPlavih, ListaCrvenih, IzabranaMapa, ukupnoPotroseno);
                Console.WriteLine("Statistika je upisana u datoteku 'statistika.txt'.");
            }
        }
    }
}
