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
            Console.WriteLine("zadejte pocet muzu/zen");
            int n = Convert.ToInt32(Console.ReadLine());
            Vztahy kekw = new Vztahy(n);
            int[] manzelstvi = kekw.VytvoreniStability();
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(manzelstvi[i]);
            }
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
            int[] manzelstvi = new int[PocetLidi];
            int[] pocetManzelstvi = new int[PocetLidi];
            int[] spokojenostMuzu = new int[PocetLidi];
            int hledanyMuz;
            int hodnostZeny = 0;

            for (int i = 0; i < PocetLidi; i++)
            {
                manzelstvi[i] = -1;
                spokojenostMuzu[i] = -1;
            }

            bool zmena = true;

            while (zmena == true)
            {
                zmena = false;
                for (int i = 0;i < PocetLidi; i++)
                {
                    hledanyMuz = PreferenceZen[i, pocetManzelstvi[i]] - 1;
                    if (manzelstvi[i] == -1)
                    {
                        for (int j = 0; j < PocetLidi; j++)
                        {
                            if (i == PreferenceMuzu[hledanyMuz,j] - 1)
                            {
                                hodnostZeny = j; break;
                            }
                        }

                        if (hodnostZeny < spokojenostMuzu[hledanyMuz] || spokojenostMuzu[hledanyMuz] == -1)
                        {
                            if (Array.IndexOf(manzelstvi, hledanyMuz) != -1)
                            {
                                manzelstvi[Array.IndexOf(manzelstvi, hledanyMuz)] = -1;
                            }
                            manzelstvi[i] = hledanyMuz;
                            spokojenostMuzu[hledanyMuz] = hodnostZeny;
                            
                        }


                        pocetManzelstvi[i]++;
                        zmena = true;
                    }
                }
            }
            for (int i = 0; i < PocetLidi; i++)
            {
                manzelstvi[i]++;
            }
            return manzelstvi;
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
