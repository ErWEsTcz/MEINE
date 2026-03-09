using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Mince
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] mince = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int suma = int.Parse(Console.ReadLine());
            Array.Sort(mince);
            Array.Reverse(mince);
            Console.WriteLine();
            NajdiReseni(mince, suma);
        }

        static void NajdiReseni(int[] mince, int suma)
        {
            int[] reseni = new int[suma];

            NajdiKombinace(mince, suma, reseni, 0, 0);

        }

        static void NajdiKombinace(int[] mince, int zbyvaZaplatit, int[] reseni, int aktualniPozice, int indexMince)
        {
            if (zbyvaZaplatit == 0)
            {
                /*
                for (int i = 0; i < aktualniPozice; i++)
                {
                    Console.WriteLine(reseni[i] + " ");
                }
                Console.WriteLine();
                return;
                */
                string[] vystup = new string[aktualniPozice];

                for (int i = 0; i < aktualniPozice; i++)
                {
                    vystup[i] = Convert.ToString(reseni[i]);
                }

                Console.WriteLine(string.Join(" ", vystup));
                return;
            }

            for (int i = indexMince; i < mince.Length; i++)
            {
                if (zbyvaZaplatit - mince[i] >= 0)
                {
                    reseni[aktualniPozice] = mince[i];

                    NajdiKombinace(mince, zbyvaZaplatit - mince[i], reseni, aktualniPozice + 1, i);
                }
            }
        }
    }
}
