using Common.Servisi;
using Common.Modeli;

namespace Servisi.ZlatniNovcic
{
    public class NapadNaIgraca : INapadNaIgraca
    {
        public NapadNaIgraca() { }

        public void NapadniIgraca(List<Igrac> Plavi, List<Igrac> Crveni)
        {
            // Plavi napada crvenog

            Random random1 = new Random();

            int indexPlavi1 = random1.Next(Plavi.Count);
            Igrac igrac1 = Plavi[indexPlavi1];

            int indexCrveni1 = random1.Next(Crveni.Count);
            Igrac igrac2 = Crveni[indexCrveni1];

            if (igrac1.heroj.ZivotniPoeni > 0 && igrac2.heroj.ZivotniPoeni > 0)
            {
                if (igrac2.heroj.ZivotniPoeni <= igrac1.heroj.JacinaNapada)
                {
                    igrac1.heroj.StanjeNovcica += 300;
                }

                igrac2.heroj.ZivotniPoeni -= igrac1.heroj.JacinaNapada;
            }
            else
            {
                if (igrac1.heroj.ZivotniPoeni <= 0)
                {
                    indexPlavi1 = random1.Next(Plavi.Count);
                    igrac1 = Plavi[indexPlavi1];
                }
                else
                {
                    indexCrveni1 = random1.Next(Crveni.Count);
                    igrac2 = Crveni[indexCrveni1];
                }
            }

            // Crveni napada plavog

            Random random2 = new Random();

            int indexPlavi2 = random2.Next(Plavi.Count);
            Igrac igrac3 = Plavi[indexPlavi2];

            int indexCrveni2 = random2.Next(Crveni.Count);
            Igrac igrac4 = Crveni[indexCrveni2];

            if (igrac3.heroj.ZivotniPoeni > 0 && igrac4.heroj.ZivotniPoeni > 0)
            {
                if (igrac3.heroj.ZivotniPoeni <= igrac4.heroj.JacinaNapada)
                {
                    igrac4.heroj.StanjeNovcica += 300;
                }

                igrac3.heroj.ZivotniPoeni -= igrac4.heroj.JacinaNapada;
            }
            else
            {
                if (igrac3.heroj.ZivotniPoeni <= 0)
                {
                    indexPlavi2 = random2.Next(Plavi.Count);
                    igrac3 = Plavi[indexPlavi2];
                }
                else
                {
                    indexCrveni2 = random2.Next(Crveni.Count);
                    igrac4 = Crveni[indexCrveni2];
                }
            }
        }
    }
}
