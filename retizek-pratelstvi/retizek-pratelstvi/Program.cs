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

            }
        }
    }
}
