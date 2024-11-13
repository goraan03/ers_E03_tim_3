using Common.Modeli;
using Domain.Servisi;

namespace Servisi.IspisHeroja
{
    public class IspisHeroja : IIspisHeroja
    {
        public void ispisHeroja(List<Heroj> ListaHeroja)
        {
            int i = 1;
            foreach (Heroj h in ListaHeroja)
            {
                Console.WriteLine("Heroj broj " + i + ": Naziv: " + h.NazivHeroja + ", Zivotni Poeni: " + h.ZivotniPoeni + ", Jacina Napada: " + h.JacinaNapada);
                i++;
            }
        }
    }
}
