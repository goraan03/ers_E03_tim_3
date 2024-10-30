using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Modeli;
using Common.Servisi;

namespace Servisi.Autentifikacija
{
    public class Autentifikacija : IAutentifikacija
    {
        private static readonly List<Korisnik> ListaKorisnika;

        static Autentifikacija()
        {
            ListaKorisnika = new List<Korisnik>
            {
                new Korisnik("goran03", "LozinkaGoran", "Goran Grcic"),
                new Korisnik("miroslav03", "LozinkaMiroslav", "Miroslav Dispiter")
            };
        }
        public bool Prijava(string korisnickoIme, string lozinka, out Korisnik? prijavljen)
        {
            Korisnik? korisnik = ListaKorisnika.FirstOrDefault(k => k.KorisnickoIme.Equals(korisnickoIme));
            if (korisnik == null)
            {
                Console.WriteLine("Nepostojece korisnicko ime!\n");
                prijavljen = null;
                return false;
            }

            if (string.IsNullOrEmpty(lozinka))
            {
                Console.WriteLine("Lozinka ne moze biti prazna! Pokusajte ponovo!\n");
                prijavljen = null;
                return false;
            }78--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------0

            if (!korisnik.Lozinka.Equals(lozinka))
            {
                prijavljen = null;
                return false;
            }
            prijavljen = korisnik;
            return true;
        }
    }
}