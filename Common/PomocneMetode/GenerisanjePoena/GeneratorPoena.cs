namespace Common.PomocneMetode.GenerisanjePoena
{
    public class GeneratorPoena
    {
        public static int GenerisiPoene()
        {
            Random random = new Random();
            int novcici = random.Next(20, 91);
            return novcici;
        }
    }
}
