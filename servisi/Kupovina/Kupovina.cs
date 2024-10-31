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

        private int totalPotroseno;

        public Kupovina()
        {
            totalPotroseno = 0;
        }

        public void KupovinaProvera(List<Igrac> PlaviTim, List<Igrac> CrveniTim, Prodavnica prod, out int ukPotroseno)
        {
            ukPotroseno = 0;
            foreach (Igrac i in PlaviTim)
            {
                if (i.heroj.StanjeNovcica >= 500)
                {
                    Kupi(i, prod, out int ukupnaCena);
                    ukPotroseno += ukupnaCena;
                    Console.WriteLine("UK POTROSENO: " + ukPotroseno);
                }
            }

            foreach (Igrac i in CrveniTim)
            {
                if (i.heroj.StanjeNovcica >= 500)
                {
                    Kupi(i, prod, out int ukupnaCena);
                    ukPotroseno += ukupnaCena;
                    Console.WriteLine("UK POTROSENO: " + ukPotroseno);
                }
            }
            totalPotroseno += ukPotroseno;
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
                    Console.WriteLine("Kupljeno oruzje: " + o.Naziv + " za " + o.Cena);
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
                    ukupnaCena += n.Cena;
                    Console.WriteLine("Kupljen napitak: " + n.Naziv + " za " + n.Cena);
                }
                else
                {
                    Console.WriteLine("Napitak " + n.Naziv + " vise nije dostupan.");
                }
            }

            Console.WriteLine("Igrac je potrosio: " + ukupnaCena);
        }

    }
}
