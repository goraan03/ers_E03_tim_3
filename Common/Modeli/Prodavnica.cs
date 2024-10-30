using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modeli
{
    public class Prodavnica
    {
        public int ID { get; set; }
        public List<Oruzje> Oruzje { get; set; }
        public List<Napici> Napicis { get; set; }
        public int Vrednost { get; set; }

        public Prodavnica() { }

        public Prodavnica(int iD, List<Oruzje> oruzje, List<Napici> napici, int vrednost)
        {
            ID = iD;
            Oruzje = oruzje;
            Napicis = napici;
            Vrednost = vrednost;
        }

        // mozda dodati funkciju private int izracunajUkupnuVrednost() za racunanje ukupne cene (jer u zagradama pise kao napici + vrednost tamo u pdf-u)
    }
}