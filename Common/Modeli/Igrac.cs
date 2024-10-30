using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Servisi;

namespace Common.Modeli
{
    public class Igrac
    {
        public string Naziv { get; set; }
        public Heroj heroj { get; set; } = new Heroj();
        public Igrac() { }

        public Igrac(string naziv, Heroj heroj)
        {
            Naziv = naziv;
            this.heroj = heroj;
        }
    }
}
