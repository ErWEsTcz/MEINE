using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connect4_CheckVyhry
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        static void CheckVyhry(int[,] hraciPole, int PocetNaVyhru, int[] PosledniZeton)
        {

            bool CheckRow()
            {
                for (int i = PosledniZeton[0] - PocetNaVyhru + 1; i < PocetNaVyhru + PosledniZeton[0] - 1; i++)
                {
                    
                }

                return true;
            }


            return;
        }
    }
}
