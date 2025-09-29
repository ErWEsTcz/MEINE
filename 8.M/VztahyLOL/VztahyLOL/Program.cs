using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VztahyLOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vztahy kekw = new Vztahy(4);
            Console.WriteLine();
            kekw.Print();
            Console.ReadLine();
        }
    }

    class Vztahy
    {
        public Vztahy(int pocetLidi)
        {
            PocetLidi = pocetLidi;
            PreferenceZen = new int[pocetLidi,pocetLidi];
            PreferenceMuzu = new int[pocetLidi, pocetLidi];
            PrecteniPreferenci();
        }
        int PocetLidi {  get; set; }
        int[,] PreferenceMuzu { get; set; }
        int[,] PreferenceZen { get; set; }
        bool[,] AktualniStav {  get; set; }



        public void PrecteniPreferenci()
        {
            Console.WriteLine("Zadej preference");

            for (int i = 0; i < PocetLidi; i++)
            {
                string[] radek = Console.ReadLine().Split(' ');

                for (int j = 0; j < PocetLidi; j++)
                {
                    PreferenceZen[i, j] = Convert.ToInt16(radek[j]);
                }
            }

            for (int i = 0; i < PocetLidi; i++)
            {
                string[] radek = Console.ReadLine().Split(' ');

                for (int j = 0; j < PocetLidi; j++)
                {
                    PreferenceMuzu[i, j] = Convert.ToInt16(radek[j]);
                }
            }
        }

        public int[] VytvoreniStability()
        {
            int[] vysledek = new int[PocetLidi];
            bool zmena = true;

            for (int i = 0;i < PocetLidi; i++)
            {
                AktualniStav[i, PreferenceZen[i, 0] - 1] = true;
            }

            while(zmena == true)
            {

            }




            return vysledek;
        }

        public void Print()
        {
            for (int i = 0; i < PocetLidi; i++)
            {
                StringBuilder radek = new StringBuilder();
                for (int j = 0; j < PocetLidi; j++)
                {
                    radek.Append(PreferenceZen[i, j]);
                    radek.Append(' ');
                }
                Console.WriteLine(radek.ToString());
            }
        }
    }
}
