using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Servisi;

namespace Common.Modeli
{
    public class Entitet
    {
        public int Poeni { get; set; }
        public Entitet() 
        {
            Poeni = generisiPoene();
        }

        private int generisiPoene()
        {
            Random random = new Random();
            int novcici = random.Next(20, 91);
            return novcici;
        }
    }
}
