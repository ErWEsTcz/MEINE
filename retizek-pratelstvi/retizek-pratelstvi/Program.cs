using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace retizek_pratelstvi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pocet_lidi = Convert.ToInt32(Console.ReadLine());

            string[] vsechny_dcojice = Console.ReadLine().Split();

            string[] zacatek_a_konec = Console.ReadLine().Split();

            int zacatek = Convert.ToInt32(zacatek_a_konec[0]) - 1;

            int konec = Convert.ToInt32(zacatek_a_konec[1]) - 1;

            bool[,] pratelstvi = new bool[pocet_lidi, pocet_lidi];

            for (int i = 0; i < vsechny_dcojice.Length; i++)
            {
                string[] dvojice = vsechny_dcojice[i].Split('-');

                pratelstvi[Convert.ToInt32(dvojice[0]) - 1, Convert.ToInt32(dvojice[1]) - 1] = true;

                pratelstvi[Convert.ToInt32(dvojice[1]) - 1, Convert.ToInt32(dvojice[0]) - 1] = true;
            }

            BFS(pratelstvi, zacatek, konec);
            Console.ReadLine();
        }

        static void BFS(bool[,] pratelstvi, int zacatek, int konec)
        {
            int pocetLidi = Convert.ToInt32(Math.Sqrt(pratelstvi.Length));
            List<string> stavy = new List<string>();
            for (int i = 0; i < pocetLidi; i++)
            {
                stavy.Add("nenalezený");
            }
            stavy[zacatek] = "otevřený";

            List<int> vzdalenost = new List<int>();
            for (int i = 0; i < pocetLidi; i++)
            {
                vzdalenost.Add(0);
            }

            List<int> predchudce = new List<int>();
            for (int i = 0; i < pocetLidi; i++)
            {
                predchudce.Add(0);
            }

            Queue<int> fronta = new Queue<int>();
            fronta.Enqueue(zacatek);
            while (fronta.Count > 0)
            {
                int clovek = fronta.Dequeue();
                for (int j = 0; j < pocetLidi; j++)
                {
                    if (pratelstvi[clovek,j] == true)
                    {
                        if (stavy[j] == "nenalezený")
                        {
                            fronta.Enqueue(j);
                            stavy[j] = "otevřený";
                            predchudce[j] = clovek;
                            vzdalenost[j] = vzdalenost[clovek] + 1;
                        }
                    }                   
                }
                stavy[clovek] = "uzavřený";
            }

            if (stavy[konec] == "uzavřený")
            {
                int clovek = konec;
                List<int> cestaZpet = new List<int>();
                for (int j = 0;j < vzdalenost[konec]; j++)
                {
                    cestaZpet.Add(clovek);
                    clovek = predchudce[clovek];
                }

                cestaZpet.Reverse();
                Console.WriteLine(string.Join(" ", cestaZpet));

            }
            else
            {
                Console.WriteLine("neexistuje");
            }

        }
    }
}
