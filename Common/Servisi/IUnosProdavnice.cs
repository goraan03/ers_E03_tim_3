using Common.Modeli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Servisi
{
    public interface IUnosProdavnice
    {
        bool unosProdavnice(int id, out Prodavnica? izabranaProdavnica);
        int IzracunajUkupnuVrednost(Prodavnica prodavnica);
    }
}
