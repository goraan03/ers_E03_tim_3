using Common.Modeli;
using Common.Servisi;

namespace Servisi.DatotekaPrikaz
{
    public class DatotekaPrikaz : IDatotekaPrikaz
    {
        public void IspisFajl(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno)
        {
            using StreamWriter sw = new StreamWriter("statistika.txt", append: false);

            // Ispis potrosenih novcica
            sw.WriteLine("Ukupan potrosen novac: " + ukPotroseno);
            // Ispis naziva mape
            sw.WriteLine("Mapa: " + m.NazivMape);
            // Ispis Plavog tima u fajl
            sw.WriteLine("\t\t\t" + m.PlaviTim);
            sw.WriteLine("========================================================================");
            sw.WriteLine("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}", "NICK", "HERO", "HP", "ATT", "COINS");
            foreach (Igrac i in TimPlavi)
            {
                sw.WriteLine("------------------------------------------------------------------------");
                sw.WriteLine("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}",
                             i.Naziv,
                             i.heroj.NazivHeroja,
                             i.heroj.ZivotniPoeni,
                             i.heroj.JacinaNapada,
                             i.heroj.StanjeNovcica);
            }
            sw.WriteLine("========================================================================\n");

            // Ispis Crvenog tima u fajl
            sw.WriteLine("\t\t\t" + m.CrveniTim);
            sw.WriteLine("========================================================================");
            sw.WriteLine("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}", "NICK", "HERO", "HP", "ATT", "COINS");
            foreach (Igrac i in TimCrveni)
            {
                sw.WriteLine("------------------------------------------------------------------------");
                sw.WriteLine("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}",
                             i.Naziv,
                             i.heroj.NazivHeroja,
                             i.heroj.ZivotniPoeni,
                             i.heroj.JacinaNapada,
                             i.heroj.StanjeNovcica);
            }
            sw.WriteLine("========================================================================");
        }
    }
}
