using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace AutokTxt
{
    internal class Program
    {
        struct Auto
        {
            public string rendszam;
            public string marka;
            public string szin;
            public int ev;
            public int ar;
            public string tulaj;
        }
        static void Main(string[] args)
        {
            List<Auto> autok = new List<Auto>();

            Auto egyAuto = new Auto();
            try
            {
                foreach (var egySor in File.ReadAllLines("Autok.txt"))
                {
                    string[] sorok = egySor.Split("\t");

                    egyAuto.rendszam = sorok[0];
                    egyAuto.marka = sorok[1];
                    egyAuto.szin = sorok[2];
                    egyAuto.ev = Convert.ToInt32(sorok[3]);
                    string pont = sorok[4].Replace(',', ' ').Replace(" ","");
                    egyAuto.ar = Convert.ToInt32(pont);
                    
                    egyAuto.tulaj = sorok[5];

                    autok.Add(egyAuto);
                }
            }
            catch (Exception hiba) 
            {
                Console.WriteLine(hiba.Message);
            }
            //2. feladat Írassuk ki, hogy összesen autó adatát tartalmazza az autok.txt állomány
            Console.WriteLine($"Összesen {autok.Count} autó található az állományban");
            //3. feladat számoljuk össze, hogy típusokként hány darabot használnak, ezeknek mennyi az értéke összesen
            List<string> markanev = new List<string>();
            List<int> darabszamok = new List<int>();
            List<long> osszertekek = new List<long>();
            foreach (var auto in autok)
            {
                int index = markanev.IndexOf(auto.marka);
                if (index == -1)
                {
                    markanev.Add(auto.marka);
                    darabszamok.Add(1);
                    osszertekek.Add(auto.ar);
                }
                else
                {
                    darabszamok[index]++;
                    osszertekek[index] += auto.ar;
                }
            }
            for(int i = 0; i < markanev.Count; i++)
            {
                Console.WriteLine($"{markanev[i]}: {darabszamok[i]} db, összérték: {osszertekek[i]}");
            }

            //4.feladat: jelenítsük meg a legdrágább autó adatait
            Auto legdragabb = autok[0];
            foreach (Auto auto in autok)
            {

                if (auto.ar > legdragabb.ar)
                {
                    legdragabb = auto;

                }
            }
            Console.WriteLine("legdrágább autó:");
            Console.WriteLine($"\n Rendszám:{legdragabb.rendszam}");
            Console.WriteLine($"\n Márka:{legdragabb.marka}");
            Console.WriteLine($"\n Szín:{legdragabb.szin}");
            Console.WriteLine($"\n Évjárat:{legdragabb.ev}");
            Console.WriteLine($"\n Ár:{legdragabb.ar}");
            Console.WriteLine($"\n Tulajdonos:{legdragabb.tulaj}");

            //5.feladat: írjuk ki fájlba az autók típusát, színét és tulajdonosát!
            StreamWriter kifajl = new StreamWriter("kiirás.txt");
            foreach (Auto elem in autok)
            {
                kifajl.WriteLine($"{elem.marka} {elem.szin} {elem.tulaj}");
            }
            kifajl.Close();

            Console.ReadKey();
        }
    }
}
