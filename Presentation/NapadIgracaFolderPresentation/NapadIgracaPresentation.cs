using Common.Modeli;
using Common.Servisi;
using Servisi.KupovinaSvihIgracaFolder;
using Presentation.KupovinaSvihIgracaFolderPresentation;

namespace Presentation.NapadIgracaFolderPresentation
{
    public class NapadIgracaPresentation
    {
        private readonly INapadNaIgracaServis _napadNaIgraca;

        public NapadIgracaPresentation(INapadNaIgracaServis napadNaIgraca)
        {
            _napadNaIgraca = napadNaIgraca;
        }

        public void IzvrsiNapadNaIgrace(List<Igrac> PlaviTim, List<Igrac> CrveniTim, int trajanjeBitke, Prodavnica prodavnica, out HashSet<string> eliminisaniPlavi, out HashSet<string> eliminisaniCrveni, out int ukupnoPotroseno)
        {
            int k = 0;
            eliminisaniPlavi = new HashSet<string>();
            eliminisaniCrveni = new HashSet<string>();
            ukupnoPotroseno = 0;

            while (k < trajanjeBitke * 2)
            {
                _napadNaIgraca.NapadniIgraca(PlaviTim, CrveniTim);

                foreach (Igrac igr1 in PlaviTim)
                {
                    if (igr1.heroj.ZivotniPoeni <= 0 && !eliminisaniPlavi.Contains(igr1.Naziv))
                    {
                        igr1.heroj.ZivotniPoeni = 0;
                        eliminisaniPlavi.Add(igr1.Naziv);
                        Console.WriteLine(igr1.Naziv + " je eliminisan.");
                    }
                }

                foreach (Igrac igr1 in CrveniTim)
                {
                    if (igr1.heroj.ZivotniPoeni <= 0 && !eliminisaniCrveni.Contains(igr1.Naziv))
                    {
                        igr1.heroj.ZivotniPoeni = 0;
                        eliminisaniCrveni.Add(igr1.Naziv);
                        Console.WriteLine(igr1.Naziv + " je eliminisan.");
                    }
                }

                var kupovinaSvihIgracaPresentation = new KupovinaSvihIgracaPresentation(new KupovinaSvihIgracaServis());
                kupovinaSvihIgracaPresentation.KupovinaSvih(PlaviTim, CrveniTim, prodavnica, out int potroseno);
                ukupnoPotroseno += potroseno;
                k++;
            }
        }
    }
}
