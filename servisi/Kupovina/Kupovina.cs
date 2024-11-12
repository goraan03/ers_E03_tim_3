using Common.Modeli;
using Common.Servisi;

namespace Servisi.Kupovina
{
    public class Kupovina : IKupovina
    {

        private int totalPotroseno = 0;

        public Kupovina() { }

        public void KupovinaProvera(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod, out int ukPotroseno)
        {
            ukPotroseno = 0;
            foreach (Igrac i in PlaviTim)
            {
                if (i.heroj.StanjeNovcica >= 500)
                {
                    Kupi(i, prod, out int ukupnaCena);
                    ukPotroseno += ukupnaCena;
                }
            }

            foreach (Igrac i in CrveniTim)
            {
                if (i.heroj.StanjeNovcica >= 500)
                {
                    Kupi(i, prod, out int ukupnaCena);
                    ukPotroseno += ukupnaCena;
                }
            }
            totalPotroseno += ukPotroseno;
        }
        public int getTotal()
        {
            return totalPotroseno;
        }

        public void Kupi(Igrac igr, Prodavnica prod, out int ukupnaCena)
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

            Console.WriteLine(igr.Naziv + " je potrosio: " + ukupnaCena);
        }

    }
}
