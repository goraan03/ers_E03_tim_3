using System.Text;
using Common.Modeli;
using Common.Servisi;
using Domain.Servisi;

namespace Servisi.PripremaStatistikeFolder
{
    public class PripremaStatistikeServis : IPripremaStatistike
    {
        private readonly IDatotekaPrikaz _datotekaPrikaz;
        private readonly ITabelarniPrikaz _tabelarniPrikaz;

        public PripremaStatistikeServis(IDatotekaPrikaz datotekaPrikaz, ITabelarniPrikaz tabelarniPrikaz)
        {
            _datotekaPrikaz = datotekaPrikaz;
            _tabelarniPrikaz = tabelarniPrikaz;
        }

        public StringBuilder PripremaIspis(List<Igrac> TimPlavi, List<Igrac> TimCrveni, Mapa m, int ukPotroseno)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Ukupan potrosen novac: {ukPotroseno}");
            sb.AppendLine($"Mapa: {m.NazivMape}");

            // Ispis Plavog tima
            sb.AppendLine($"\t\t\t{m.PlaviTim}");
            sb.AppendLine(new string('=', 72));
            sb.AppendLine(string.Format("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}", "NICK", "HERO", "HP", "ATT", "COINS"));

            foreach (Igrac i in TimPlavi)
            {
                sb.AppendLine(new string('-', 72));
                sb.AppendLine(string.Format("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}",
                                             i.Naziv,
                                             i.heroj.NazivHeroja,
                                             i.heroj.ZivotniPoeni,
                                             i.heroj.JacinaNapada,
                                             i.heroj.StanjeNovcica));
            }
            sb.AppendLine(new string('=', 72));

            // Ispis Crvenog tima
            sb.AppendLine($"\n\t\t\t{m.CrveniTim}");
            sb.AppendLine(new string('=', 72));
            sb.AppendLine(string.Format("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}", "NICK", "HERO", "HP", "ATT", "COINS"));

            foreach (Igrac i in TimCrveni)
            {
                sb.AppendLine(new string('-', 72));
                sb.AppendLine(string.Format("{0,-10} || {1,-10} || {2,-5} || {3,-5} || {4,-5}",
                                             i.Naziv,
                                             i.heroj.NazivHeroja,
                                             i.heroj.ZivotniPoeni,
                                             i.heroj.JacinaNapada,
                                             i.heroj.StanjeNovcica));
            }
            sb.AppendLine(new string('=', 72));

            return sb;
        }
    }
}
