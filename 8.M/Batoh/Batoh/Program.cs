using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batoh
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }

        class Batoh
        {
            int[] Profity { get; set; }
            int[] Vahy { get; set; }
            int VahaBatohu { get; set; }

            public int[] CoSebou()
            {
                int[] NejlepsiBatoh = new int[Profity.Length];
                for (int i = 0; i < NejlepsiBatoh.Length; i++)
                {

                }

                return NejlepsiBatoh;
            }

            public int[] PridaniDoBatohu(int indexPredmetu, int[] aktualniBatoh)
            {
                aktualniBatoh[indexPredmetu] = 1;

                int aktualniVaha = 0;
                int aktualniProfit = 0;
                for (int i = 0; i < aktualniBatoh.Length; i++)
                {
                    if (aktualniBatoh[i] == 1)
                    {
                        aktualniVaha = aktualniVaha + Vahy[i];
                        aktualniProfit = aktualniProfit + Profity[i];
                    }
                }
                if (aktualniVaha > VahaBatohu)
                {
                    aktualniBatoh[indexPredmetu] = 0;
                    return aktualniBatoh;
                }

                return aktualniBatoh;
            }
        }
    /*
    class Batoh
    {
        int[] Profity {  get; set; }
        int[] Vahy { get; set; }
        int VahaBatohu { get; set; }

        int[] FinalniBatoh = new int[Profity.Length];

        public int[] CoSebou()
        {

        }

        public int[] PridaniDoBatohu()
        {

        }
    }
    */

}
