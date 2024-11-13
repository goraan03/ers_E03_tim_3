using Common.Modeli;

namespace Presentation
{
    public class TrajanjeBitkePresentation
    {
        public int ZapocniBitku(Mapa mapa)
        {
            Random rand = new Random();
            int trajanjeBitke = rand.Next(10, 46);

            Console.WriteLine("\n=============== Zapocinjanje bitke ================\n");
            Console.WriteLine($"Bitka između plavog i crvenog tima započinje na mapi " + mapa.NazivMape + " i traje" + trajanjeBitke + "sekundi.\n");

            Thread.Sleep(trajanjeBitke * 1000);
            return trajanjeBitke;
        }
    }
}
