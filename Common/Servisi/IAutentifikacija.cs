using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeli;

namespace Common.Servisi
{
    public interface IAutentifikacija
    {
        public bool Prijava(string korisnickoIme, string lozinka, out Korisnik? prijavljen);
    }
}
