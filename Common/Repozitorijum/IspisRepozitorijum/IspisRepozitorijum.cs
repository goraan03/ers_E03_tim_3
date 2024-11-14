using Common.Modeli;

namespace Domain.Repozitorijum.IspisRepozitorijum
{
    public class IspisRepozitorijum
    {
        public void Ispis(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno, Action<string> ispis)
        {
            ispis($"Ukupan potrosen novac: {ukPotroseno}");
            ispis($"Mapa: {m.NazivMape}");

            // Ispis Plavog tima
            ispis($"\t\t\t{m.PlaviTim}");
            ispis(new string('=', 72));
            ispis(string.Format("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}", "NICK", "HERO", "HP", "ATT", "COINS"));

            foreach (Igrac i in TimPlavi)
            {
                ispis(new string('-', 72));
                ispis(string.Format("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}",
                                     i.Naziv,
                                     i.heroj.NazivHeroja,
                                     i.heroj.ZivotniPoeni,
                                     i.heroj.JacinaNapada,
                                     i.heroj.StanjeNovcica));
            }
            ispis(new string('=', 72));

            // Ispis Crvenog tima
            ispis($"\n\t\t\t{m.CrveniTim}");
            ispis(new string('=', 72));
            ispis(string.Format("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}", "NICK", "HERO", "HP", "ATT", "COINS"));

            foreach (Igrac i in TimCrveni)
            {
                ispis(new string('-', 72));
                ispis(string.Format("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}",
                                     i.Naziv,
                                     i.heroj.NazivHeroja,
                                     i.heroj.ZivotniPoeni,
                                     i.heroj.JacinaNapada,
                                     i.heroj.StanjeNovcica));
            }
            ispis(new string('=', 72));
        }

    }
}
