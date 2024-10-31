using Common.Modeli;
using Common.Servisi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servisi.Kupovina
{
    public class Kupovina : IKupovina
    {
        public Kupovina() { }

        public void KupovinaProvera(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod)
        {
            foreach (Igrac i in PlaviTim)
            {
                if (i.heroj.StanjeNovcica >= 500)
                {
                    Kupi(i, prod);
                }
            }

            foreach (Igrac i in CrveniTim)
            {
                if (i.heroj.StanjeNovcica >= 500)
                {
                    Kupi(i, prod);
                }
            }
        }

        public void Kupi(Igrac igr, Prodavnica prod)
        {
            foreach (Oruzje o in prod.Oruzje)
            {
                if (o.Kolicina > 0)
                {
                    igr.heroj.JacinaNapada += o.Napad;
                    igr.heroj.StanjeNovcica -= o.Cena;
                    o.Kolicina--;
                }
                else
                {
                    Console.WriteLine("Oruzje " + o.Naziv + " vise nije dostupno.");
                }
            }

            foreach (Napici n in prod.Napicis)
            {
                if (n.Kolicina > 0)
                {
                    igr.heroj.JacinaNapada += n.Napad;
                    igr.heroj.StanjeNovcica -= n.Cena;
                    n.Kolicina--;
                }
                else
                {
                    Console.WriteLine("Napitak " + n.Naziv + " vise nije dostupan.");
                }
            }
        }
    }
}
