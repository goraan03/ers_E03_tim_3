using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Klase
{
    public class Prodavnica
    {
        public int ID { get; set; }
        public List<Oruzje> Oruzje { get; set; }
        public List<Napici> Napicis { get; set; }
        public int Vrednost { get; set; }

        public Prodavnica() { }

        public Prodavnica(int iD, List<Oruzje> oruzje, List<Napici> napicis, int vrednost)
        {
            ID = iD;
            Oruzje = oruzje;
            Napicis = napicis;
            Vrednost = vrednost;
        }
    }
}