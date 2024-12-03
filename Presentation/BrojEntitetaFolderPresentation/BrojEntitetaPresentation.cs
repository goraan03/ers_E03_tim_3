namespace Presentation.BrojEntitetaFolderPresentation
{
    public class BrojEntitetaPresentation
    {
        public int UnesiBrojEntiteta()
        {
            int brojEntiteta = 0;

            Console.WriteLine("\n================= Unos broja entiteta ===================\n");
            while (true)
            {
                try
                {
                    Console.Write("Unesite broj entiteta: ");
                    brojEntiteta = int.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception e)
                {
                    Console.WriteLine("Doslo je do greske: " + e.Message);
                }
            }
            return brojEntiteta;
        }
    }
}
