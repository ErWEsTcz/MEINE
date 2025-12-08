using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MaturitniTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] sachovnice;
            sachovnice = PrecteniVstupu();

            Console.WriteLine(SachovyKun(sachovnice));
            Console.ReadLine();
        }

        static int[,] PrecteniVstupu()
        {
            using (StreamReader sr = new StreamReader(@"vstupni_soubory\1.txt"))
            {
                int[,] pole = new int[8,8];

                int pocetPrekazek = int.Parse(sr.ReadLine());

                string[] radek;
                int x;
                int y;

                for (int i = 0; i < pocetPrekazek; i++) //překážky...-1
                {
                    radek = sr.ReadLine().Split(' ');
                    x = int.Parse(radek[0]);
                    y = int.Parse(radek[1]);
                    pole[x, y] = -3;
                }

                radek = sr.ReadLine().Split(' '); //start...-2
                x = int.Parse(radek[0]);
                y = int.Parse(radek[1]);
                pole[x, y] = -1;

                radek = sr.ReadLine().Split(' '); //cíl...-3
                x = int.Parse(radek[0]);
                y = int.Parse(radek[1]);
                pole[x, y] = -2;


                return pole;
            }
        }

        static int SachovyKun(int[,] sachovnice)
        {
            int[] start = new int[2];
            int[] cil = new int[2];

            NajdiStartCil();

            Queue<int[]> mozneTahy = new Queue<int[]>();

            int[] moznyTah = new int[2];

            int[] aktualniTah = new int[2];

            List<int[]> predchoziTah = new List<int[]>();

            int hodnotaCile = sachovnice[cil[0], cil[1]];

            int hodnotaAktualnihoTahu;



            mozneTahy.Enqueue(start);

            while (mozneTahy.Count > 0) // dokud mám nějaké možné tahy, program pojede
            {
                aktualniTah = mozneTahy.Dequeue();

                hodnotaAktualnihoTahu = sachovnice[aktualniTah[0], aktualniTah[1]];

                if (aktualniTah == cil && hodnotaAktualnihoTahu < hodnotaCile) // pokud jsme se dostali do cíle a naše hodnota je menší než hodnota cíle, tak jsme našli lepší cestu a hodnotu cíle změníme
                {
                    hodnotaCile = hodnotaAktualnihoTahu;
                }

                HledaniMoznychTahu(aktualniTah);

            }

            return hodnotaCile;


            void NajdiStartCil() //nalezeni Startu a Cíle
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int z = 0; z < 8; z++)
                    {
                        if (sachovnice[i, z] == -2)
                        {
                            start[0] = i;
                            start[1] = z;
                        }
                        if (sachovnice[i, z] == -3)
                        {
                            cil[0] = i;
                            cil[1] = z;
                        }
                    }
                }
            }

            void HledaniMoznychTahu(int[] aktualniPozice) // nalezení možných tahů z aktuální pozice a přidání do fronty
            {
                //1. nesmí jít mimo index šachovnice a není to překážka tedy není hodnota -1

                if (aktualniPozice[0] > 1 && aktualniPozice[1] > 0  && sachovnice[aktualniPozice[0], aktualniPozice[1]] != -1)
                {
                    moznyTah[0] = aktualniPozice[0] - 2;
                    moznyTah[1] = aktualniPozice[1] - 1;
                }
                //...

                //nesmí mít větší hodnotu než hodnota, která na dané pozici již je
            }
        }

    }
}
