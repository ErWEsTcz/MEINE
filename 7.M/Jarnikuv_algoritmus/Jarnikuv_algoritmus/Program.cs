using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jarnikuv_algoritmus
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
        static int[,] Jarnikuv_alg(int[,] matice)
        {
            int v = 0;
            List<int> sousedi = new List<int>();
            for (int i = 0; i < matice.GetLength(0); i++)
            {
                if (matice[0, i] > 0) // + jestli je v sousedech a ma mensi hodnotu 
                {
                    sousedi.Add(i);
                    int nejkratsi_cesta = matice[i, 0];
                }

            }





            int[,] kekw = { };
            return kekw;
        }
    }
}
