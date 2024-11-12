using Common.Enumeracije;

namespace Common.Modeli
{
    public class Mapa
    {
        public string NazivMape { get; set; } = string.Empty;

        public Tip_Mape TipMape { get; set; }

        public int MaxIgraca { get; set; }

        public string PlaviTim { get; set; } = string.Empty;

        public string CrveniTim { get; set; } = string.Empty;

        public int PomocniEntiteti { get; set; }

        public Mapa() { }

        public Mapa(string nazivMape, Tip_Mape tipMape, int maxIgraca, string plaviTim, string crveniTim, int pomocniEntiteti)
        {
            NazivMape = nazivMape;
            TipMape = tipMape;
            MaxIgraca = maxIgraca;
            PlaviTim = plaviTim;
            CrveniTim = crveniTim;
            PomocniEntiteti = pomocniEntiteti;
        }
    }
}
