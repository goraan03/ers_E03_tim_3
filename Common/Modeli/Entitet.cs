using Common.PomocneMetode.GenerisanjePoena;

namespace Common.Modeli
{
    public class Entitet
    {
        public int Poeni { get; set; }
        public Entitet()
        {
            Poeni = GeneratorPoena.GenerisiPoene();
        }


    }
}
