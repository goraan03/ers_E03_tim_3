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
        public int Vrednost => IzracunajUkupnuVrednost();

        public Prodavnica() { }

        public Prodavnica(int iD, List<Oruzje> oruzje, List<Napici> napici)
        {
            ID = iD;
            Oruzje = oruzje;
            Napicis = napici;
        }

        public int IzracunajUkupnuVrednost()
        {
            int ukupnaVrednostOruzja = Oruzje.Sum(o => o.Cena * o.Kolicina);
            int ukupnaVrednostNapitaka = Napicis.Sum(n => n.Cena * n.Kolicina);
            return ukupnaVrednostOruzja + ukupnaVrednostNapitaka;
        }
    }
}