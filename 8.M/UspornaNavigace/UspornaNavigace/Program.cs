using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace UspornaNavigace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] vstup = Console.ReadLine().Split(' ');
            int M = Convert.ToInt32(vstup[0]);

            int S = Convert.ToInt32(vstup[1]);

            UspornaNavigace navigace = new UspornaNavigace(M,S);


            Console.ReadLine();
        }

    }

    class UspornaNavigace
    {
        public UspornaNavigace(int PocetMest, int PocetSilnic)
        {
            pocetMest = PocetMest;
            vzdalenostMest = new int[pocetMest,pocetMest];
            placenost = new int[pocetMest,pocetMest];
            pocatecniMesto = 0;
            konecneMesto = 0;

            precteniVstupu(PocetSilnic);
        }

        int pocetMest {  get; }
        int[,] vzdalenostMest { get; set; }
        int[,] placenost {  get; set; }
        int pocatecniMesto {  get; set; }
        int konecneMesto { get; set; }

      
        private void precteniVstupu(int pocetSilnic)
        {
            for (int i = 0; i < pocetSilnic; i++)
            {
                int[] radekInt = new int[4];
                string[] radek = Console.ReadLine().Split(' ');
                for (int y = 0; y < 4; y++)
                {
                    radekInt[y] = Convert.ToInt32(radek[y]);
                }
                vzdalenostMest[radekInt[0], radekInt[1]] = radekInt[2];
                vzdalenostMest[radekInt[1], radekInt[0]] = radekInt[2];
                if (radekInt[3] == 1)
                {
                    placenost[radekInt[0], radekInt[1]] = 1;
                    placenost[radekInt[1], radekInt[0]] = 1;
                }
            }

            string[] posledniRadek = Console.ReadLine().Split(' ');
            pocatecniMesto = Convert.ToInt32(posledniRadek[0]);
            konecneMesto = Convert.ToInt32(posledniRadek[1]);
        }



    }
}
