using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutokTxt
{
    internal class Autoim
    {
        public string rendszam;
        public string marka;
        public string szin;
        public int ev;
        public int ar;
        public string tulaj;
        public Autoim(string sor)
        {
            string[] sorok = sor.Split("\t");
        rendszam = sorok[0];
        marka = sorok[1];
        szin = sorok[2];
        ev = Convert.ToInt32(sorok[3]);
        string pont = sorok[4].Replace(',', ' ').Replace(" ", "");
        ar = Convert.ToInt32(pont);
        tulaj = sorok[5];
        }
    }
    
}
