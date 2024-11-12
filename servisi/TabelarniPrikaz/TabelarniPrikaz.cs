using Common.Modeli;
using Common.Servisi;

namespace Servisi.TabelarniPrikaz
{
    public class TabelarniPrikaz : ITabelarniPrikaz
    {
        public void ispisTabele(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno)
        {
            Console.WriteLine();
            // Ispis potrosenog novca
            Console.WriteLine("Ukupan potrosen novac: " + ukPotroseno);
            //Ispis naziva mape
            Console.WriteLine("Mapa: " + m.NazivMape);
            // Ispis Plavog tima
            Console.WriteLine("\t\t\t" + m.PlaviTim);
            Console.WriteLine("========================================================================");
            Console.WriteLine("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}", "NICK", "HERO", "HP", "ATT", "COINS");
            foreach (Igrac i in TimPlavi)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}",
                                  i.Naziv,
                                  i.heroj.NazivHeroja,
                                  i.heroj.ZivotniPoeni,
                                  i.heroj.JacinaNapada,
                                  i.heroj.StanjeNovcica);
            }
            Console.WriteLine("========================================================================\n");

            // Ispis Crvenog tima
            Console.WriteLine("\t\t\t" + m.CrveniTim);
            Console.WriteLine("========================================================================");
            Console.WriteLine("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}", "NICK", "HERO", "HP", "ATT", "COINS");
            foreach (Igrac i in TimCrveni)
            {
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}",
                                  i.Naziv,
                                  i.heroj.NazivHeroja,
                                  i.heroj.ZivotniPoeni,
                                  i.heroj.JacinaNapada,
                                  i.heroj.StanjeNovcica);
            }
            Console.WriteLine("========================================================================");
        }

    }
}
