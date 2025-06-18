using Common.Modeli;
using Common.Servisi;
using System.Text;

namespace Servisi.KupovinaFolder
{
    public class KupovinaServis : IKupovina
    {
        public void ObaviKupovinu(Igrac igr, Prodavnica prod, out int ukupnaCena)
        {
            ukupnaCena = 0;
            StringBuilder sb = new StringBuilder();

            foreach (Oruzje o in prod.Oruzje)
            {
                if (o.Kolicina > 0)
                {
                    igr.heroj.JacinaNapada += o.Napad;
                    igr.heroj.StanjeNovcica -= o.Cena;
                    o.Kolicina--;
                    ukupnaCena += o.Cena;
                    sb.AppendLine("Igrac " + igr.Naziv + " je kupio oruzje: " + o.Naziv + " za " + o.Cena);
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
                    sb.AppendLine("Igrac " + igr.Naziv + " je kupio napitak: " + n.Naziv + " za " + n.Cena);
                }
            }
            Console.Write(sb.ToString());
        }

    }
}
