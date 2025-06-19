using Common.Modeli;
using Common.Servisi;

namespace Servisi.NapadNaEntitetFolder
{
    public class NapadNaEntitetServis : INapadNaEntitetServis
    {

        public void NapadniEntitet(List<Igrac> TimPlavi, List<Igrac> TimCrveni, List<Entitet> Ent)
        {
            Random randomIgrPlavi = new Random();
            Random randomIgrCrveni = new Random();
            Random randomEnt = new Random();

            int indexTimPlavi = randomIgrPlavi.Next(TimPlavi.Count);
            Igrac igrac1 = TimPlavi[indexTimPlavi];

            int indexTimCrveni = randomIgrCrveni.Next(TimCrveni.Count);
            Igrac igrac2 = TimCrveni[indexTimCrveni];

            if (Ent.Count > 0)
            {
                int indexEnt = randomEnt.Next(Ent.Count);
                Entitet entitet = Ent[indexEnt];

                if (igrac1.heroj.ZivotniPoeni > 0)
                {
                    igrac1.heroj.StanjeNovcica += entitet.Poeni;
                    Ent.Remove(entitet);
                }
            }

            if (Ent.Count > 0)
            {
                int indexEnt = randomEnt.Next(Ent.Count);
                Entitet entitet = Ent[indexEnt];

                if (igrac2.heroj.ZivotniPoeni > 0)
                {
                    igrac2.heroj.StanjeNovcica += entitet.Poeni;
                    Ent.Remove(entitet);
                }
            }
        }
    }
}
