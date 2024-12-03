using Common.Modeli;
using Common.Servisi;

namespace Servisi.KupovinaFolder
{
    public class KupovinaServis : IKupovina
    {
        public void ObaviKupovinu(Igrac igr, Prodavnica prod, out int ukupnaCena)
        {
            ukupnaCena = 0;

            foreach (Oruzje o in prod.Oruzje)
            {
                if (o.Kolicina > 0)
                {
                    igr.heroj.JacinaNapada += o.Napad;
                    igr.heroj.StanjeNovcica -= o.Cena;
                    o.Kolicina--;
                    ukupnaCena += o.Cena;
                    Console.WriteLine("Igrac " + igr.Naziv + " je kupio oruzje: " + o.Naziv + " za " + o.Cena);
                }
            }

            foreach (Napici n in prod.Napicis)
            {
                if (n.Kolicina > 0)
                {
                    igr.heroj.ZivotniPoeni += n.Napad;
                    igr.heroj.StanjeNovcica -= n.Cena;
                    n.Kolicina--;
                    ukupnaCena += n.Cena;
                    Console.WriteLine("Igrac " + igr.Naziv + " je kupio napitak: " + n.Naziv + " za " + n.Cena);
                }
            }
        }

    }
}
