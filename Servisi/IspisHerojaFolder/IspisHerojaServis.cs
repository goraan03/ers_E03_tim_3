using Common.Modeli;
using Domain.Servisi;
using System.Text;

namespace Servisi.IspisHerojaFolder
{
    public class IspisHerojaServis : IIspisHeroja
    {
        public void IspisHeroja(List<Heroj> ListaHeroja)
        {
            StringBuilder sb = new StringBuilder();
            int i = 1;
            foreach (Heroj h in ListaHeroja)
            {
                sb.AppendLine("Heroj broj " + i + ": Naziv: " + h.NazivHeroja + ", Zivotni Poeni: " + h.ZivotniPoeni + ", Jacina Napada: " + h.JacinaNapada);
                i++;
            }

            Console.Write(sb.ToString());
        }
    }
}
